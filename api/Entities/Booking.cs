﻿namespace WebApi.Entities;

using System.Text.Json.Serialization;

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

  // [ForeignKey(nameof(CourtId))]
  // public virtual Court Court { get; set; }
}