using System.Collections.Generic;
using System.Threading.Tasks;
using Rentify.Core.Data;
using Rentify.Core.Domain;
using Rentify.Core.Results;

namespace Rentify.Core.CommandHandlers
{
    public class AddGalleryImageCommandHandler : UpdateSiteComponentBaseHandler<AddGalleryImageCommand>
    {
        public AddGalleryImageCommandHandler(IRentifyDataFacade data) : base(data) { }

        public override async Task<IResult> InnerHandle(AddGalleryImageCommand message)
        {
            var imageUrl = Gallery.GetGalleryImageUrl(RentifyConfig.RentifyAzureStorageConnectionStringAccountName, message.SiteUniqueId, message.ImageName);

            if (site.Gallery.ImageUrls == null)
                site.Gallery.ImageUrls = new List<string>();

            site.Gallery.ImageUrls.Add(imageUrl);

            return SimpleResult.Success();
        }

    }
}