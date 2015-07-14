namespace Twocents
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Edit
    {
        public int EditId { get; set; }

        public int CommentId { get; set; }

        public string Changes { get; set; }

        [StringLength(50)]
        public string Reason { get; set; }

        public DateTime Date { get; set; }

        public virtual Comment Comment { get; set; }
    }
}
