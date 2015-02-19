using System.Collections.Generic;
using System.Linq;
using Rentify.Core.Domain;
using Rentify.Sites.Models;

namespace Rentify.Sites.Extensions
{
    public static class PropertyOverviewExtensions
    {
        public static List<IntItemViewModel> GetRoomsViewModels(this Rooms rooms)
        {
            var roomViewModels = new List<IntItemViewModel>
            {
                new IntItemViewModel("Bedrooms", rooms.Bedrooms),
                new IntItemViewModel("Lounges", rooms.Lounges),
                new IntItemViewModel("Dining Rooms", rooms.DiningRooms),
                new IntItemViewModel("Kitchens", rooms.Kitchens),
                new IntItemViewModel("Bathrooms", rooms.Bathrooms),
                new IntItemViewModel("Toilets", rooms.Toilets),
                new IntItemViewModel("Showers", rooms.Showers),
                new IntItemViewModel("Sculleries", rooms.Sculleries),
                new IntItemViewModel("Studies", rooms.Studies),
                new IntItemViewModel("Reception Rooms", rooms.ReceptionRooms),
                new IntItemViewModel("Pantries", rooms.Pantries),
                new IntItemViewModel("Entertainment Rooms", rooms.EntertainmentRooms)
            };

            return roomViewModels.Where(r => r.Value > 0).ToList();
        }

        public static List<BoolItemViewModel> GetFactsViewModels(this PropertyFacts facts)
        {
            return new List<BoolItemViewModel>
            {
                new BoolItemViewModel("Accessible 24/7", facts.Accessible247),
                new BoolItemViewModel("Pets Welcome", facts.PetsWelcome),
                new BoolItemViewModel("Secure onsite parking", facts.SecureOnsiteParking),
                new BoolItemViewModel("House keeper", facts.HouseKeeper),
                new BoolItemViewModel("Smoking allowed", facts.SmokingAllowed),
            };
        }

        public static List<BoolItemViewModel> GetAmenitiesViewModels(this PropertyAmenities amenities)
        {
            return new List<BoolItemViewModel>
            {
                new BoolItemViewModel("Dishwasher", amenities.Dishwasher),
                new BoolItemViewModel("Stove", amenities.Stove),
                new BoolItemViewModel("Microwave", amenities.MicrowaveOven),
                new BoolItemViewModel("DSTV", amenities.DSTV),
                new BoolItemViewModel("Tumble Dryer", amenities.TumbleDryer),
            };
        }
    }
}