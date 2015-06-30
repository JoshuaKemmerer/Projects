using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PlanofStudy.Models;

namespace PlanOfStudy.DAL
{
    public class PlanOfStudyDbContext : DbContext
    {

        public DbSet<CourseAvail> CoursesAvail { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseTaken> CoursesTaken { get; set; }
        public DbSet<DegreeRequirement> DegreeRequirements { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
    }
}