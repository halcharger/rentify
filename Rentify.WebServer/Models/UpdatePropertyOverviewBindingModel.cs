using FluentValidation.Attributes;
using Rentify.WebServer.Validators;

namespace Rentify.WebServer.Models
{
    [Validator(typeof(UpdatePropertyOverviewBindingModelValidator))]
    public class UpdatePropertyOverviewBindingModel : PropertyOverviewViewModel
    {
        public string UniqueId { get; set; }
    }
}