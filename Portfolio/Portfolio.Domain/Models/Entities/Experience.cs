using System.ComponentModel.DataAnnotations;

namespace Portfolio.Domain.Models.Entities
{
    public class Experience : BaseEntity
    {
        [Required]
        public string TimeInterval { get; set; }
        [Required]
        public string Occupation { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }



    }
}
