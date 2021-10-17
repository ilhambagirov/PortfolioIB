using System.Collections.Generic;

namespace Portfolio.Domain.Models.Entities
{
    public class Service : BaseEntity
    {
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Icon> Icons { get; set; }
    }
}
