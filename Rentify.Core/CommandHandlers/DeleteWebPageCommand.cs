using MediatR;

namespace Rentify.Core.CommandHandlers
{
    public class DeleteWebPageCommand : IAsyncRequest<ICommandResult>
    {
        public DeleteWebPageCommand(string userId, string siteUniqueId, int webPageId)
        {
            UserId = userId;
            SiteUniqueId = siteUniqueId;
            WebPageId = webPageId;
        }

        public string UserId { get; set; }
        public string SiteUniqueId { get; set; }
        public int WebPageId { get; set; }
    }
}