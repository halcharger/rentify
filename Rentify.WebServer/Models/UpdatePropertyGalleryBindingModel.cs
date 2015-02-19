using FluentValidation.Attributes;
using Rentify.WebServer.Validators;

namespace Rentify.WebServer.Models
{
    [Validator(typeof(UpdatePropertyGalleryBindingModelValidator))]
    public class UpdatePropertyGalleryBindingModel
    {
        public string UniqueId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}