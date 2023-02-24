namespace WebApi.Services;

using AutoMapper;
using BCrypt.Net;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Bookings;

public interface IBookingService
{
  IEnumerable<Booking> GetAll();
  Booking GetById(int id);
  void Create(CreateRequest model);
  void Update(int id, UpdateRequest model);
  void Delete(int id);
}

public class BookingService : IBookingService
{
  private DataContext _context;
  private readonly IMapper _mapper;

  public BookingService(
      DataContext context,
      IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public IEnumerable<Booking> GetAll()
  {
    return _context.Bookings;
  }

  public Booking GetById(int id)
  {
    return getBooking(id);
  }

  public void Create(CreateRequest model)
  {
    // validate
    // if (_context.Bookings.Any(x => x.BookingId == model.BookingId))
    // throw new AppException("Booking with the email '" + model.Email + "' already exists");

    // map model to new booking object
    var booking = _mapper.Map<Booking>(model);

    // hash password
    // booking.PasswordHash = BCrypt.HashPassword(model.Password);

    // save booking
    _context.Bookings.Add(booking);
    _context.SaveChanges();
  }

  public void Update(int id, UpdateRequest model)
  {
    var booking = getBooking(id);

    // validate
    // if (model.Email != booking.Email && _context.Bookings.Any(x => x.Email == model.Email))
    //   throw new AppException("Booking with the email '" + model.Email + "' already exists");

    // hash password if it was entered
    if (!string.IsNullOrEmpty(model.Password))
      // booking.PasswordHash = BCrypt.HashPassword(model.Password);

      // copy model to booking and save
      _mapper.Map(model, booking);
    _context.Bookings.Update(booking);
    _context.SaveChanges();
  }

  public void Delete(int id)
  {
    var booking = getBooking(id);
    _context.Bookings.Remove(booking);
    _context.SaveChanges();
  }

  // helper methods

  private Booking getBooking(int id)
  {
    var booking = _context.Bookings.Find(id);
    if (booking == null) throw new KeyNotFoundException("Booking not found");
    return booking;
  }
}