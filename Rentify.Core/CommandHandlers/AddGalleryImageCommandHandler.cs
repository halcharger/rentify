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
            if (site.Property.Gallery.Images == null)
                site.Property.Gallery.Images = new List<AzureBlobImage>();

            site.Property.Gallery.Images.Add(message.Image);

            return SimpleResult.Success();
        }

    }
}