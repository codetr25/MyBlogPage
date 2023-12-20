using MyBlogPage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlogPage.Business
{
    public class SitePageManager:ManagerBase<SitePage>
    {
        public IEnumerable<SitePage> List()
        {
            string sql = "select * from sitepages";

            return Query(sql);
        }
    }
}