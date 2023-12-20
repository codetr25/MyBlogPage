using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlogPage.Entities
{
    [Table("sitepages")]
    public class SitePage
    {
        [Key]
        public int Id { get; set; }
        public int KatId { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
        public string TitleUrl { get; set; }
        public string PageContent { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}