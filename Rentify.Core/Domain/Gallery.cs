using System;
using System.Collections.Generic;

namespace Rentify.Core.Domain
{
    public class Gallery
    {
        public static string GetGalleryImageUrl(string storageAccount, string container, string imageName)
        {
            return string.Format("https://{0}.blob.core.windows.net/{1}/{2}", storageAccount, container, imageName);
        }

        public Gallery()
        {
            Id = Guid.NewGuid().ToString();
            ImageUrls = new List<string>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> ImageUrls { get; set; }
    }
}