namespace Portfolio.Domain.Models.Entities
{
    public class Icon : BaseEntity
    {
        public string IconLink { get; set; }
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
    }
}
