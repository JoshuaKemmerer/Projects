namespace Twocents
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vote
    {
        public int VoteId { get; set; }

        public int VoteTypeId { get; set; }

        public int UserId { get; set; }

        public int CommentId { get; set; }

        public virtual Comment Comment { get; set; }

        public virtual VoteType VoteType { get; set; }
    }
}
