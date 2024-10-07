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

        public Task Add(Room room)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Room>> GetAvailable()
        {
            return await context.Rooms.Include(r => r.RoomType).Where(r => r.Availability == true).ToListAsync();
        }

        public async Task<object> GetStatusCountRooms()
        {
            var rooms = await context.Rooms.ToListAsync();
            var occupiedCount = rooms.Count(r => !r.Availability);
            var availableCount = rooms.Count(r => r.Availability);

            var count = new
            {
                TotalRooms = rooms.Count,
                OccupiedRooms = occupiedCount,
                AvailableRooms = availableCount
            };
            return count;
        }

        public async Task<IEnumerable<Room>> GetAll()
        {
            return await context.Rooms.Include(r => r.RoomType).ToListAsync();
        }

        public async Task<Room> GetId(int id)
        {
            return await context.Rooms.Include(r => r.RoomType).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Room>> GetOccupied()
        {
            return await context.Rooms.Include(r => r.RoomType).Where(r => r.Availability == false).ToListAsync();
        }

    }
}