using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SamuraiApp.Domain;

/// <summary>
/// to add new migration use 
/// Add-Migration MigrationName -Context SamuraiContext
/// because we have more than one db context 
/// </summary>
namespace SamuraiApp.Data
{
  public class SamuraiContext : DbContext
  {
    public DbSet<Samurai> Samurais { get; set; }
    public DbSet<Quote> Quotes { get; set; }
    public DbSet<Clan> Clans { get; set; }
    public DbSet<Battel> Battels { get; set; }
    public DbSet<SamuraiBattleStat> SamuraiBattleStats { get; set; }

        //public DbSet<SamuraiBattel> SamuraiBattels { get; set; } ef will configure from nav prop

        //public DbSet<Horse> Horses { get; set; } we won't add it here so we can't interact with it in our business logic so we will handel it with fluent api

        public static readonly ILoggerFactory ConsoleLoggerFactory = LoggerFactory.Create(builder  => { 
        builder.AddFilter((category, level) =>
            category == DbLoggerCategory.Database.Command.Name
            && level == LogLevel.Information).AddConsole();
        });
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder
                .UseLoggerFactory(ConsoleLoggerFactory).EnableSensitiveDataLogging() //overwrite to see values to the log
                .UseSqlServer(
          "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = SamuraiAppData");
    }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //when ef is running will pass model builder obj then we will ask ef to make a composite key for samuraiBattel table
            modelBuilder.Entity<SamuraiBattel>().HasKey(s=> new { s.BattelId, s.SamuraiId});
            modelBuilder.Entity<Horse>().ToTable("Horses"); //without this the default name would be Horse and this will break our naming convenstion
            modelBuilder.Entity<SamuraiBattleStat>().HasNoKey().ToView("SamuraiBattleStats");
        }

        //to configure in asp core web project in startup
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddControllers();
        //    services.AddDbContext<SamuraiContext>(opt =>
        //       opt.UseSqlServer(Configuration.GetConnectionString("SamuraiConnex"))
        //          .EnableSensitiveDataLogging()
        //       );


        }
}