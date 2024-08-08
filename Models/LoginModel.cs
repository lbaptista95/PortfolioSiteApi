using System.ComponentModel.DataAnnotations;

namespace PortfolioSiteApi.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}