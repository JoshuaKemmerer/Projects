namespace BaseTwoAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CommentFlag
    {
        public CommentFlag()
        {
            Comments = new HashSet<Comment>();
        }

        public int CommentFlagId { get; set; }

        public int FlagTypeId { get; set; }

        public int CreatorId { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual FlagType FlagType { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
