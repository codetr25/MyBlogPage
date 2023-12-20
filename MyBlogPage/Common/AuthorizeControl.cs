using MyBlogPage.Business;
using MyBlogPage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogPage.Common
{
    public class AuthorizeControl:AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            HttpContext context = HttpContext.Current;
            User user = CurrentSession.User;
            if (user == null)
            {
                //No session, but if there is a cookie, create a session

                if (context.Request.Cookies["user"]!=null)
                {
                    string email = context.Request.Cookies["user"].Value;

                    UserManager userManager = new UserManager();
                    User userInfo = userManager.UserInfo(email);
                    if (userInfo != null)
                    {
                        return false;
                    }
                    CurrentSession.Set(userInfo);
                }
                else
                {
                    //if there is no session and no cookie, redirect to logout.

                    httpContext.Response.Redirect("/Admin/Login/Logout");
                    return false;
                }

            }

            //Check the roles coming from the controller and allow
            //the user to proceed if they have this role
            var roles = Roles.Split(',');

            foreach (var role in roles)
            {
                if(user.Roles.Contains(role))
                {
                    return true;
                }
            }

            return base.AuthorizeCore(httpContext);
        }
    }
}