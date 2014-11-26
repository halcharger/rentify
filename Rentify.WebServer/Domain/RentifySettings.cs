﻿using System.Collections.Generic;

namespace Rentify.WebServer.Domain
{
    public class RentifySettings
    {
        public RentifySettings()
        {
            Sites = new List<RentifySite>();
        }

        public List<RentifySite> Sites { get; set; }
    }
}