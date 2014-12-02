using System;

namespace Rentify.Core.Extensions
{
    public static class UriExtensions
    {
        public const string RentifyTopLevelDomain = "adaptivesystems";//adaptivesystems.info

        public static string GetRentifyUniqueSiteId(this Uri uri)
        {
            if (uri.HostNameType == UriHostNameType.Dns)
            {

                var host = uri.Host.ToLower();

                var nodes = host.Split('.');
                var startNode = 0;
                if(nodes[0] == "www") startNode = 1;

                if (nodes[startNode] == RentifyTopLevelDomain)
                    return string.Empty;

                return nodes[startNode];

            }

            return string.Empty; 
        }
    }
}