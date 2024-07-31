using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Viajeros.Data.Models
{
    public class VideoTag
    { 
        [Key]
        public int Id { get; set; }
        [ForeignKey("Video")]
        public int? VideoID { get; set; }
        [ForeignKey("Tag")]
        public int TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}
