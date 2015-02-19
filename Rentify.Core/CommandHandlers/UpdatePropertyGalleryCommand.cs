using Rentify.Core.Domain;

namespace Rentify.Core.CommandHandlers
{
    public class UpdatePropertyGalleryCommand : UpdateSiteComponentBaseCommand
    {
        public UpdatePropertyGalleryCommand(string userId, string siteUniqueId, Gallery gallery) : base(userId, siteUniqueId)
        {
            Gallery = gallery;
        }

        public Gallery Gallery { get; set; }

    }
}