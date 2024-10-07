using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotelapi.Models;

namespace hotelapi.Repositories
{
    public interface IRoomRepository
    {
        public Task Add(Room product);
        public Task<Room> Update(int id, Room product);
        public Task<bool> Delete(int id);
        public Task<IEnumerable<Room>> GetAvailable();
    }
}