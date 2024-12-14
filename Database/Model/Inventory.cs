using System.ComponentModel.DataAnnotations;

namespace Database.Model
{
    public class Inventory:BaseModel
    {
        [Key]
        public string ItemId { get; set; } = Guid.NewGuid().ToString();
        [Required,MaxLength(40)]
        public string? ItemName { get; set; }
        [Required]
        public string ItemDetails { get; set; }
        [Required]
        public string QuantityInstock { get; set; }
        [Required]
        public string UnitPrice { get; set; }
        [Required]
        public string SupplierId { get; set; }
        
    }
}
