using MyBlogPage.Business;
using MyBlogPage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogPage.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            SitePageManager sitePageManager= new SitePageManager();
            IEnumerable<SitePage> pages = sitePageManager.List();

            return View(pages);
        }
    }
}