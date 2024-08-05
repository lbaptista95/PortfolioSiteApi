using System.ComponentModel.DataAnnotations;

namespace PortfolioSiteApi.Models
{
    public class FieldProject
    {
        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int FieldId { get; set; }
    }
}
