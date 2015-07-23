namespace BaseTwoAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        public Comment()
        {
            CommentRatings = new HashSet<CommentRating>();
            Edits = new HashSet<Edit>();
            Votes = new HashSet<Vote>();
        }

        public int CommentId { get; set; }

        public int AccessTypeId { get; set; }

        public int? ParentId { get; set; }

        public int SourceId { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime PostDate { get; set; }

        public int? FlagId { get; set; }

        public int WebpageId { get; set; }

        public virtual AccessType AccessType { get; set; }

        public virtual CommentFlag CommentFlag { get; set; }

        public virtual ICollection<CommentRating> CommentRatings { get; set; }

        public virtual CommentSource CommentSource { get; set; }

        public virtual Webpage Webpage { get; set; }

        public virtual ICollection<Edit> Edits { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
