using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotelapi.DTOs;
using hotelapi.Models;
using hotelapi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hotelapi.Controllers.v1.guests
{
    [ApiController]
    [Route("api/v1/guests/[controller]")]
    public class GuestsPostController : GuestsController
    {
        public GuestsPostController(IGuestRepository _GuestRepository) : base(_GuestRepository)
        {
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create a new guest",
            Description = "This endpoint allows you to create a new guest in the database")]
        [SwaggerResponse(200, "Return the new guest")]
        [SwaggerResponse(400, "Invalid request")]
        [SwaggerResponse(409, "Guest with the same identification number already exists")]

        public async Task<IActionResult> PostCreateProducts([FromBody] GuestDTO guest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var guestSave = new Guest()
            {
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                Email = guest.Email,
                IdentificationNumber = guest.IdentificationNumber,
                PhoneNumber = guest.PhoneNumber,
                Birthdate = guest.Birthdate
            };
            if (await GuestRepository.CheckExistence(guest.IdentificationNumber) == true)
            {
                return Conflict("Identification number already exists");
            }
            else
            {
                await GuestRepository.Add(guestSave);
                return Ok("Product saved successfully");
            }
        }
    }
}