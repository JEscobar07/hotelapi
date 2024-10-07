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
    public class RoomTypeServices : IRoomTypesRepository
    {
        private readonly AppDbContext context;

        public RoomTypeServices(AppDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<RoomType>> GetAll()
        {
            return await context.RoomTypes.ToListAsync();
        }

        public async Task<RoomType> GetId(int id)
        {
            return await context.RoomTypes.FindAsync(id);
        }
    }
}