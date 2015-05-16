using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Plasty.Models;

namespace Plasty.DAL
{
    public class SiteInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SiteContext>
    {
        protected override void Seed(SiteContext context)
        {
            var passwordHash = new PasswordHasher();
            var password = passwordHash.HashPassword("password");
            //context.Users.AddOrUpdate(u => u.UserName,
            //    new ApplicationUser
            //    {
            //        UserName = "joshkemm",
            //        PasswordHash = password,
            //        Email = "joshkemm@gmail.com",
            //        maj
            //    });
        }
    }
}