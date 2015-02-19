namespace Rentify.Core.CommandHandlers
{
    public class UpdateSiteThemeCommand : UpdateSiteComponentBaseCommand
    {
        public UpdateSiteThemeCommand(string userId, string siteUniqueId, string themeId) : base(userId, siteUniqueId)
        {
            ThemeId = themeId;
        }

        public string ThemeId { get; set; }
    }
}