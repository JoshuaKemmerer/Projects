namespace Twocents
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FlagType
    {
        public FlagType()
        {
            CommentFlags = new HashSet<CommentFlag>();
        }

        public int FlagTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public int CreatorId { get; set; }

        public virtual ICollection<CommentFlag> CommentFlags { get; set; }
    }
}
