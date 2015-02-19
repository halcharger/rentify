using FluentValidation;
using Rentify.WebServer.Models;

namespace Rentify.WebServer.Validators
{
    public class UpdatePropertyGalleryBindingModelValidator : AbstractValidator<UpdatePropertyGalleryBindingModel>
    {
        public UpdatePropertyGalleryBindingModelValidator()
        {
            RuleFor(x => x.UniqueId).NotEmpty().WithMessage("You must provide a value for the site unique ID");
            RuleFor(x => x.Name).NotEmpty().WithMessage("You must provide a value for the property name");
        }
    }
}