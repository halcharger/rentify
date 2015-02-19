namespace Rentify.Sites.Infrastructure.Themes
{
    public interface ITheme
    {
        string LayoutFile { get; }
        string OverviewPartialFile { get; }
        string GalleryPartialFile { get; }
    }
}