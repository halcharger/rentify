using System.Web;
using Rentify.Core.Domain;

namespace Rentify.Sites.Infrastructure.Providers
{
    public interface IRentifySiteProvider
    {
        RentifySite RentifySite { get; set; }
    }

    public class SessionRentifySiteProvider : IRentifySiteProvider
    {
        public RentifySite RentifySite
        {
            get { return HttpContext.Current.Session["RentifySite"] as RentifySite; }
            set { HttpContext.Current.Session["RentifySite"] = value; }
        }
    }
}