using System.ComponentModel.DataAnnotations;

namespace PortfolioSiteApi.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Client { get; set; }
        public string Description {get;set;}
        public string StartDate { get; set; }
         public string EndDate { get; set; }        
    }
}
