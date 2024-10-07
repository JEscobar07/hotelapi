using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace hotelapi.Controllers.v1.guests
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestsController : ControllerBase
    {
        protected readonly IRoomRepository roomRepository;

        public RoomsController(IRoomRepository _roomRepository)
        {
            roomRepository = _roomRepository;
        }
    }
}