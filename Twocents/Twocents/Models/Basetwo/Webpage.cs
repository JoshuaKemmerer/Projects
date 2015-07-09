namespace Twocents
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Webpage
    {
        public Webpage()
        {
            Comments = new HashSet<Comment>();
        }

        public int WebpageId { get; set; }

        [Required]
        [StringLength(2083)]
        public string url { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
