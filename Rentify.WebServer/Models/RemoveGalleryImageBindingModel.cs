using FluentValidation.Attributes;
using Rentify.WebServer.Validators;

namespace Rentify.WebServer.Models
{
    [Validator(typeof(RemoveGalleryImageModelValidator))]
    public class RemoveGalleryImageBindingModel
    {
        public string SiteUniqueId { get; set; }
        public string GalleryId { get; set; }
        public string ImageUrl { get; set; }
    }
}