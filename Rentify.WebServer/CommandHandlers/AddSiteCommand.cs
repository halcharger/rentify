using MediatR;
using Rentify.WebServer.Domain;

namespace Rentify.WebServer.CommandHandlers
{
    public class AddSiteCommand : IAsyncRequest<ICommandResult>
    {
        public AddSiteCommand(string userId, RentifySite site)
        {
            UserId = userId;
            Site = site;
        }

        public string UserId { get; set; }
        public RentifySite Site { get; set; } 
    }
}