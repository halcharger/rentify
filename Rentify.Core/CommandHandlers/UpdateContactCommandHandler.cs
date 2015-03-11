using System.Threading.Tasks;
using Rentify.Core.Data;
using Rentify.Core.Results;

namespace Rentify.Core.CommandHandlers
{
    public class UpdateContactCommandHandler : UpdateSiteComponentBaseHandler<UpdateContactCommand>
    {
        public UpdateContactCommandHandler(IRentifyDataFacade data) : base(data) { }

        public override async Task<IResult> InnerHandle(UpdateContactCommand message)
        {
            site.Property.Contact = message.Contact;

            return SimpleResult.Success();
        }
    }
}