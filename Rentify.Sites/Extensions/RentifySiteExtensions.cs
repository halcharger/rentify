using Rentify.Core.Domain;
using Rentify.Sites.Infrastructure.Themes;

namespace Rentify.Sites.Extensions
{
    public static class RentifySiteExtensions
    {
        public static ITheme GetTheme(this RentifySite site)
        {
            return ThemeFactory.CreateTheme(site.ThemeId);
        }
    }
}