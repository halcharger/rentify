using FluentValidation;
using Rentify.WebServer.Models;

namespace Rentify.WebServer.Validators
{
    public class UpdateLocationBindingModelValidator : AbstractValidator<UpdateLocationBindingModel>
    {
        public UpdateLocationBindingModelValidator()
        {
            RuleFor(x => x.UniqueId).NotEmpty().WithMessage("You must provide a value for the site unique ID");
            RuleFor(x => x.AddressLine1).NotEmpty().WithMessage("You must provide a value for address line 1");
            RuleFor(x => x.Province).NotEmpty().WithMessage("You must provide a value for province");
            RuleFor(x => x.Country).NotEmpty().WithMessage("You must provide a value for country");
        }
    }
}