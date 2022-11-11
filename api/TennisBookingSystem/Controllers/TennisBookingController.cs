using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TennisBookingSystem.Model;

namespace TennisBookingSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TennisBookingController : ControllerBase
    {

        private readonly ILogger<TennisBookingController> _logger;

        public TennisBookingController(ILogger<TennisBookingController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<ModelBooking> readBookingList()
        {

            List<ModelBooking> bookingLst= new List<ModelBooking>();
            return bookingLst;
        }

        [HttpPost]
        public List<ModelBooking> addBooking(ModelBooking booking)
        {

            List<ModelBooking> bookingLst = new List<ModelBooking>();
            return bookingLst;
        }
    }
}
