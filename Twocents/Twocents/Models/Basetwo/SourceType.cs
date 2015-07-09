namespace Twocents
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
