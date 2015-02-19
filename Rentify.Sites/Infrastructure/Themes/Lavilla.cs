namespace Rentify.Sites.Infrastructure.Themes
{
    public class Lavilla : ITheme
    {
        public const string ThemeId = "lavilla";

        public string LayoutFile
        {
            get { return "~/Views/Shared/Themes/lavilla/_Layout.cshtml"; }
        }

        public string OverviewPartialFile
        {
            get { return "~/Views/Shared/Themes/lavilla/overview.cshtml"; }
        }

        public string GalleryPartialFile
        {
            get { return "~/Views/Shared/Themes/lavilla/gallery.cshtml"; }
        }
    }
}