using System.ComponentModel.DataAnnotations;

namespace PortfolioSiteApi.Models
{
    public class JobProposal
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Email { get; set; }
        public int RecruiterName { get; set; }
        public string Title {get;set;}
        public string Description { get; set; }
        public string SeniorityLevel { get; set; }
        public int Requirements { get; set; }
        public int Salary { get; set; }
        public int Benefits { get; set; }     

    }
}
