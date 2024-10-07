using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotelapi.Models;

namespace hotelapi.Repositories
{
    public interface IBookingRepository
    {
        public Task<IEnumerable<Booking>> GetIdentificationNumber(string identificationNumber);
        public Task<Booking> GetId(int id);
        public Task Add(Booking Booking);
        public Task<bool> Delete(int id);
        public Task<bool> CheckAvailable(int roomId);

    }
}