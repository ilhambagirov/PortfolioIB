using Microsoft.AspNetCore.Http;

namespace Portfolio.Application.Modules.ProjectModules.Admin
{
    public class ExperienceViewModel
    {
        public int? Id { get; set; }
        public string TimeInterval { get; set; }
        public string CompanyName { get; set; }
        public string Occupation { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public IFormFile File { get; set; }
        public string fileTemp { get; set; }
    }
}
