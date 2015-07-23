namespace BaseTwoAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CommentSource
    {
        public CommentSource()
        {
            Comments = new HashSet<Comment>();
        }

        public int CommentSourceId { get; set; }

        public int TypeId { get; set; }

        public int SourceId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual SourceType SourceType { get; set; }
    }
}
