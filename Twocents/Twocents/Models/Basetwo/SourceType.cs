namespace Twocents
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class SourceType
    {
        public SourceType()
        {
            CommentSources = new HashSet<CommentSource>();
        }

        public int SourceTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<CommentSource> CommentSources { get; set; }
    }
}
