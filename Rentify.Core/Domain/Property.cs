namespace Rentify.Core.Domain
{
    public class Property
    {
        public Property()
        {
            Overview = new PropertyOverview();
            Location = new Location();
            Gallery = new Gallery();
        }

        public PropertyOverview Overview { get; set; }
        public Location Location { get; set; }
        public Gallery Gallery { get; set; }
    }
}