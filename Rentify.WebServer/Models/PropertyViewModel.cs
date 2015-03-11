namespace Rentify.WebServer.Models
{
    public class PropertyViewModel
    {
        public PropertyOverviewViewModel Overview { get; set; }
        public LocationViewModel Location { get; set; }
        public GalleryViewModel Gallery { get; set; }
        public ContactViewModel Contact { get; set; }
    }
}