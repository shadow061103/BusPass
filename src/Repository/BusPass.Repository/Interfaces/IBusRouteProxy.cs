using BusPass.Repository.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusPass.Repository.Interfaces
{
    public interface IBusRouteProxy
    {
        Task<List<BusRoute>> GetRouteAsync(string city);
    }
}