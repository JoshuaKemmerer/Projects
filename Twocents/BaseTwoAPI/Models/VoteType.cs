namespace BaseTwoAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VoteType
    {
        public VoteType()
        {
            CommentRatings = new HashSet<CommentRating>();
            Votes = new HashSet<Vote>();
        }

        public int VoteTypeId { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        public virtual ICollection<CommentRating> CommentRatings { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
