using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Rentify.Sites.Extensions;
using Rentify.Sites.Infrastructure.Providers;
using Rentify.Sites.Models;

namespace Rentify.Sites.Controllers
{
    public class HomeController : Controller
    {
        private IRentifySiteProvider siteProvider;

        public HomeController(IRentifySiteProvider siteProvider)
        {
            this.siteProvider = siteProvider;
        }

        [Route("")]
        public ActionResult Index()
        {
            var site = siteProvider.RentifySite;
            ViewBag.MainTitle = site.Property.Overview.MainTitle;
            ViewBag.SubTitle = site.Property.Overview.SubTitle;

            return View();
        }

        [Route("overview")]
        public ActionResult Overview()
        {
            var theme = siteProvider.RentifySite.GetTheme();
            var overview = siteProvider.RentifySite.Property.Overview;
            return View(new OverviewViewModel
            {
                OverviewPartialPath = theme.OverviewPartialFile,
                MainTitle = overview.MainTitle,
                SubTitle = overview.SubTitle,
                DescriptionHtml = overview.Description,
                Rooms = overview.Rooms.GetRoomsViewModels(),
                CustomRoomsHtml = overview.Rooms.CustomRoomsHtml,
                Facts = overview.Facts.GetFactsViewModels(),
                CustomFactsHtml = overview.Facts.CustomFactsHtml,
                Amenities = overview.Amenities.GetAmenitiesViewModels(),
                CustomAmenitiesHtml = overview.Amenities.CustomAmenitiesHtml
            });
        }

        [Route("gallery")]
        public ActionResult Gallery()
        {
            var theme = siteProvider.RentifySite.GetTheme();
            var gallery = siteProvider.RentifySite.Property.Gallery;
            var viewmodel = new GalleryViewModel
            {
                GalleryPartialPath = theme.GalleryPartialFile,
                Name = gallery.Name,
                Description = gallery.Description,
                ImageUrls = gallery.Images.Select(i => i.GetImageResizerUrl()).ToArray()
            };
            return View(viewmodel);
        }
    }
}