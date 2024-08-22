using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioSiteApi.Models
{
    public class Skill
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }
       
        public ICollection<SkillProject> SkillProjects { get; set; }
    }
}
