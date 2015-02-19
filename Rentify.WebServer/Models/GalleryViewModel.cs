using System.Collections.Generic;

namespace Rentify.WebServer.Models
{
    public class GalleryViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ImageViewModel> Images { get; set; }
    }
}