using MediatR;
using Rentify.Core.Results;

namespace Rentify.Core.CommandHandlers
{
    public class DeleteSiteCommand : BaseCommand, IAsyncRequest<IResult>
    {
        public DeleteSiteCommand(string userId, string siteUniqueId)
        {
            UserId = userId;
            SiteUniqueId = siteUniqueId;
        }

        public string SiteUniqueId { get; set; }
    }
}