using System.ComponentModel.DataAnnotations;

namespace PortfolioSiteApi.Models.DTO
{
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}