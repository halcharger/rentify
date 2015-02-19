namespace Rentify.Core.CommandHandlers
{
    public class RemoveGalleryImageCommand : UpdateSiteComponentBaseCommand
    {
        public RemoveGalleryImageCommand(string userId, string siteUniqueId, string galleryId, string imageUrl) : base(userId, siteUniqueId)
        {
            GalleryId = galleryId;
            ImageUrl = imageUrl;
        }

        public string GalleryId { get; set; }
        public string ImageUrl { get; set; }
    }
}