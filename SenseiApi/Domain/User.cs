namespace SenseiApi.Domain
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string PasswordHash { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private User() { } // dla EF Core

        public User(string name, string email, string passwordHash)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            CreatedAt = DateTime.UtcNow;
        }


        public void ChangeEmail(string email)
        {
            Email = email;
        }
    }
}
