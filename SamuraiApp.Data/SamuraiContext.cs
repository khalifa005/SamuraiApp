using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;

namespace SamuraiApp.Data
{
  public class SamuraiContext : DbContext
  {
    public DbSet<Samurai> Samurais { get; set; }
    public DbSet<Quote> Quotes { get; set; }
    public DbSet<Clan> Clans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(
          "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = SamuraiAppData");
    }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //when ef is running will pass model bullder obj then we will ask ef to make a composite key for samuraiBattel table
            modelBuilder.Entity<SamuraiBattel>().HasKey(s=> new { s.BattelId, s.SamuraiId});
        }
  }
}