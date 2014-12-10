using System.Collections.Generic;

namespace Rentify.Core.Domain
{
    public class RentifySite
    {
        public RentifySite()
        {
            Pages = new List<WebPage>();
        }

        public string Name { get; set; }
        public string UniqueId { get; set; }
        public string ThemeId { get; set; }
        public string LayoutId { get; set; }

        public List<WebPage> Pages { get; set; }
    }
}