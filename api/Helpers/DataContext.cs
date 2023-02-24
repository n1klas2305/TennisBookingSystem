namespace WebApi.Helpers;

using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

public class DataContext : DbContext
{
  protected readonly IConfiguration Configuration;

  public DataContext(IConfiguration configuration)
  {
    Configuration = configuration;
  }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    // in memory database used for simplicity, change to a real db for production applications
    options.UseInMemoryDatabase("TestDb");
  }

  public DbSet<Booking> Bookings { get; set; }
  public DbSet<Court> Courts { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Booking>()
        .HasOne(b => b.Court)
        .WithMany(c => c.Bookings);
  }
}