using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotelapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace hotelapi.Controllers.v1.bookings
{
    [ApiController]
    [Route("api/v1/bookings/[controller]")]
    public class BookingsController : ControllerBase
    {
        protected readonly IBookingRepository bookingRepository;

        public BookingsController(IBookingRepository _bookingRepository)
        {
            bookingRepository = _bookingRepository;
        }
    }
}