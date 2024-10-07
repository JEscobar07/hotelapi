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
    public class BookingServices : IBookingRepository
    {
        private readonly AppDbContext context;

        public BookingServices(AppDbContext _context)
        {
            context = _context;
        }
        
        public async Task<IEnumerable<Booking>> GetIdentificationNumber(string identification_number)
        {
             return await context.Bookings.Include(r => r.Guest).Where(g => g.Guest.IdentificationNumber.Contains(identification_number)).ToListAsync();
        }

        public async Task<Booking> GetId(int id)
        {
            return await context.Bookings.Include(p => p.Employee).Include(p => p.Guest).Include(p => p.Room).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task Add(Booking Booking)
        {
            await context.Bookings.AddAsync(Booking);
            await context.SaveChangesAsync();
        }
        
        public async Task<bool> Delete(int id)
        {
            var bookingFound = await context.Bookings.FindAsync(id);
            if (bookingFound != null)
            {
                context.Bookings.Remove(bookingFound);
                await context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> CheckAvailable(int roomId)
        {
            return await context.Bookings.Include(r => r.Room).AnyAsync(b => b.RoomId == roomId && b.Room.Availability == true);
        }
        

    }
}