using FluentValidation;
using Rentify.WebServer.Models;

namespace Rentify.WebServer.Validators
{
    public class UpdateContactBindingModelValidator : AbstractValidator<UpdateContactBindingModel>
    {
        public UpdateContactBindingModelValidator()
        {
            RuleFor(x => x.UniqueId).NotEmpty().WithMessage("You must provide a value for the site unique ID");
            RuleFor(x => x.Name).NotEmpty().WithMessage("You must provide a value for name");
            RuleFor(x => x.PrimaryNumber).NotEmpty().WithMessage("You must provide a value for primary contact number");
            RuleFor(x => x.Email).NotEmpty().WithMessage("You must provide a value for email");
        }
    }
}