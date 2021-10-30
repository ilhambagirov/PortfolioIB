using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Domain.Models.Entities
{
    public class Blog : BaseEntity
    {
        [Required]
        public string ImagePath { get; set; }
        [Required]
        public string BlogName{ get; set; }
        public string Description { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string BlogType { get; set; }
        public virtual ICollection<BlogComment> BlogComments { get; set; }
    }
}
