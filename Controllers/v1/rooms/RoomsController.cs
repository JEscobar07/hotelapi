using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotelapi.Models;
using hotelapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace hotelapi.Controllers.v1.rooms
{
    [ApiController]
    [Route("/api/v1/rooms/[controller]")]
    public class RoomsController : ControllerBase
    {
        protected readonly IRoomRepository roomRepository;

        public RoomsController(IRoomRepository _roomRepository)
        {
            roomRepository = _roomRepository;
        }
    }
}