namespace BaseTwoAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AccessType
    {
        public AccessType()
        {
            Comments = new HashSet<Comment>();
        }

        public int AccessTypeId { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
