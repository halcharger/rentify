using System.Collections.Generic;

namespace Rentify.Sites.Infrastructure.Themes
{
    public class ThemeFactory
    {
        private static IDictionary<string, ITheme> Themes = new Dictionary<string, ITheme>
        {
            {Lavilla.ThemeId, new Lavilla()}
        };

        public static ITheme CreateTheme(string themeId)
        {
            if (Themes.ContainsKey(themeId))
                return Themes[themeId];

            return new UnknownTheme();
        }
    }
}