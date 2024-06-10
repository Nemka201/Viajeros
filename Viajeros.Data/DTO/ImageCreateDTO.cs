using System.ComponentModel.DataAnnotations.Schema;

namespace Viajeros.Data.DTO
{
    [NotMapped]
    public class ImageCreateDTO
    {
        public ImageCreateDTO(int postId, string url)
        {
            this.PostId = postId;
            this.Url = url;
        }
        public string Url { get; set; }
        public int PostId { get; set; }
    }
}
