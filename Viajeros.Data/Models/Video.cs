using System.ComponentModel.DataAnnotations;

namespace Viajeros.Data.Models
{
    public class Video
    {
        public Video()
        {
            Date = DateTime.Now;
        }
        public int? Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Nombre")]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Descripción")]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Fecha de subida")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Link del video")]
        [MaxLength(150)]
        public string VideoLink { get; set; }
        [Display(Name = "Link del video block 2")]
        [MaxLength(150)]
        public string? VideoLinkSecond { get; set; }
        [Display(Name = "Link del video block 3")]
        [MaxLength(150)]
        public string? VideoLinkThird { get; set; }
        [Display(Name = "Link del video block 4")]
        [MaxLength(150)]
        public string? VideoLinkFourth { get; set; }
        public ICollection<VideoTag> Tags { get; set; }
    }
}
