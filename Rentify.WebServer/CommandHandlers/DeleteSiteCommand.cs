using MediatR;

namespace Rentify.WebServer.CommandHandlers
{
    public class DeleteSiteCommand : IAsyncRequest<ICommandResult>
    {
        public string UserId { get; set; }
        public string SiteUniqueId { get; set; }
    }
}