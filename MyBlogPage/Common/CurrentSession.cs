using MyBlogPage.Business;
using MyBlogPage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlogPage.Common
{
    public static class CurrentSession
    {
        public static string sessionKey = "user";
       
        public static User User=>Get<User>();
        public static void Set<T>(T userControl)
        {
            HttpContext context = HttpContext.Current;
            context.Session[sessionKey] = userControl;
            context.Session.Timeout = 1440;//one day
        }
        private static T Get<T>()
        {
            HttpContext context = HttpContext.Current;
            string email = "";
            if (context.Session[sessionKey]!=null)
                return (T)context.Session[sessionKey];
            else if (!string.IsNullOrEmpty(context.User.Identity.Name))
            {
                //if the value for Identity.Name exits. create the session again
                email = context.User.Identity.Name;
            }
            else if (context.Request[sessionKey] != null)
            {
                //if there is a cookie value, retrieve user information and create a session
                email = context.Request.Cookies[sessionKey].Value;
            }

            UserManager userManager = new UserManager();
            User userControl = userManager.UserInfo(email);
            if (userControl != null)
            {
                Set(userControl);
            }
            else
            {
                //if there is no session and no cookie, redirect to logout
                context.Response.Redirect("/Admin/Login/Logout");
            }
            return (T)context.Session[sessionKey];
        }

        public static void Remove()
        {
            HttpContext context = HttpContext.Current;
            if (context.Session[sessionKey] != null)
            {
                context.Session.Remove(sessionKey);
            }
            Set<User>(null);
        }

        public static void Clear()
        {
            HttpContext context = HttpContext.Current;
            context.Session.Clear();
        }
    }
}