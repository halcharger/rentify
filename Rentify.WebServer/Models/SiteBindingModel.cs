using FluentValidation.Attributes;
using Rentify.WebServer.Validators;

namespace Rentify.WebServer.Models
{
    [Validator(typeof(SiteBindingModelValidator))]
    public class SiteBindingModel
    {
        public string Name { get; set; }
        public string UniqueId { get; set; }
    }
}