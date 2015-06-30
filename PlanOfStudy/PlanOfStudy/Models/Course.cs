using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlanofStudy.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [StringLength(5)]
        public string SubjectCode { get; set; }

        [Required]
        [StringLength(5)]
        public string CourseNumber { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "Course Title")]
        public string Title { get; set; }

        public virtual ICollection<CourseAvail> CoursesAvail { get; set; }
    }
}

/*public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<CoursesAvail> CoursesAvail { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<CoursesTaken> CoursesTaken { get; set; }
        public DbSet<DegreeRequirements> DegreeRequirements { get; set; }
        public DbSet<Majors> Majors { get; set; }
        public DbSet<Terms> Terms { get; set; } 
    */