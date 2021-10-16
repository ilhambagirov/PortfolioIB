namespace Portfolio.Domain.Models.Entities
{
    public class Skills : BaseEntity
    {
        public string SkillType { get; set; }
        public string SkillName { get; set; }
        public string SkillPercentage { get; set; }
        public string SkillDescription { get; set; }
        public bool IsHardSkill { get; set; }
    }
}
