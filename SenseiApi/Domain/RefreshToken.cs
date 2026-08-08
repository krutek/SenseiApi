namespace SenseiApi.Domain
{
    public class RefreshToken
    {
        private RefreshToken() { }
        public RefreshToken(Guid userId, string token, DateTime expiresAt)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Token = token;
            ExpiresAt = expiresAt;
        }
        public Guid Id { get; private set; }

        public Guid UserId { get; private set; }

        public string Token { get; private set; } = string.Empty;

        public DateTime ExpiresAt { get; private set; }

        public DateTime? RevokedAt { get; private set; }

        public bool IsActive => RevokedAt == null && ExpiresAt > DateTime.UtcNow;

        public void Revoke()
        {
            RevokedAt = DateTime.UtcNow;
        }
    }
}
