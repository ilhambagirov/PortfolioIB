using Portfolio.Domain.Models.Entities;
using System.Collections.Generic;

namespace Portfolio.Domain.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<Skills> Skills { get; set; }
        public List<Service> Services { get; set; }
        public PersonalDetails PersonalDetails { get; set; }
    }
}
