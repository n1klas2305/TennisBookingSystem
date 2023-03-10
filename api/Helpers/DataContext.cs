namespace WebApi.Helpers;

using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

public class DataContext : DbContext
{
  protected readonly IConfiguration Configuration;

  public DataContext(IConfiguration configuration)
  {
    Database.EnsureCreated();
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
    modelBuilder.Entity<Court>().HasData(
        new Court
        {
          CourtId = 1,
          Label = "Platz 1"
        },
        new Court
        {
          CourtId = 2,
          Label = "Platz 2"
        },
        new Court
        {
          CourtId = 3,
          Label = "Platz 3"
        },
        new Court
        {
          CourtId = 4,
          Label = "Platz 4"
        }
    );

    modelBuilder.Entity<Booking>().HasData(
        new Booking
        {
          BookingId = 1,
          CourtId = 1,
          FirstName = "Hetty",
          LastName = "Deacon",
          Date = new DateTime(2023, 03, 24),
          StartTime = 12,
          EndTime = 14,
          Type = Booking.BookingType.BOOKED
        },
        new Booking
        {
          BookingId = 2,
          CourtId = 1,
          FirstName = "Oisin",
          LastName = "Clements",
          Date = new DateTime(2023, 03, 25),
          StartTime = 9,
          EndTime = 10,
          Type = Booking.BookingType.BOOKED
        },
        new Booking
        {
          BookingId = 3,
          CourtId = 1,
          FirstName = "Maaria",
          LastName = "Garza",
          Date = new DateTime(2023, 03, 26),
          StartTime = 14,
          EndTime = 15,
          Type = Booking.BookingType.BOOKED
        },
        new Booking
        {
          BookingId = 4,
          CourtId = 1,
          Date = new DateTime(2023, 03, 26),
          StartTime = 17,
          EndTime = 18,
          Type = Booking.BookingType.BLOCKED
        },
        new Booking
        {
          BookingId = 5,
          CourtId = 3,
          FirstName = "Lili",
          LastName = "Wilkes",
          Date = new DateTime(2023, 03, 24),
          StartTime = 11,
          EndTime = 14,
          Type = Booking.BookingType.BOOKED
        },
        new Booking
        {
          BookingId = 6,
          CourtId = 3,
          Date = new DateTime(2023, 03, 26),
          StartTime = 10,
          EndTime = 22,
          Type = Booking.BookingType.BLOCKED
        }
    );

    modelBuilder.Entity<Booking>()
        .HasOne(b => b.Court)
        .WithMany(c => c.Bookings)
        .IsRequired();
  }
}