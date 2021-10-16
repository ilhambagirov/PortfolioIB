using Portfolio.Domain.Models.Entities;
using System.Collections.Generic;

namespace Portfolio.Domain.Models.ViewModels
{
    public class ResumeViewModel
    {
        public List<Experience> Experience { get; set; }
        public List<Education> Education { get; set; }
        public Bio Bio { get; set; }
        public List<Skills> Skills { get; set; }
    }
}
