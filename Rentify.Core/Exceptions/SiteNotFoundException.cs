using System;

namespace Rentify.Core.Exceptions
{
    public class SiteNotFoundException : Exception
    {
        public SiteNotFoundException(Uri uri) : base(string.Format("A rentify site couyld not be found for the url: {0}", uri))
        {
            
        }
    }
}