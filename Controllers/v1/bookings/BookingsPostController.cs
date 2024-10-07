using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotelapi.DTOs;
using hotelapi.Models;
using hotelapi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hotelapi.Controllers.v1.bookings
{
    [ApiController]
    [Route("api/v1/bookings/[controller]")]
    public class BookingsPostController : BookingsController
    {
        public BookingsPostController(IBookingRepository _bookingRepository) : base(_bookingRepository)
        {
        }

        [HttpPost("bookings")]
        [Authorize]
        [SwaggerOperation(
            Summary = "Create a new booking",
            Description = "This endpoint allows you to create a new booking in the database"
        )]
        [SwaggerResponse(200, "Return the new booking")]
        [SwaggerResponse(400, "Invalid request")]
        [SwaggerResponse(409, "Booking with the same guest and room already exists")]
        public async Task<IActionResult> PostCreateProducts([FromBody] BookingDTO booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookingSave = new Booking()
            {
                RoomId = booking.RoomId,
                GuestId = booking.GuestId,
                EmployeeId = booking.EmployeeId,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                TotalCost = 0 // Calculate total cost based on room rate and duration
            };

            if (booking.EndDate != null)
            {
                var daysDifference = (booking.EndDate.Value - booking.StartDate).Days;
                bookingSave.TotalCost = bookingSave.Room.PricePerNight * daysDifference;
            }
            else
            {
                bookingSave.TotalCost = 1 * bookingSave.Room.PricePerNight;
            }

            if (await bookingRepository.CheckAvailable(booking.RoomId) == true)
            {
                return Ok("the reservation was made successfully");
            }
            else
            {
                return Conflict("Room is not available for the given date range");
            }
        }
    }
}