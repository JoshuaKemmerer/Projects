namespace Twocents
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Edit
    {
        public int EditId { get; set; }

        public int CommentId { get; set; }

        [StringLength(1000)]
        public string Changes { get; set; }

        [StringLength(50)]
        public string Reason { get; set; }

        public DateTime Date { get; set; }

        public virtual Comment Comment { get; set; }
    }
}
