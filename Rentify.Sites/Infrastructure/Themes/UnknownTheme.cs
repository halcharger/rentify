namespace Rentify.Sites.Infrastructure.Themes
{
    public class UnknownTheme : ITheme
    {
        public string LayoutFile
        {
            get { return "~/Views/Shared/_Layout.cshtml"; }
        }

        public string OverviewPartialFile
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}