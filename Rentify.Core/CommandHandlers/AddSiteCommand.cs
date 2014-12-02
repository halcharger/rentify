using MediatR;
using Rentify.Core.Domain;

namespace Rentify.Core.CommandHandlers
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