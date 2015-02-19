using FluentValidation.Attributes;
using Rentify.WebServer.Validators;

namespace Rentify.WebServer.Models
{
    [Validator(typeof(AddSiteBindingModelValidator))]
    public class AddSiteBindingModel
    {
        public string Name { get; set; }
        public string UniqueId { get; set; }
    }
}