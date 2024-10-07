using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotelapi.Models;
using hotelapi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hotelapi.Controllers.v1.bookings
{
    [ApiController]
    [Route("api/v1/bookings/[controller]")]
    public class BookingsGetController : BookingsController
    {
        public BookingsGetController(IBookingRepository _bookingRepository) : base(_bookingRepository)
        {
        }

        [HttpGet("bookings/search/{identification_number}")]
        [SwaggerOperation(
            Summary = "bookings by identification number",
            Description = "see bookings by their identification number."
        )]
        [SwaggerResponse(200, "Return bookings")]
        [SwaggerResponse(404, "no bookings found for the given identification number")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetByIdentificationNumber(string identification_number)
        {
            var bookings = await bookingRepository.GetIdentificationNumber(identification_number);
            if (bookings == null ||!bookings.Any())
            {
                return NotFound("no bookings found for the given identification number");
            }
            return Ok(bookings);
        }

        [HttpGet("bookings/{id}")]
        [SwaggerOperation(
            Summary = "booking by id",
            Description = "see a booking by id."
        )]
        [SwaggerResponse(200, "Return booking")]
        [SwaggerResponse(404, "no booking found for the given id")]
        public async Task<ActionResult<Booking>> GetById(int id)
        {
            var booking = await bookingRepository.GetId(id);
            if (booking == null)
            {
                return NotFound("no booking found for the given id");
            }
            return Ok(booking);
        }
    }
}