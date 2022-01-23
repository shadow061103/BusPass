using BusPass.Repository.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusPass.Repository.Interfaces
{
    public interface IBusRouteRelationRepository
    {
        Task<int> AddAsync(IEnumerable<BusRouteOperator> relations);

        Task<int> AddAsync(IEnumerable<BusSubRouteOperator> relations);
    }
}