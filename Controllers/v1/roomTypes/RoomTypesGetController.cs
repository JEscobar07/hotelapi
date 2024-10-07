using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotelapi.Controllers.v1.rooms;
using hotelapi.Models;
using hotelapi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hotelapi.Controllers.v1.roomTypes
{
    [ApiController]
    [Route("api/v1/roomTypes/[controller]")]
    public class RoomTypesGetController : RoomTypesController
    {
        public RoomTypesGetController(IRoomTypesRepository _roomTypesRepository) : base(_roomTypesRepository)
        {
        }

        [HttpGet("room_types")]
        [SwaggerOperation(
            Summary = "room types",
            Description = "see all room types available."
        )]
        [SwaggerResponse(200, "Return rooms types")]
        [SwaggerResponse(404, "no room types to display")]
        public async Task<ActionResult<IEnumerable<RoomType>>> GetAll()
        {
            var roomTypes = await roomTypesRepository.GetAll();
            if (roomTypes == null || !roomTypes.Any())
            {
                return NotFound("no room types to display");
            }
            return Ok(roomTypes);
        }

        [HttpGet("room_types/{id}")]
        [SwaggerOperation(
            Summary = "room type by id",
            Description = "see details of a room type by id."
        )]
        [SwaggerResponse(200, "Return room type")]
        [SwaggerResponse(404, "no room type found for the given id")]
        public async Task<ActionResult<RoomType>> GetById(int id)
        {
            var roomType = await roomTypesRepository.GetId(id);
            if (roomType == null)
            {
                return NotFound("no room type found for the given id");
            }
            return Ok(roomType);
        }
    }
}
