using System.ComponentModel.DataAnnotations;

namespace HospitalProyect.Models
{
    public class RoleModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre del rol es obligatorio")]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [StringLength(200)]
        public string? Description { get; set; }

        public ICollection<UserModel> Users { get; set; } = new List<UserModel>();
    }
}
