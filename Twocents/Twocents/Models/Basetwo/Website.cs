namespace Twocents
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Website
    {
        public int WebsiteId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}