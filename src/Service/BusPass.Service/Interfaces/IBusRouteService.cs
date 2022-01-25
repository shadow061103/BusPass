using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusPass.Service.Interfaces
{
    public interface IBusRouteService
    {
        /// <summary>
        /// 新增公車路線/附屬路線資料
        /// </summary>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        Task<bool> AddBusRouteAsync(string city);

        /// <summary>
        /// 新增公車業者資料
        /// </summary>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        Task<bool> AddBusOperator(string city);
    }
}