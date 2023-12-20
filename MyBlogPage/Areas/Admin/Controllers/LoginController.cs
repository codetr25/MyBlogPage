using MyBlogPage.Areas.Admin.ViewModel;
using MyBlogPage.Business;
using MyBlogPage.Common;
using MyBlogPage.Entities;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyBlogPage.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            if (string.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                return View(loginViewModel);
            }

            return View(loginViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserManager userManager = new UserManager();
                User userInfo = userManager.UserInfo(model.Email, model.Password);

                if (userInfo != null)
                {
                    if (userInfo.Banned == 1)//is banned
                    {
                        ModelState.AddModelError("", "This account has been banned");
                        return View(model);
                    }

                    userInfo.LastLoginDate = DateTime.Now;
                    userManager.Update(userInfo);

                    //The user has been authenticated, they can now navigate through the pages.
                    FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);

                    //Let's create a session class to track the users session using Session
                    CurrentSession.Set(userInfo);

                    //Lets write to a cookie to continue the session when the session expires.
                    HttpCookie httpCookie = new HttpCookie("user");
                    httpCookie.Value = model.Email;
                    httpCookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(httpCookie);

                    return RedirectToAction("Index", "Default");
                }
                else
                {
                    ModelState.AddModelError("", "The email or password is incorrect!");
                    return View(model);
                }
            }

            return View(model);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            CurrentSession.Remove();

            HttpCookie httpCookie = new HttpCookie("user");
            httpCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(httpCookie);

            return RedirectToAction("Index", "Login");
        }
    }
}