using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotelapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace hotelapi.Controllers.v1.guests
{
    [ApiController]
    [Route("api/v1/guests/[controller]")]
    public class GuestsController : ControllerBase
    {
        protected readonly IGuestRepository GuestRepository;

        public GuestsController(IGuestRepository _GuestRepository)
        {
            GuestRepository = _GuestRepository;
        }
    }
}