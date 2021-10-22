using Portfolio.Domain.Models.Entities.Membership;

namespace Portfolio.Domain.Models.Entities
{
    public class PersonalDetails : BaseEntity
    {
        public int PortfolioUserId { get; set; }
        public virtual PortfolioUser PortfolioUser { get; set; }
        public string Location { get; set; }
        public string Degree { get; set; }
        public string Phone { get; set; }
        public string Age { get; set; }
        public string Experience { get; set; }
        public string CareerLevel { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string Occupation { get; set; }
        public string About { get; set; }
    }
}
