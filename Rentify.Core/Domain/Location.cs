namespace Rentify.Core.Domain
{
    public class Location
    {
        public const string CustomDirectionsPdfUrlFormat = "https://{0}.blob.core.windows.net/{1}/customdirections.pdf";
        public const string CustomMapImageUrlFormat = "https://{0}.blob.core.windows.net/{1}/custommapimage";

        public string AddressLine1 { get; set; } 
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }

        public string DirectionsHtml { get; set; }
        public bool UseCustomMapIamge { get; set; }
        public bool UseCustomDirectionsPdf { get; set; }
    }
}