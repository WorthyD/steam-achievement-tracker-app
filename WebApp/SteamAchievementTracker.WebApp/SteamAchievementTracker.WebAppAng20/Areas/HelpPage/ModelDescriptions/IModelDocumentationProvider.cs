using System;
using System.Reflection;

namespace SteamAchievementTracker.WebAppAng20.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}