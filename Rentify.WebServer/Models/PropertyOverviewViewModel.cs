namespace Rentify.WebServer.Models
{
    public class PropertyOverviewViewModel
    {
        public string Name { get; set; }
        public string MainTitle { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public int Sleeps { get; set; }
        public int SquareMeters { get; set; }

        public int RoomsBedrooms { get; set; }
        public int RoomsLounges { get; set; }
        public int RoomsDiningRooms { get; set; }
        public int RoomsKitchens { get; set; }
        public int RoomsBathrooms { get; set; }
        public int RoomsToilets { get; set; }
        public int RoomsShowers { get; set; }
        public int RoomsSculleries { get; set; }
        public int RoomsStudies { get; set; }
        public int RoomsReceptionRooms { get; set; }
        public int RoomsPantries { get; set; }
        public int RoomsEntertainmentRooms { get; set; }
        public string RoomsCustomRoomsHtml { get; set; }

        public bool FactsAccessible247 { get; set; }
        public bool FactsPetsWelcome { get; set; }
        public bool FactsSecureOnsiteParking { get; set; }
        public bool FactsHouseKeeper { get; set; }
        public bool FactsSmokingAllowed { get; set; }
        public string FactsCustomFactsHtml { get; set; }

        public bool AmenitiesDishwasher { get; set; }
        public bool AmenitiesStove { get; set; }
        public bool AmenitiesMicrowaveOven { get; set; }
        public bool AmenitiesDSTV { get; set; }
        public bool AmenitiesTumbleDryer { get; set; }
        public string AmenitiesCustomAmenitiesHtml { get; set; } 
         
    }
}