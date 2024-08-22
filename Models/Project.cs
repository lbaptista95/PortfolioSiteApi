using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioSiteApi.Models
{
    public class Project
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("company")]
        public string Company {get; set;}

        [Column("client")]
        public int Client { get; set; }

        [Column("description")]
        public string Description {get;set;}
        
        [Column("start_date")]
        public string StartDate { get; set; }

        [Column("end_date")]
         public string EndDate { get; set; }     

        public ICollection<MediaProject> MediaProjects { get; set; }  

        public ICollection<SkillProject> SkillProjects { get; set; } 
    }
}
