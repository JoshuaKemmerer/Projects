using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    public class DegreeRequirement
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("Major")]
        public int MajorId { get; set; }
        [ForeignKey("MajorId")]
        public Major Major { get; set; }

        [Required]
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        [Required]
        [ForeignKey("Term")]
        public int EffectiveTermId { get; set; }
        [ForeignKey("TermId")]
        public Term Term { get; set; }
    }
}