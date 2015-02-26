using System.Web.Mvc;

namespace Rentify.WebServer.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return new FilePathResult("~/index.html", "text/html");
        }
    }
}