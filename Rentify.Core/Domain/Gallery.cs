using System;
using System.Collections.Generic;

namespace Rentify.Core.Domain
{
    public class Gallery
    {
        public Gallery()
        {
            Id = Guid.NewGuid().ToString();
            Images = new List<AzureBlobImage>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<AzureBlobImage> Images { get; set; }
    }
}