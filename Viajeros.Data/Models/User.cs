using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Viajeros.Data.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Display(Name = "Nombre")]
    [MaxLength(20)]
    public string Name { get; set; }
    [NotMapped]
    public string? Token { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Display(Name = "Usuario")]
    [MaxLength(20)]
    public string UserName { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Display(Name = "Contraseña")]
    [MaxLength(20)]
    public string Password { get; set; }
    public string Rol {  get; set; }

}
