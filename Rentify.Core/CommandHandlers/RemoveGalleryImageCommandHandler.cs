using System.Linq;
using System.Threading.Tasks;
using Rentify.Core.Data;
using Rentify.Core.Results;

namespace Rentify.Core.CommandHandlers
{
    public class RemoveGalleryImageCommandHandler : UpdateSiteComponentBaseHandler<RemoveGalleryImageCommand>
    {
        public RemoveGalleryImageCommandHandler(IRentifyDataFacade data) : base(data) { }

        public override async Task<IResult> InnerHandle(RemoveGalleryImageCommand message)
        {
            if (site.Property.Gallery.Images != null)
            {
                var img = site.Property.Gallery.Images.SingleOrDefault(
                        i => i.GetAzureImageUrl() == message.ImageUrl ||
                            i.GetImageResizerUrl() == message.ImageUrl);
                site.Property.Gallery.Images.Remove(img);
            }

            return SimpleResult.Success();
        }
    }
}