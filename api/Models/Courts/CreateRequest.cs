namespace WebApi.Models.Courts;

using System.ComponentModel.DataAnnotations;

public class CreateRequest
{
  [Required]
  public int CourtId { get; set; }

  [Required]
  public string Label { get; set; }
}