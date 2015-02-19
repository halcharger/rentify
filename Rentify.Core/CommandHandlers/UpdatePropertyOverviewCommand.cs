using Rentify.Core.Domain;

namespace Rentify.Core.CommandHandlers
{
    public class UpdatePropertyOverviewCommand : UpdateSiteComponentBaseCommand
    {
        public UpdatePropertyOverviewCommand(string userId, string siteUniqueId, PropertyOverview propertyOverview) : base(userId, siteUniqueId)
        {
            PropertyOverview = propertyOverview;
        }

        public PropertyOverview PropertyOverview { get; set; }
    }
}