using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioSiteApi.Models.Entity
{
    public class SkillProject
    {
        [Column("project_id")]
        public int ProjectId { get; set; }

        [Column("skill_id")]
        public int SkillId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }

        [ForeignKey(nameof(SkillId))]
         public Skill Skill { get; set; }
    }
}
