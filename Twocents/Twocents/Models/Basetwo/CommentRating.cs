namespace Twocents
{

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
