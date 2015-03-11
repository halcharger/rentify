using Rentify.Core.Domain;

namespace Rentify.Core.CommandHandlers
{
    public class UpdateContactCommand : UpdateSiteComponentBaseCommand
    {
        public UpdateContactCommand(string userId, string siteUniqueId, Contact contact) : base(userId, siteUniqueId)
        {
            Contact = contact;
        }

        public Contact Contact { get; set; }
    }
}