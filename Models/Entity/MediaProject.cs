using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioSiteApi.Models.Entity
{
    public class MediaProject
    {
        [Column("project_id")]
        public int ProjectId { get; set; }

        [Column("media_id")]        
        public int MediaId { get; set; }

        [ForeignKey(nameof(ProjectId))]
         public Project Project { get; set; }

        [ForeignKey(nameof(MediaId))]
         public Media Media { get; set; }
    }
}
