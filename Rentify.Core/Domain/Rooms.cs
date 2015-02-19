namespace Rentify.Core.Domain
{
    public class Rooms
    {
        public int Bedrooms { get; set; }
        public int Lounges { get; set; }
        public int DiningRooms { get; set; }
        public int Kitchens { get; set; }
        public int Bathrooms { get; set; }
        public int Toilets { get; set; }
        public int Showers { get; set; }
        public int Sculleries { get; set; }
        public int Studies { get; set; }
        public int ReceptionRooms { get; set; }
        public int Pantries { get; set; }
        public int EntertainmentRooms { get; set; }

        public string CustomRoomsHtml { get; set; }
    }
}