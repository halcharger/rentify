using MediatR;
using Rentify.Core.Domain;

namespace Rentify.Core.CommandHandlers
{
    public class EditWebPageCommand : IAsyncRequest<ICommandResult>
    {
        public string UserId { get; set; }
        public string SiteUniqueId { get; set; }
        public WebPage WebPage { get; set; }
    }
}