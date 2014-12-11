using MediatR;
using Rentify.Core.Domain;

namespace Rentify.Core.CommandHandlers
{
    public class SaveWebPageCommand : IAsyncRequest<ICommandResult>
    {
        public SaveWebPageCommand(string userId, string siteUniqueId, WebPage webPage)
        {
            UserId = userId;
            SiteUniqueId = siteUniqueId;
            WebPage = webPage;
        }

        public string UserId { get; set; }
        public string SiteUniqueId { get; set; }
        public WebPage WebPage { get; set; }
    }
}