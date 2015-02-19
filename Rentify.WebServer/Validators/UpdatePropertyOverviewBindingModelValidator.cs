using FluentValidation;
using Rentify.WebServer.Models;

namespace Rentify.WebServer.Validators
{
    public class UpdatePropertyOverviewBindingModelValidator : AbstractValidator<UpdatePropertyOverviewBindingModel>
    {
        public UpdatePropertyOverviewBindingModelValidator()
        {
            RuleFor(x => x.UniqueId).NotEmpty().WithMessage("You must provide a value for the site unique ID");
            RuleFor(x => x.Name).NotEmpty().WithMessage("You must provide a value for the property name");
            RuleFor(x => x.MainTitle).NotEmpty().WithMessage("You must provide a value for the main title");
            RuleFor(x => x.Sleeps).NotEmpty().WithMessage("You must provide a value for sleeps (number of people who can sleep in the property)");
        }
    }
}