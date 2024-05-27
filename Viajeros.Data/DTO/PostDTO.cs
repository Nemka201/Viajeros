using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viajeros.Data.Models;

namespace Viajeros.Data.DTO;
[NotMapped]
public class PostDTO
{
    [Required]
    public Post? Post { get; set; }
    public string[]? ImagesURL { get; set; }
}
