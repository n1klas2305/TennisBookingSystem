namespace WebApi.Entities;

public class Booking
{
  public int BookingId { get; set; }
  public int? CourtId { get; set; }
  public string Type { get; set; }
  public string Firstname { get; set; }
  public string Lastname { get; set; }
  public DateTime? Date { get; set; }
  public int? StartTime { get; set; }
  public int? EndTime { get; set; }

  public Court Court { get; set; }
}
