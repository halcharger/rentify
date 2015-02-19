using System.Threading.Tasks;
using Rentify.Core.Data;
using Rentify.Core.Results;

namespace Rentify.Core.CommandHandlers
{
    public class UpdatePropertyGalleryCommandHandler : UpdateSiteComponentBaseHandler<UpdatePropertyGalleryCommand>
    {
        public UpdatePropertyGalleryCommandHandler(IRentifyDataFacade data) : base(data) { }

        public override async Task<IResult> InnerHandle(UpdatePropertyGalleryCommand message)
        {
            if (site.Gallery.Id != message.Gallery.Id)
                return SimpleResult.Failure("The Gallery ID does not match what the system has stored for the Gallery ID");

            site.Gallery.Name = message.Gallery.Name;
            site.Gallery.Description = message.Gallery.Description;

            return SimpleResult.Success();
        }
    }
}