using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioSiteApi.Models
{
    public class Field
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        public string FieldName { get; set; }
        public string ProgrammingLanguage { get; set; }
        public int YearsOfExperience { get; set; }
    }
}
