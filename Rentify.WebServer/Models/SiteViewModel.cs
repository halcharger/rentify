namespace Rentify.WebServer.Models
{
    public class SiteViewModel
    {
        public string Name { get; set; }
        public string UniqueId { get; set; }
        public string ThemeId { get; set; }

        public PropertyViewModel Property { get; set; }
    }
}