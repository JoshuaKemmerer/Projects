using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Plasty.Models
{
    public class CoursesAvail
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public string TermId { get; set; }

        public string Crn { get; set; }

        public string InstructorType { get; set; }

        public string InstructorMethod { get; set; }

        public string Title { get; set; }

        public string Days { get; set; }

        public string Time { get; set; }

        public string Instructor { get; set; }
    }
}