using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;

namespace SamuraiApp.Data
{
  public class SamuraiContext : DbContext
  {
    public DbSet<Samurai> Samurais { get; set; }
    public DbSet<Quote> Quotes { get; set; }
    public DbSet<Clan> Clans { get; set; }

    //public DbSet<SamuraiBattel> SamuraiBattels { get; set; } ef will configure from nav prop

    //public DbSet<Horse> Horses { get; set; } we won't add it here so we cann't interact with it in our bussness logic so we will handel it with fluent api

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(
          "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = SamuraiAppData");
    }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //when ef is running will pass model bullder obj then we will ask ef to make a composite key for samuraiBattel table
            modelBuilder.Entity<SamuraiBattel>().HasKey(s=> new { s.BattelId, s.SamuraiId});
            modelBuilder.Entity<Horse>().ToTable("Horses"); //without this the default name would be Horse and this will break our naming convenstion
        }
  }
}