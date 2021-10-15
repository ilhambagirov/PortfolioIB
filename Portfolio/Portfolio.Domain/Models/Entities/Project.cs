using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Models.Entities
{
    public class Project : BaseEntity
    {
        [Required]
        public string ImagePath { get; set; }
        [Required]
        public string ProjectName { get; set; }
        public string Description { get; set; }
        [Required]
        public string ProjectType { get; set; }
        [Required]
        public string Link { get; set; }
    }
}
