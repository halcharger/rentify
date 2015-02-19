namespace Rentify.Core.Domain
{
    public class PropertyOverview
    {
        public PropertyOverview()
        {
            Rooms = new Rooms();
            Facts = new PropertyFacts();
            Amenities = new PropertyAmenities();
        }

        public string Name { get; set; }
        public string MainTitle { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public int Sleeps { get; set; }
        public int SquareMeters { get; set; }
        public Rooms Rooms { get; set; }
        public PropertyFacts Facts { get; set; }
        public PropertyAmenities Amenities { get; set; }
    }
}