using PortfolioSiteApi.Models;

namespace PortfolioSiteApi.DTOs
{
    public class ProjectResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Media> MediaList { get; set; }
        public List<string> SkillNames { get; set; }
    }
}