using Microsoft.WindowsAzure.Storage.Table;

namespace Rentify.Core.Data.Entities
{
    public class SiteUniqueIdIndex : TableEntity
    {
        public SiteUniqueIdIndex() {}
        public SiteUniqueIdIndex(string siteUniqueId) : this(siteUniqueId, string.Empty) { }
        public SiteUniqueIdIndex(string siteUniqueId, string userId)
        {
            PartitionKey = siteUniqueId;
            RowKey = siteUniqueId;

            UserId = userId;
        }

        public string UserId { get; set; }
        public string SiteUniqueId { get { return PartitionKey; } }
    }
}