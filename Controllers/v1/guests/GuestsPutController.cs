
using hotelapi.DTOs;
using hotelapi.Models;
using hotelapi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hotelapi.Controllers.v1.guests
{
    [ApiController]
    [Route("api/v1/guests/[controller]")]
    public class GuestsPutController : GuestsController
    {
        public GuestsPutController(IGuestRepository _GuestRepository) : base(_GuestRepository)
        {
        }

        [HttpPut("guests/{id}")]
        [Authorize]
        [SwaggerOperation(
            Summary = "Update a guest",
            Description = "This endpoint allows you to update a guest in the database")]
        [SwaggerResponse(200, "Return the updated guest")]
        [SwaggerResponse(400, "Invalid request")]
        [SwaggerResponse(404, "No guest found for the given id")]
        public async Task<IActionResult> PutUpdateProducts([FromRoute] int id, [FromBody] GuestDTO guest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var guestFound = await GuestRepository.GetId(id);
            if (guestFound == null)
            {
                return NotFound("No guest found for the given id");
            }

            guestFound.FirstName = guest.FirstName;
            guestFound.LastName = guest.LastName;
            guestFound.Email = guest.Email;
            guestFound.IdentificationNumber = guest.IdentificationNumber;
            guestFound.PhoneNumber = guest.PhoneNumber;
            guestFound.Birthdate = guest.Birthdate;

            await GuestRepository.Update(id, guestFound);
            return Ok(guestFound);
        }

    }
}