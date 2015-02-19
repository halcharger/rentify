using FluentValidation;
using Rentify.WebServer.Models;

namespace Rentify.WebServer.Validators
{
    public class RemoveGalleryImageModelValidator : AbstractValidator<RemoveGalleryImageBindingModel>
    {
        public RemoveGalleryImageModelValidator()
        {
            RuleFor(x => x.SiteUniqueId).NotEmpty().WithMessage("You must provide a value for site unique ID");
            RuleFor(x => x.GalleryId).NotEmpty().WithMessage("You must provide a value for gallery ID");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("You must provide a value for image url");
        }
    }
}