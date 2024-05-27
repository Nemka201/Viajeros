using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
