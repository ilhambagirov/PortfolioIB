using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Models.Entities
{
    public class BlogComment: BaseEntity
    {
        public string Comment { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
        public int? ParentId { get; set; }
        public virtual BlogComment  Parent { get; set; }
        public virtual ICollection<BlogComment> Children { get; set; }
    }
}
