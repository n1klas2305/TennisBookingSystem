namespace WebApi.Controllers.Booking;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Bookings;
using WebApi.Services.Booking;

[ApiController]
[Route("[controller]")]
public class BookingsController : ControllerBase
{
  private IBookingService _bookingService;
  private IMapper _mapper;

  public BookingsController(
      IBookingService bookingService,
      IMapper mapper)
  {
    _bookingService = bookingService;
    _mapper = mapper;
  }

  [HttpGet]
  public IActionResult GetAll()
  {
    var bookings = _bookingService.GetAll();
    return Ok(bookings);
  }

  [HttpGet("{id}")]
  public IActionResult GetById(int id)
  {
    var booking = _bookingService.GetById(id);
    return Ok(booking);
  }

  [HttpPost]
  public IActionResult Create(CreateRequest model)
  {
    _bookingService.Create(model);
    return Ok(new { message = "Booking created" });
  }

  [HttpPut("{id}")]
  public IActionResult Update(int id, UpdateRequest model)
  {
    _bookingService.Update(id, model);
    return Ok(new { message = "Booking updated" });
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
    _bookingService.Delete(id);
    return Ok(new { message = "Booking deleted" });
  }
}