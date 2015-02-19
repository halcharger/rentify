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
            if (site.Gallery.ImageUrls != null && site.Gallery.ImageUrls.Contains(message.ImageUrl))
                site.Gallery.ImageUrls.Remove(message.ImageUrl);

            return SimpleResult.Success();
        }
    }
}