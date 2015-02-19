using FluentValidation.Attributes;
using Rentify.WebServer.Validators;

namespace Rentify.WebServer.Models
{
    [Validator(typeof(UpdateLocationBindingModelValidator))]
    public class UpdateLocationBindingModel : LocationViewModel
    {
        public string UniqueId { get; set; }
    }
}