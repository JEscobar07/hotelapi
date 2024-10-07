using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotelapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace hotelapi.Controllers.v1
{
    [ApiController]
    [Route("api/v1/roomTypes/[controller]")]
    public class RoomTypesController : ControllerBase
    {
        protected readonly IRoomTypesRepository roomTypesRepository;

        public RoomTypesController(IRoomTypesRepository _roomTypesRepository)
        {
            roomTypesRepository = _roomTypesRepository;
        }
    }
}