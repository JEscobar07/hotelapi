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
    public class GuestServices : IGuestRepository
    {
        private readonly AppDbContext context;

        public GuestServices(AppDbContext _context)
        {
            context = _context;
        }

        public async Task Add(Guest Guest)
        {
            await context.Guests.AddAsync(Guest);
            await context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var guestFound = await context.Guests.FindAsync(id);
            if (guestFound != null)
            {
                context.Guests.Remove(guestFound);
                await context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Guest>> GetAll()
        {
            return await context.Guests.ToListAsync();
        }

        public async Task<Guest> GetId(int id)
        {
            return await context.Guests.FindAsync(id);
        }

        public async Task<IEnumerable<Guest>> Getkeyword(string keyword)
        {
            return await context.Guests.Where(g => g.FirstName.Contains(keyword) || g.Email.Contains(keyword) || g.LastName.Contains(keyword)).ToListAsync();
        }

        public async Task<Guest> Update(int id, Guest guest)
        {
            var guestFound = await context.Guests.FindAsync(id);
            if (guestFound != null)
            {
                guestFound.FirstName = guest.FirstName;
                guestFound.LastName = guest.LastName;
                guestFound.Email = guest.Email;
                guestFound.IdentificationNumber = guest.IdentificationNumber;
                guestFound.PhoneNumber = guest.PhoneNumber;
                guestFound.Birthdate = guest.Birthdate;
                await context.SaveChangesAsync();
                return guestFound;
            }
            else
            {
                return guestFound;
            }
        }

        public async Task<bool> CheckExistence(string identification_number)
        {
            return await context.Guests.AnyAsync(p => p.IdentificationNumber == identification_number );
        }
    }
}