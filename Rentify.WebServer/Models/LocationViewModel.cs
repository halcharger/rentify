namespace Rentify.WebServer.Models
{
    public class LocationViewModel
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }

        public string DirectionsHtml { get; set; }
        public string CustomDirectionsPdfUrl { get; set; }
        public string CustomMapImageUrl { get; set; }
        public bool UseCustomMapIamge { get; set; }
        public bool UseCustomDirectionsPdf { get; set; }

    }
}