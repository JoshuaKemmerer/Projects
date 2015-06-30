using System;
using System.Data.Entity;
using Test.Models;

namespace Test.DAL.Model
{
    public class SiteDbContext : DbContext
    {
        public IDbSet<Course> Courses { get; set; }
        public IDbSet<CourseAvail> CoursesAvail { get; set; }
        public IDbSet<CourseTaken> CoursesTaken { get; set; } 
        public IDbSet<DegreeRequirement> DegreeRequirements { get;set; } 
        public IDbSet<Enrollment> Enrollments { get; set; } 
        public IDbSet<Major> Majors { get;set; } 
        public IDbSet<Term> Terms { get;set; } 

        /// <summary>
        /// The constructor, we provide the connectionstring to be used to it's base class.
        /// </summary>
        public SiteDbContext()
            : base("DefaultConnection")
        {
        }

        static SiteDbContext()
        {
            try
            {
                Database.SetInitializer<SiteDbContext>(new DropCreateDatabaseIfModelChanges<SiteDbContext>());
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This method prevents the plurarization of table names
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
        }
    }
}