using Microsoft.AspNetCore.Http;

namespace Portfolio.Application.Modules.ProjectModules.Admin
{
    public class ProjectViewModel
    {
        public int? Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectType { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
        public string fileTemp { get; set; }
    }
}
