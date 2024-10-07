using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotelapi.Models;
using hotelapi.Repositories;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("status")]
        [SwaggerOperation(
            Summary = "room count",
            Description = "Return total, occupied, and available rooms"
        )]

        [SwaggerResponse(200, "Return room count")]
        [SwaggerResponse(404, "there are no rooms to count")]

        public async Task<ActionResult<object>> GetStatusCountRooms(){

            var status = await roomRepository.GetStatusCountRooms();
            if (status == null)
            {
                return NotFound("there are no rooms to count");
            }
            return Ok(status);
        }

        [HttpGet]
        // [Authorize]
        [SwaggerOperation(
            Summary = "all rooms",
            Description = "Return all rooms"
        )]
        [SwaggerResponse(200, "Return all rooms")]
        [SwaggerResponse(404, "there are no rooms to display")]
        public async Task<ActionResult<IEnumerable<Room>>> GetAllRooms()
        {
            var rooms = await roomRepository.GetAll();
            if (rooms == null ||!rooms.Any())
            {
                return NotFound("There are no rooms to display");
            }
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        // [Authorize]
        [SwaggerOperation(
            Summary = "room by id",
            Description = "Return a room by id"
        )]
        [SwaggerResponse(200, "Return room")]
        [SwaggerResponse(404, "no room found for the given id")]
        public async Task<ActionResult<Room>> GetRoomById(int id)
        {
            var room = await roomRepository.GetId(id);
            if (room == null)
            {
                return NotFound("no room found for the given id");
            }
            return Ok(room);
        }

        [HttpGet("occupied")]
        // [Authorize]
        [SwaggerOperation(
            Summary = "busy rooms",
            Description = "Each employee can see which rooms are currently occupied")]

        [SwaggerResponse(200, "Return busy rooms")]
        [SwaggerResponse(404, "there are no rooms to display")]
        public async Task<ActionResult<IEnumerable<Room>>> GetOccupiedRooms()
        {
            var rooms = await roomRepository.GetOccupied();
            if (rooms == null ||!rooms.Any())
            {
                return NotFound("There are no rooms currently occupied");
            }
            return Ok(rooms);
        }      
    }
}