namespace Rentify.Core.CommandHandlers
{
    public class AddGalleryImageCommand : UpdateSiteComponentBaseCommand
    {
        public AddGalleryImageCommand(string siteUniqueId, string userId, string galleryId, string imageName) : base(userId, siteUniqueId)
        {
            GalleryId = galleryId;
            ImageName = imageName;
        }

        public string GalleryId { get; set; }
        public string ImageName { get; set; }
    }
}