using System.Threading.Tasks;
using Rentify.Core.Data;
using Rentify.Core.Results;

namespace Rentify.Core.CommandHandlers
{
    public class UpdateLocationCommandHandler : UpdateSiteComponentBaseHandler<UpdateLocationCommand>
    {
        public UpdateLocationCommandHandler(IRentifyDataFacade data) : base(data) { }

        public override async Task<IResult> InnerHandle(UpdateLocationCommand message)
        {
            site.Property.Location = message.Location;

            return SimpleResult.Success();
        }
    }
}