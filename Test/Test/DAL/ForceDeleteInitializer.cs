using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Test.DAL.Model;

namespace Test.DAL
{
    public class ForceDeleteInitializer : IDatabaseInitializer<SiteDbContext>
    {
        private readonly IDatabaseInitializer<SiteDbContext> _initializer = new DropCreateDatabaseIfModelChanges<SiteDbContext>();

        public ForceDeleteInitializer()
        {
            //_initializer = new ForceDeleteInitializer();
        }

        public void InitializeDatabase(SiteDbContext context)
        {
            //This command is added to prevent open connections. See http://stackoverflow.com/questions/5288996/database-in-use-error-with-entity-framework-4-code-first
            context.Database.ExecuteSqlCommand("ALTER DATABASE Test SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
            _initializer.InitializeDatabase(context);
        }
    }
}