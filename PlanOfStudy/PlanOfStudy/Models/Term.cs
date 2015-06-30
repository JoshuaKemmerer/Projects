using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlanofStudy.Models
{
    public class Term
    {
        public int Id { get; set; }

        [Required]
        [StringLength(16)]
        public string Name { get; set; }// at Drexel, this would be something like 'Fall 2015', 'Winter 2015'

        [Required]
        [StringLength(16)]
        public string Identity { get; set; }// a Term might have an alternate alias that is known to mostly advisors, such as 120125?

        public virtual List<DegreeRequirement> DegreeRequirements { get; set; }
        public virtual List<Enrollment> Enrollments { get; set; }
    }
}