using System.ComponentModel.DataAnnotations;

namespace PortfolioSiteApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Password { get; set; }

        public string Contact { get; set; }
        public string SocialUrl { get; set; }
}
