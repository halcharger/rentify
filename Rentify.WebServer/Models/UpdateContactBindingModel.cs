using FluentValidation.Attributes;
using Rentify.WebServer.Validators;

namespace Rentify.WebServer.Models
{
    [Validator(typeof(UpdateContactBindingModelValidator))]
    public class UpdateContactBindingModel : ContactViewModel
    {
        public string UniqueId { get; set; }
    }
}