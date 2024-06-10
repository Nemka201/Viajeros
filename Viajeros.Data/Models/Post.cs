using System.ComponentModel.DataAnnotations;

namespace Viajeros.Data.Models
{
    public class Post
    {
        public Post()
        {
            Created = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Titulo")]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Descripción")]
        [MaxLength(5000)]
        public string Description { get; set; }
        [Display(Name = "Publicado")]
        public DateTime Created { get; set; }
        [MaxLength(200)]
        public ICollection<PostImage> Images { get; set; }
    }
}
