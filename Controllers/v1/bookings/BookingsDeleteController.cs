using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotelapi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hotelapi.Controllers.v1.bookings
{
    [ApiController]
    [Route("api/v1/bookings/[controller]")]
    public class BookingsDeleteController : BookingsController
    {
        public BookingsDeleteController(IBookingRepository _bookingRepository) : base(_bookingRepository)
        {
        }
        
        [HttpDelete("bookings/{id}")]
        [Authorize]
        [SwaggerOperation(
            Summary = "Delete a booking by ID",
            Description = "This endpoint allows you to delete a booking from the database"
        )]
        [SwaggerResponse(204, "Booking deleted")]
        [SwaggerResponse(404, "No booking found for the given id")]
        public async Task<IActionResult> DeleteBooking([FromRoute] int id)
        {
            if (await bookingRepository.Delete(id) == true)
            {
                return Ok("Product successfully removed");
            }
            else
            {
                return NotFound("No booking found for the given id");
            }
        }
    }
}