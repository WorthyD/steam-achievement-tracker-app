using SteamApiWrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAchievementTracker.BLL.Providers
{
    public class GameAchievementProvider : BaseProvider
    {
        public async Task GetGameAchievements(long appId, long steamId)
        {
            var db = new DataAccess.ModelContext();

            var game = db.GameSchemas.Where(x => x.AppId == appId).FirstOrDefault();

            if (game == null || ExperationService.isSchemaExpired(game.LastSchemaSUpdate))
            {
                var gameSchemaRequest = new SteamApiWrapper.SteamUserStats.GetSchemaForGameRequest(base.APIKey);
                gameSchemaRequest.appid = (int)appId;


                var gameSchema = await gameSchemaRequest.GetResponse();
                ProcessSchema(db, appId, game, gameSchema.GameSchema);



            }

            db.Dispose();
        }

        public DataAccess.Models.GameSchema ProcessSchema(DataAccess.ModelContext db, long appId, DataAccess.Models.GameSchema game, SchemaForGame.Game gameSchema)
        {
            if (game == null)
            {
                game = new DataAccess.Models.GameSchema();
                db.GameSchemas.Add(game);
                game.AppId = appId;
            }

            game.Name = gameSchema.gameName;

            if (gameSchema.availableGameStats != null && gameSchema.availableGameStats.achievements != null)
            {
                var gameAchievements = game.GameAchievements;

                if (gameAchievements == null)
                {
                    game.GameAchievements = new List<DataAccess.Models.GameAchievement>();


                }
                else {

                }
            }
            else {
                game.HasAchievements = false;
            }




            return game;
        }
    }
}
