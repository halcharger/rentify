using MediatR;

namespace Rentify.Core.CommandHandlers
{
    public class DeleteSiteCommand : IAsyncRequest<ICommandResult>
    {
        public DeleteSiteCommand(string userId, string siteUniqueId)
        {
            UserId = userId;
            SiteUniqueId = siteUniqueId;
        }

        public string UserId { get; set; }
        public string SiteUniqueId { get; set; }
    }
}