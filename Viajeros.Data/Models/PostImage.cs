using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Viajeros.Data.Models
{
    public class PostImage
    {
        [Key] public int Id { get; set; }
        [ForeignKey("Post")] public int PostId { get; set; }
        [Required] public string ImageUrl { get; set; }
    }
}
