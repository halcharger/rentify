using System.Threading.Tasks;
using Rentify.Core.Data;
using Rentify.Core.Results;

namespace Rentify.Core.CommandHandlers
{
    public class UpdateSiteThemeCommandHandler : UpdateSiteComponentBaseHandler<UpdateSiteThemeCommand>
    {
        public UpdateSiteThemeCommandHandler(IRentifyDataFacade data) : base(data) { }

        public override async Task<IResult> InnerHandle(UpdateSiteThemeCommand message)
        {
            site.ThemeId = message.ThemeId;

            return SimpleResult.Success();
        }
    }
}