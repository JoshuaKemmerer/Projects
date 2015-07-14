namespace Twocents
{
    using System.Collections.Generic;

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
