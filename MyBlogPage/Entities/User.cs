using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlogPage.Entities
{
    [Table("users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Roles { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public int Banned { get; set; }
    }
}