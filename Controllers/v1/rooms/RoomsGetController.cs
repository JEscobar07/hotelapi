using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotelapi.Models;
using hotelapi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hotelapi.Controllers.v1.rooms
{
    [ApiController]
    [Route("api/v1/rooms/[controller]")]
    public class RoomsGetController : RoomsController
    {
        public RoomsGetController(IRoomRepository _roomRepository) : base(_roomRepository)
        {
        }

        [HttpGet("available")]
        [SwaggerOperation(
            Summary = "available rooms",
            Description = "Each employee can see which rooms areavailable to choose"
        )]
        [SwaggerResponse(200, "Return available rooms")]
        [SwaggerResponse(404, "No room available")]
        public async Task<ActionResult<IEnumerable<Room>>> GetAvailableRooms()
        {
            var rooms = await roomRepository.GetAvailable();
            if (rooms == null || !rooms.Any())
            {
                return NotFound("There are no rooms available at the moment");
            }
            return Ok(rooms);
        }
    }
}