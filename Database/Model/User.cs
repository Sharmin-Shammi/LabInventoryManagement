namespace Database.Model
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
