using Portfolio.Domain.Models.Entities.Membership;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Domain.Models.Entities
{
    public class Blog : BaseEntity
    {
        [Required]
        public string ImagePath { get; set; }
        public virtual PortfolioUser CreatedByUser { get; set; }
        [Required]
        public string BlogName{ get; set; }
        public string Description { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string BlogType { get; set; }
    }
}
