namespace Twocents
{
    using System.ComponentModel.DataAnnotations;

    public partial class Website
    {
        public int WebsiteId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
