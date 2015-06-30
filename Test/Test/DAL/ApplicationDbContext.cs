using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Test.Models;

namespace Test.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public new DbSet<ApplicationUser> Users { get; set; }
        public DbSet<CourseAvail> CoursesAvail { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseTaken> CoursesTaken { get; set; }
        public DbSet<DegreeRequirement> DegreeRequirements { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
    }
}