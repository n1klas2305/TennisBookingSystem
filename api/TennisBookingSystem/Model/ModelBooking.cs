using System;
using TennisBookingSystem.Enum;

namespace TennisBookingSystem.Model
{
    public class ModelBooking
    {
        private int id { get; set; }
        private ModelCourt court { get; set; }
        private BookingType bookingType { get; set; }
        private string firstname { get; set; }
        private string lastname { get; set; }
        private DateTime date { get; set; }
        int startTime { get; set; }
        int endTime { get; set; }

    }
}