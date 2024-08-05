using System.ComponentModel.DataAnnotations;

namespace PortfolioSiteApi.Models
{
    public class Field
    {
        [Key]
        public int Id { get; set; }
        public string FieldName { get; set; }
        public string ProgrammingLanguage { get; set; }
        public int YearsOfExperience { get; set; }
    }
}
