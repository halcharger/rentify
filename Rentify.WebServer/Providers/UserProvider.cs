using System.Web;
using Microsoft.AspNet.Identity;

namespace Rentify.WebServer.Providers
{
    public interface IUserProvider
    {
        string Username { get; }
        string UserId { get; }
    }

    public class UserProvider : IUserProvider
    {
        public string Username { get { return HttpContext.Current.User.Identity.Name; } }
        public string UserId { get { return HttpContext.Current.User.Identity.GetUserId(); } }
    }
}