using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi;

public class Tests
{
  private DataContext GetDatabaseContext()
  {
    var options = new DbContextOptionsBuilder<DataContext>()
        .UseInMemoryDatabase("TestDb").Options;

    var databaseContext = new DataContext(null);
    databaseContext.Database.EnsureCreated();

    return databaseContext;
  }

  [Test]
  public void aRequestBookings()
  {
    var db = GetDatabaseContext();
    var booking = db.Bookings.Find(1);

    Assert.IsNotNull(booking);
    Assert.AreEqual(booking.FirstName, "Hetty");
  }

  [Test]
  public void bCreateBooking()
  {
    var db = GetDatabaseContext();
    db.Bookings.Add(new Booking
    {
      BookingId = 7,
      CourtId = 3,
      Date = new DateTime(2023, 04, 26),
      StartTime = 10,
      EndTime = 22,
      FirstName = "Newt",
      LastName = "Tree",
      Type = Booking.BookingType.BOOKED
    });

    var booking = db.Bookings.Find(7);

    Assert.IsNotNull(booking);
    Assert.AreEqual(booking.FirstName, "Newt");
  }

  [Test]
  public void cCancelBooking()
  {
    var db = GetDatabaseContext();
    var booking = db.Bookings.Find(1);
    db.Bookings.Remove(booking);
    db.SaveChanges();

    var canceledBooking = db.Bookings.Find(1);
    Assert.IsNull(canceledBooking);
  }

  [Test]
  public void dBlockCourt()
  {
    var db = GetDatabaseContext();
    var booking = db.Bookings.Find(2);
    Assert.AreEqual(booking.Type, Booking.BookingType.BOOKED);

    booking.Type = Booking.BookingType.BLOCKED;
    db.Bookings.Update(booking);
    db.SaveChanges();

    var blockedCourt = db.Bookings.Find(2);
    Assert.AreEqual(blockedCourt.Type, Booking.BookingType.BLOCKED);
  }
  [Test]
  public void eDeblockCourt()
  {
    var db = GetDatabaseContext();
    var booking = db.Bookings.Find(4);
    Assert.AreEqual(booking.Type, Booking.BookingType.BLOCKED);

    booking.Type = Booking.BookingType.BLOCKED;
    db.Bookings.Update(booking);
    db.SaveChanges();

    var blockedCourt = db.Bookings.Find(4);
    Assert.AreEqual(blockedCourt.Type, Booking.BookingType.BLOCKED);
  }
}
