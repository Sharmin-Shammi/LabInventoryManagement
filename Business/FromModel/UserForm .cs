using Database.Model;
using System.ComponentModel.DataAnnotations;

namespace LabInventory.FormModel
{
    public class UserForm : BaseModel
    {
        [Required, MaxLength(40)]
        public string? FullName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required, MinLength(8)]
        public string? Password { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
        public int? SupplierId { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
