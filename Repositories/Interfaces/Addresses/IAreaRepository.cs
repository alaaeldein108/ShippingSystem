using Data.Entities.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.Addresses
{
    public interface IAreaRepository
    {
        Task<Area> GetAreaById(string code);
        Task<IQueryable<Area>> GetAllAreaAsync();
    }
}
