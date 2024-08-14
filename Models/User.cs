using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioSiteApi.Models
{
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("email")]
        public string Email;

        [Column("name")]
        public string Name { get; set; }

        [Column("company")]
        public string Company { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("contact")]
        public string Contact { get; set; }

        [Column("social_url")]
        public string SocialUrl { get; set; }

        [Column("email_confirmed")]
        public bool EmailConfirmed { get; set; }
    }
}
