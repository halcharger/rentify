using Rentify.Core.Domain;

namespace Rentify.Core.CommandHandlers
{
    public class AddGalleryImageCommand : UpdateSiteComponentBaseCommand
    {
        public AddGalleryImageCommand(string siteUniqueId, string userId, string galleryId, AzureBlobImage image)
            : base(userId, siteUniqueId)
        {
            GalleryId = galleryId;
            Image = image;
        }

        public string GalleryId { get; set; }
        public AzureBlobImage Image { get; set; }
    }
}