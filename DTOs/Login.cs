using System.ComponentModel.DataAnnotations;

namespace PortfolioSiteApi.DTOs
{
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}