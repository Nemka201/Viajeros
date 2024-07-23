using System.ComponentModel.DataAnnotations;

namespace Viajeros.Data.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Nombre")]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Descripción")]
        [MaxLength(100)]
        public string Description { get; set; }
        public ICollection<VideoTag>? Tags { get; set; }

    }
}
