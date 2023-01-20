using Microsoft.AspNetCore.Mvc;
using TennisBookingApi.DbRepo;

namespace TennisBookingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingController : ControllerBase
{
    private readonly ScottDbContext dbContext;

    public BookingController(ScottDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public IEnumerable<Booking> getBookings()
    {
        return dbContext.Bookings.ToList();
    }
}


