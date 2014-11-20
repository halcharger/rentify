using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace Rentify.WebServer.Controllers
{
    public class RentifyVersionController : ApiController
    {
        [HttpGet]
        [Route("api/version")]
        public IEnumerable<string> GetAssemblyVersions()
        {
            var versions = new List<string>();
            var webApiAssembly = Assembly.GetAssembly(typeof(RentifyVersionController));
            versions.Add(string.Format("{0} [{1}]", webApiAssembly.FullName, webApiAssembly.GetName().Version));
            versions.AddRange(webApiAssembly.GetReferencedAssemblies().Select(item => string.Format("{0} [{1}]", item.FullName, item.Version)));

            return versions;
        }
    }
}