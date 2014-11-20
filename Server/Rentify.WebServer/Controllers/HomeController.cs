using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

namespace Rentify.WebServer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new HomeModel();

            var webApiAssembly = Assembly.GetAssembly(typeof (HomeController));
            model.AssemblyVersions.Add(new KeyValuePair<string, string>(webApiAssembly.FullName, webApiAssembly.GetName().Version.ToString()));

            foreach (var item in webApiAssembly.GetReferencedAssemblies())
            {
                model.AssemblyVersions.Add(new KeyValuePair<string, string>(item.FullName, item.Version.ToString()));
            }

            return View(model);
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
