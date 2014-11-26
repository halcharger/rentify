using FluentValidation;
using Rentify.WebServer.Models;

namespace Rentify.WebServer.Validators
{
    public class SiteBindingModelValidator : AbstractValidator<SiteBindingModel>
    {
        public SiteBindingModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("You must provide a value for site name");
            RuleFor(x => x.UniqueId).NotEmpty().WithMessage("You must provide a value for site unique ID");
        }
    }
}