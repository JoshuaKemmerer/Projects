using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Plasty.Models
{
    public class Major
    {
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        [Required]
        [ForeignKey("Term")]
        public int TermApplicable { get; set; }
        [ForeignKey("TermId")]
        public Term Term { get; set; }

        public virtual List<DegreeRequirement> Requirements { get; set; }
        public virtual List<Enrollment> Enrollments { get; set; } 
    }
}