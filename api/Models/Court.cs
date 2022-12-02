using System;
using System.Collections.Generic;

namespace TennisCourtBooking.Models
{
    public partial class Court
    {
        public Court()
        {
            Bockings = new HashSet<Bocking>();
        }

        public int CourtId { get; set; }
        public string? Label { get; set; }

        public virtual ICollection<Bocking> Bockings { get; set; }
    }
}
