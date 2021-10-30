using Portfolio.Domain.Models.Entities;
using System.Collections.Generic;

namespace Portfolio.Domain.Models.ViewModels
{
    public class BlogPostSingleViewModel
    {
        public Blog Blog { get; set; }
        public List<BlogComment> Comments { get; set; }
    }
}
