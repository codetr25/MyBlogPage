using MyBlogPage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlogPage.Business
{
    public class UserManager : ManagerBase<User>
    {
        public User UserInfo(string email)
        {
            string sql = "select * from users where Email=@email";

            return Find(sql, new { email });
        }

        internal User UserInfo(string email, string password)
        {
            string sql = "select * from users where Email=@email and Password=@password";

            return Find(sql, new { email, password });
        }
    }
}