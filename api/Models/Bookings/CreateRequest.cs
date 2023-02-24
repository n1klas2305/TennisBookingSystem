namespace WebApi.Models.Bookings;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class CreateRequest
{
  [Required]
  public int BookingId { get; set; }

  [Required]
  public int CourtId { get; set; }

  [Required]
  public string Type { get; set; }

  [Required]
  public string FirstName { get; set; }

  [Required]
  public string LastName { get; set; }

  [Required]
  public DateTime Date { get; set; }

  [Required]
  public int StartTime { get; set; }

  [Required]
  public int EndTime { get; set; }
}