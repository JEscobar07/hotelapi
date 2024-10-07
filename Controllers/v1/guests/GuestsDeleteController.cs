using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotelapi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hotelapi.Controllers.v1.guests
{
    [ApiController]
    [Route("api/v1/guests/[controller]")]
    public class GuestsDeleteController : GuestsController
    {
        public GuestsDeleteController(IGuestRepository _GuestRepository) : base(_GuestRepository)
        {
        }

        [HttpDelete("guests/{id}")]
        [SwaggerOperation(
            Summary = "Delete a guest by id",
            Description = "Delete a guest by id from the database."
        )]
        [SwaggerResponse(204, "Guest deleted")]
        [SwaggerResponse(404, "no guest found for the given id")]
        public async Task<IActionResult> DeleteGuest([FromRoute] int id)
        {
            if (await GuestRepository.Delete(id) == true)
            {
                return Ok("Product successfully removed");
            }
            else
            {
                return BadRequest("We are sorry but the product is not in our system");
            }

        }
    }
}