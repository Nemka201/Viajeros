using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Viajeros.Data.DTO;
[NotMapped]
public class LoginUserDTO
{
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Display(Name = "Usuario")]
    [MaxLength(20)]
    public string UserName { get; set; }
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [Display(Name = "Contraseña")]
    [MaxLength(20)]
    public string Password { get; set; }
}
