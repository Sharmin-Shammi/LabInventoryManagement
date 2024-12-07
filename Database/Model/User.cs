using System.ComponentModel.DataAnnotations;

namespace Database.Model
{
    public class User
    {
        [Key]
        public string UserId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserPassword { get; set; }
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string UserPhoneNumber { get; set; }
        [Required]
        public string UserLastLogin { get; set; }


    }
}
