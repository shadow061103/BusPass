using BusPass.Repository.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusPass.Repository.Interfaces
{
    public interface IBusSubRouteRepositoey
    {
        Task<int> AddAsync(BusSubRoute busSubRoute);

        Task<int> AddAsync(IEnumerable<BusSubRoute> busSubRoutes);
    }
}