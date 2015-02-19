namespace Rentify.Sites.Extensions
{
    public static class BooleanExtensions
    {
        public static string FontAwesomeCheckIcon(this bool value)
        {
            return value ? "fa-check-square-o" : "fa-square-o";
        }
    }
}