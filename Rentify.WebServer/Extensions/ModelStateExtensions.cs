using System.Web.Http.ModelBinding;

namespace Rentify.WebServer.Extensions
{
    public static class ModelStateExtensions
    {
        public static bool NotValid(this ModelStateDictionary state)
        {
            return !state.IsValid;
        }
    }
}