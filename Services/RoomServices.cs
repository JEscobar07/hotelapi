using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotelapi.Data;
using hotelapi.Models;
using hotelapi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace hotelapi.Services
{
    public class RoomServices : IRoomRepository
    {
        private readonly AppDbContext context;

        public RoomServices(AppDbContext _context)
        {
            context = _context;
        }

        public Task Add(Room product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Room>> GetAvailable()
        {
            return await context.Rooms.Where(r => r.Availability == true).ToListAsync();
        }

        public Task<Room> Update(int id, Room product)
        {
            throw new NotImplementedException();
        }
    }
}