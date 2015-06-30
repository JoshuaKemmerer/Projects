using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    public class CourseTaken
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public ApplicationUser ApplicationUserId { get; set; }

        [Required]
        [ForeignKey("CourseAvail")]
        public int CourseId { get; set; }
        [ForeignKey("CourseAvailId")]
        public CourseAvail CourseAvail { get; set; }

    }
}