namespace users.Models
{
    public class User //scheme for database
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Created { get; set; }
    }
}
