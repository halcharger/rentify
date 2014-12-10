using FluentValidation;
using Rentify.WebServer.Models;

namespace Rentify.WebServer.Validators
{
    public class PageBindingModelValidator : AbstractValidator<PageBindingModel>
    {
        public PageBindingModelValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("You must provide a value for page title");
            RuleFor(x => x.Content).NotEmpty().WithMessage("You must provide a value for page content");
        }
    }
}