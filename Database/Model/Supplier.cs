namespace Database.Model
{
    public class Supplier
    {
        [Key]
        public string SupplierId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string SupplierName { get; set; }
        [Required]
        public string SupplierEmail { get; set; }
        [Required]
        public string SupplierPhoneNumber { get; set; }
        [Required]
        public string SupplierAddress { get; set; }
        [Required]
        public string SupplyCatogory { get; set; }
       
    }
}
