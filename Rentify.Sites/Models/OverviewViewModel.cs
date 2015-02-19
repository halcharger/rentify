using System.Collections.Generic;

namespace Rentify.Sites.Models
{
    public class OverviewViewModel
    {
        public string OverviewPartialPath { get; set; }

        public string MainTitle { get; set; }
        public string SubTitle { get; set; }
        public string DescriptionHtml { get; set; }
        public int Sleeps { get; set; }
        public int SquareMeters { get; set; }

        public List<IntItemViewModel> Rooms { get; set; }
        public string CustomRoomsHtml { get; set; }
        public List<BoolItemViewModel> Facts { get; set; }
        public string CustomFactsHtml { get; set; }
        public List<BoolItemViewModel> Amenities { get; set; }
        public string CustomAmenitiesHtml { get; set; }
    }

    public class BoolItemViewModel
    {
        public BoolItemViewModel(string description, bool value)
        {
            Description = description;
            Value = value;
        }

        public string Description { get; set; }
        public bool Value { get; set; }
    }

    public class IntItemViewModel
    {
        public IntItemViewModel(string description, int value)
        {
            Description = description;
            Value = value;
        }

        public string Description { get; set; }
        public int Value { get; set; }
    }
}