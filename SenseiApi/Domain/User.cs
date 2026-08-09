namespace SenseiApi.Domain
{
    public class User
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PasswordHash { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public ICollection<RefreshToken> RefreshTokens { get; private set; } = new List<RefreshToken>();

        private User() { }

        public User(string firstName, string lastName, string email, string passwordHash)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
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
