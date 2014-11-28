using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

namespace Rentify.WebServer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return new FilePathResult("index.html", "text/html");
        }

        public class HomeModel
        {
            public HomeModel()
            {
                AssemblyVersions = new List<KeyValuePair<string, string>>();
            }

            public List<KeyValuePair<string, string>> AssemblyVersions { get; set; }
        }
    }
}
