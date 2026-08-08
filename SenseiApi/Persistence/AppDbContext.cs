using Microsoft.EntityFrameworkCore;
using SenseiApi.Domain;

namespace SenseiApi.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
