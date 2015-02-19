using Rentify.Core.Domain;

namespace Rentify.Core.CommandHandlers
{
    public class UpdateLocationCommand : UpdateSiteComponentBaseCommand
    {
        public UpdateLocationCommand(string userId, string siteUniqueId, Location location) : base(userId, siteUniqueId)
        {
            Location = location;
        }

        public Location Location { get; set; }
    }
}