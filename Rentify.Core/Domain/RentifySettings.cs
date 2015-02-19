using System.Collections.Generic;
using System.Linq;

namespace Rentify.Core.Domain
{
    public class RentifySettings
    {
        public RentifySettings()
        {
            Sites = new List<RentifySite>();
        }

        public List<RentifySite> Sites { get; set; }

        public RentifySite GetSiteByUniqueId(string uniqueId)
        {
            return Sites.SingleOrDefault(s => s.UniqueId == uniqueId);
        }
    }
}