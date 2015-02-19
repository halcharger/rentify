using FluentValidation;
using Rentify.WebServer.Models;

namespace Rentify.WebServer.Validators
{
    public class UpdateSiteThemeBindingModelValidator : AbstractValidator<UpdateSiteThemeBindingModel>
    {
        public UpdateSiteThemeBindingModelValidator()
        {
            RuleFor(x => x.UniqueId).NotEmpty().WithMessage("You must provide a value for the site unique ID");
            RuleFor(x => x.ThemeId).NotEmpty().WithMessage("You must provide a value for the site theme");
        }
    }
}