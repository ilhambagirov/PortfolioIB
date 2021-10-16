using System.ComponentModel.DataAnnotations;

namespace Portfolio.Domain.Models.Entities
{
    public class Education : BaseEntity
    {
        [Required]
        public string TimeInterval { get; set; }
        [Required]
        public string Occupation { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string LinkForDiploma { get; set; }
        public string Description { get; set; }
    }
}
