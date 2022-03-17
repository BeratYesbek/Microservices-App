using Microsoft.EntityFrameworkCore;
using CommandsService.Models;
namespace CommandsService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }

        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>()
            .HasMany(p => p.Commands)
            .WithOne(p => p.platform!)
            .HasForeignKey(p => p.PlatformId);

            modelBuilder
            .Entity<Command>()
            .HasOne(p => p.platform)
            .WithMany(p => p.Commands)
            .HasForeignKey(p => p.PlatformId);
        }
    }
}