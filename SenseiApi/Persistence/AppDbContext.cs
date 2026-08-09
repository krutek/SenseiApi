using Microsoft.EntityFrameworkCore;
using SenseiApi.Domain;

namespace SenseiApi.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
        public DbSet<Flashcard> Flashcards => Set<Flashcard>();
        public DbSet<FlashcardTranslation> FlashcardTranslations => Set<FlashcardTranslation>();
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
