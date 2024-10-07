using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotelapi.Models;

namespace hotelapi.Repositories
{
    public interface IRoomRepository
    {
        public Task<IEnumerable<Room>> GetAvailable();
        public Task<object> GetStatusCountRooms(); 
        public Task<IEnumerable<Room>> GetAll();
        public Task<Room> GetId(int id);  
        public Task<IEnumerable<Room>> GetOccupied();
    }
}