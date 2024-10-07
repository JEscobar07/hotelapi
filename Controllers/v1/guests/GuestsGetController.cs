using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotelapi.Models;
using hotelapi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hotelapi.Controllers.v1.guests
{
    [ApiController]
    [Route("api/v1/guests/[controller]")]
    public class GuestsGetController : GuestsController
    {
        public GuestsGetController(IGuestRepository _GuestRepository) : base(_GuestRepository)
        {
        }

        [HttpGet("guests")]
        [SwaggerOperation(
            Summary = "guests",
            Description = "see all guests in the hotel."
        )]
        [SwaggerResponse(200, "Return guests")]
        [SwaggerResponse(404, "no guests to display")]
        public async Task<ActionResult<IEnumerable<Guest>>> GetAll()
        {
            var guests = await GuestRepository.GetAll();
            if (guests == null ||!guests.Any())
            {
                return NotFound("no guests to display");
            }
            return Ok(guests);
        }

        [HttpGet("guests/{id}")]
        [SwaggerOperation(
            Summary = "guest by id",
            Description = "see a guest by id."
        )]
        [SwaggerResponse(200, "Return guest")]
        [SwaggerResponse(404, "no guest found for the given id")]
        public async Task<ActionResult<Guest>> GetById(int id)
        {
            var guest = await GuestRepository.GetId(id);
            if (guest == null)
            {
                return NotFound("no guest found for the given id");
            }
            return Ok(guest);
        }

        [HttpGet("guests/search/{keyword}")]
        [SwaggerOperation(
            Summary = "guests by keyword",
            Description = "see guests by their keyword."
        )]
        [SwaggerResponse(200, "Return guests")]
        [SwaggerResponse(404, "no guests found for the given keyword")]
        public async Task<ActionResult<IEnumerable<Guest>>> Getkeyword(string keyword)
        {
            var guests = await GuestRepository.Getkeyword(keyword);
            if (guests == null ||!guests.Any())
            {
                return NotFound("no guests found for the given keyword");
            }
            return Ok(guests);
        }
        
        

    }
}