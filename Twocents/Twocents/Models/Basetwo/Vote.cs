namespace Twocents
{

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
