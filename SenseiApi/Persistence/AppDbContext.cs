using Microsoft.EntityFrameworkCore;
using SenseiApi.Domain;
using SenseiApi.Domain.Flashcards;

namespace SenseiApi.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
        public DbSet<Flashcard> Flashcards { get; set; }
        public DbSet<FlashcardTranslation> FlashcardTranslations {get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
