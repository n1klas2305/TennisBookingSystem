using System;
using System.Collections.Generic;

#nullable disable

namespace TennisBookingApi.DbRepo
{
  public partial class Court
  {
    public Court()
    {
      Bookings = new HashSet<Booking>();
    }

    public int CourtId { get; set; }
    public string Label { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; }
  }
}
