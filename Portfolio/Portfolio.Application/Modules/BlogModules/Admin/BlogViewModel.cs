using Microsoft.AspNetCore.Http;

namespace Portfolio.Application.Modules.BlogModules.Admin
{
    public class BlogViewModel
    {
        public int? Id { get; set; }
        public string BlogName { get; set; }
        public string BlogType { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
        public string fileTemp { get; set; }
    }
}
