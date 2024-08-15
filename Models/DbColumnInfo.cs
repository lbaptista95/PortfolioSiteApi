using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioSiteApi.Models
{
    public class DbColumnInfo
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}