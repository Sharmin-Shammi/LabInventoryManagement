namespace Database.Model
{
    public class Document
    {
        [Key] 
        public string DocumentId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string DocumentName { get; set; }
        [Required]
        public string DocumentType { get; set; }
        [Required]
        public string TransactionQuality { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string TransactionId { get; set; }
        
    }
}
