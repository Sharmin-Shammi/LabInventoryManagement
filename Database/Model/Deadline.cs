namespace Database.Model
{
    public class Deadline
    {
        [Key]
        public string DeadlineId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string ItemId { get; set; }
        [Required]
        public string DeadlineDate { get; set; }
        [Required]
        public string DeadlineType { get; set; }
        [Required]
        public string UserId { get; set; }
        
    }
}
