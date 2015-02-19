using System.Threading.Tasks;
using Rentify.Core.Data;
using Rentify.Core.Results;

namespace Rentify.Core.CommandHandlers
{
    public class UpdatePropertyOverviewCommandHandler : UpdateSiteComponentBaseHandler<UpdatePropertyOverviewCommand>
    {
        public UpdatePropertyOverviewCommandHandler(IRentifyDataFacade data) : base(data) { }

        public override async Task<IResult> InnerHandle(UpdatePropertyOverviewCommand message)
        {
            site.Property.Overview = message.PropertyOverview;

            return SimpleResult.Success();
        }
    }
}