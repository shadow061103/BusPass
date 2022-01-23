using BusPass.Repository.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusPass.Repository.Interfaces
{
    public interface IBusOperatorRepository
    {
        Task<int> AddAsync(BusOperator busOperator);

        Task<int> AddAsync(IEnumerable<BusOperator> busOperators);
    }
}