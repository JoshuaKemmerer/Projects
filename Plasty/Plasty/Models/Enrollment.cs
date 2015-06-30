using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Plasty.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required]
        [ForeignKey("Major")]
        public int MajorId { get; set; }
        [ForeignKey("MajorId")]
        public Major Major { get; set; }

        [Required]
        [ForeignKey("Term")]
        public int TermId { get; set; }
        [ForeignKey("TermId")]
        public Term Term { get; set; }
    }
}