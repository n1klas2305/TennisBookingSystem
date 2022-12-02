using System;
using System.Collections.Generic;

namespace TennisCourtBooking.Models
{
    public partial class Bocking
    {
        public int BookingId { get; set; }
        public int? CourtId { get; set; }
        public string? Type { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public DateOnly? Date { get; set; }
        public int? StartTime { get; set; }
        public int? EndTime { get; set; }

        public virtual Court? Court { get; set; }
    }
}
