using MediatR;
using Rentify.Core.Results;

namespace Rentify.Core.CommandHandlers
{
    public class UpdateSiteComponentBaseCommand : BaseCommand, IAsyncRequest<IResult>
    {
        public UpdateSiteComponentBaseCommand(string userId, string siteUniqueId)
        {
            SiteUniqueId = siteUniqueId;
            UserId = userId;
        }

        public string SiteUniqueId { get; set; }
    }
}