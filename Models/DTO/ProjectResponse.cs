using PortfolioSiteApi.Models.Entity;

namespace PortfolioSiteApi.Models.DTO
{
    public class ProjectResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Company {get; set;}
        public string Client { get; set; }        
        public string StartDate { get; set; }
         public string EndDate { get; set; }   
        public List<Media> MediaList { get; set; }
        public List<string> SkillNames { get; set; }
    }
}