using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using System.Linq;
using System.Web;

namespace MyBlogPage.Entities
{
    [Table("categories")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}