using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    public class CourseAvail
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        [Required]
        [ForeignKey("Term")]
        public int TermId { get; set; }
        [ForeignKey("TermId")]
        public Term Term { get; set; }

        [Required]
        [StringLength(4)]
        [Display(Name = "Sec")]
        public string Section { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "CRN")]
        public string Crn { get; set; }

        [Required]
        [StringLength(64)]
        [Display(Name = "Instr Type")]
        public string InstructionType { get; set; }

        [Required]
        [StringLength(64)]
        [Display(Name = "Instr Method")]
        public string InstructionMethod { get; set; }

        [Required]
        [StringLength(4)]
        public string Days { get; set; }

        [Required]
        [StringLength(16)]
        public string Time { get; set; }

        [Required]
        [StringLength(64)]
        public string Instructor { get; set; }
    }
}