using Plasty.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Plasty.DAL
{
    public class SiteContext : DbContext
    {

        public SiteContext()
            : base("PlastyContext") // 'PlastyContext' is the connection string for the database
        {
        }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<CoursesAvail> CoursesAvail { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<CoursesTaken> CoursesTaken { get; set; }
        public DbSet<DegreeRequirements> DegreeRequirements { get; set; }
        public DbSet<Majors> Majors { get; set; }
        public DbSet<Terms> Terms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}