using System.Collections.Generic;

namespace Rentify.Core.Domain
{
    public class RentifySite
    {
        public RentifySite()
        {
            Pages = new List<WebPage>();
            Property = new Property();
            Location = new Location();
            Gallery = new Gallery();
        }

        public string Name { get; set; }
        public string UniqueId { get; set; }
        public string ThemeId { get; set; }
        public string MainTitle { get; set; }
        public string SubTitle { get; set; }

        public Property Property { get; set; }
        public Location Location { get; set; }
        public Gallery Gallery { get; set; }
        public List<WebPage> Pages { get; set; }
    }
}