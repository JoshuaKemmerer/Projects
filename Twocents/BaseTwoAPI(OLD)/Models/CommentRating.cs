namespace BaseTwoAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CommentRating
    {
        public int CommentRatingId { get; set; }

        public int Rating { get; set; }

        public int CommentId { get; set; }

        public int VoteTypeId { get; set; }

        public virtual Comment Comment { get; set; }

        public virtual VoteType VoteType { get; set; }
    }
}
