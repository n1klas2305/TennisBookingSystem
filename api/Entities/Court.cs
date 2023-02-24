namespace WebApi.Entities;

public class Court
{
  public int CourtId { get; set; }
  public string Label { get; set; }

  public List<Booking> Bookings { get; set; }
}
