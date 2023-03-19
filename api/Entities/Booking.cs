namespace WebApi.Entities;

public class Booking
{
  public enum BookingType
  {
    BOOKED,
    BLOCKED,
  }

  public int BookingId { get; set; }
  public int CourtId { get; set; }
  public BookingType Type { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public DateTime? Date { get; set; }
  public int? StartTime { get; set; }
  public int? EndTime { get; set; }

  public Court Court { get; set; }
}
