using System.ComponentModel.DataAnnotations;

namespace Database.Model
{
    public class Transaction:BaseModel
    {
        [Key]
        public string TransactionId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string TransactionDate { get; set; }
        [Required]
        public string TransactionType { get; set; }
        [Required]
        public string TransactionQuality { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string SupplierId { get; set; }
        [Required]
        public string ItemId { get; set; }
    }
}
