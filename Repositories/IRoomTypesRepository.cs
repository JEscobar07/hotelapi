using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotelapi.Models;

namespace hotelapi.Repositories
{
    public interface IRoomTypesRepository
    {
        public Task<IEnumerable<RoomType>> GetAll();
        public Task<RoomType> GetId(int id);  
    }
}