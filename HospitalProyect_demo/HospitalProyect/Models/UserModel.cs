using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace HospitalProyect.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "formato de correo invalido")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debes asignar un rol")]
        public int RoleId { get; set; }

        [ValidateNever]
        public RoleModel Role { get; set; } = null!;
    }
}
