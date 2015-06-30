using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Plasty.Models;

namespace Plasty.DAL
{
    public class PlastyDbContext : DbContext
    {
        public PlastyDbContext()
            : base("name=DefaultConnection")
        {
        }
        static PlastyDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            //Database.SetInitializer<PlastyDbContext>(new PlastyDBInitializer());
            Database.SetInitializer<PlastyDbContext>(new DropCreateDatabaseIfModelChanges<PlastyDbContext>());
        }

        public static PlastyDbContext Create()
        {
            return new PlastyDbContext();
        }

        public DbSet<ApplicationUser> Users { get; set; }

        public DbSet<CourseAvail> CoursesAvail { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseTaken> CoursesTaken { get; set; }

        public DbSet<DegreeRequirement> DegreeRequirements { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<Major> Majors { get; set; }

        public DbSet<Term> Terms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}