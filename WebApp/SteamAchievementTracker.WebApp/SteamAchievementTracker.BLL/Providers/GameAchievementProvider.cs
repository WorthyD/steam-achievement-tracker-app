using SteamApiWrapper.Models;
using SteamAchievementTracker.BLL.Converters.ServiceToModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using SteamAchievementTracker.Contracts.Models;

namespace SteamAchievementTracker.BLL.Providers
{
    public class GameAchievementProvider : BaseProvider
    {

        public async Task<Contracts.Models.IGameSchema> GetGameAchievements(long appId)
        {
            var db = new DataAccess.ModelContext();

            var game = db.GameSchemas.Include(x => x.GameAchievements).Where(x => x.AppId == appId).FirstOrDefault();

            if (game == null || ExperationService.isSchemaExpired(game.LastSchemaUpdate))
            {
                var gameSchemaRequest = new SteamApiWrapper.SteamUserStats.GetSchemaForGameRequest(base.APIKey);
                var gameStatRequest = new SteamApiWrapper.SteamUserStats.GetGlobalAchievementPercentagesForAppRequest();
                gameSchemaRequest.appid = (int)appId;
                gameStatRequest.GameId = (int)appId;

                var gameSchema = gameSchemaRequest.GetResponse();
                var gameStats = gameStatRequest.GetResponse();

                await Task.WhenAll(gameSchema, gameStats);
                var gameSchemaResult = await gameSchema;
                var gameStatsResult = await gameStats;

                ProcessSchema(db, appId, game, gameSchemaResult.GameSchema, gameStatsResult.GlobalAchievementPercentages.achievements);
            }

            db.Dispose();
            return game;
        }

        public DataAccess.Models.GameSchema ProcessSchema(DataAccess.ModelContext db, long appId, DataAccess.Models.GameSchema game, SchemaForGame.Game gameSchema, List<GlobalAchievementPercentages.Achievement> achievementPercentages)
        {
            if (game == null)
            {
                game = new DataAccess.Models.GameSchema();
                db.GameSchemas.Add(game);
                game.AppId = appId;
            }

            game.Name = (string.IsNullOrEmpty(gameSchema.gameName)) ? "Name title found" : gameSchema.gameName;

            if (gameSchema.availableGameStats != null && gameSchema.availableGameStats.achievements != null)
            {
                var gameAchievements = game.GameAchievements;


                if (gameAchievements == null)
                {
                    var ga = new List<DataAccess.Models.GameAchievement>();
                    game.GameAchievements = ga.ToList<IGameAchievement>();// as List<IGameAchievement>;
                    //game.GameAchievements = new IList<IGameAchievement>();
                }

                //Update data
                foreach (var ach in gameSchema.availableGameStats.achievements)
                {
                    var gameAch = game.GameAchievements.Where(x => x.Name == ach.name).FirstOrDefault();
                    if (gameAch == null)
                    {
                        gameAch = new DataAccess.Models.GameAchievement();
                        game.GameAchievements.Add(gameAch);
                    }
                    gameAch.ConvertService(appId, ach, achievementPercentages.Where(x => x.name == ach.name).FirstOrDefault());
                }
                game.LastSchemaUpdate = DateTime.Now;
                game.HasAchievements = true;
            }
            else {
                game.HasAchievements = false;
            }

            db.SaveChanges();

            return game;
        }
    }
}
