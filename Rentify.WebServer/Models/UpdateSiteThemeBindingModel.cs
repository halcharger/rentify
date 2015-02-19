using FluentValidation.Attributes;
using Rentify.WebServer.Validators;

namespace Rentify.WebServer.Models
{
    [Validator(typeof(UpdateSiteThemeBindingModelValidator))]
    public class UpdateSiteThemeBindingModel
    {
        public string UniqueId { get; set; }
        public string ThemeId { get; set; }
    }
}