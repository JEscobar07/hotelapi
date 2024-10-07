using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotelapi.Models;

namespace hotelapi.Repositories
{
    public interface IGuestRepository
    {
        public Task Add(Guest Guest);
        public Task<IEnumerable<Guest>> GetAll();
        public Task<Guest> GetId(int id);
        public Task<bool> Delete(int id);
        public Task<IEnumerable<Guest>> Getkeyword(string keyword);
        public Task<Guest> Update(int id, Guest guest);
        public Task<bool> CheckExistence(string identication_number);
    }
}