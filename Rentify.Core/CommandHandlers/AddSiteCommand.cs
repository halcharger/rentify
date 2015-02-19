using MediatR;
using Rentify.Core.Results;

namespace Rentify.Core.CommandHandlers
{
    public class AddSiteCommand : BaseCommand, IAsyncRequest<IResult>
    {
        public AddSiteCommand(string userId, string name, string uniqueId)
        {
            Name = name;
            UniqueId = uniqueId;
            UserId = userId;
        }

        public string Name { get; set; }
        public string UniqueId { get; set; }
    }
}