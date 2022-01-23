using BusPass.Repository.Models.Api;
using BusPass.Repository.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusPass.Repository.Interfaces
{
    public interface IBusRouteRepository
    {
        Task<int> AddAsync(BusRoute busRoute);

        Task<int> AddAsync(IEnumerable<BusRoute> busRoute);
    }
}