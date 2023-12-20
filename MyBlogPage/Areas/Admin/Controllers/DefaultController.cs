using MyBlogPage.Common;
using System.Web.Mvc;

namespace MyBlogPage.Areas.Admin.Controllers
{
    [AuthorizeControl(Roles="Admin,Root")]
    public class DefaultController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}