using BusPass.Repository.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusPass.Repository.Interfaces
{
    public interface ICityBusProxy
    {
        /// <summary>
        /// 取得指定[縣市]的市區公車路線資料
        /// </summary>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        Task<List<BusRoute>> GetRouteAsync(string city);

        /// <summary>
        /// 取得指定[縣市]的市區公車站牌資料
        /// </summary>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        Task<List<BusStop>> GetBusStopAsync(string city);

        /// <summary>
        /// 取得指定[縣市]的市區公車站位資料
        /// </summary>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        Task<List<BusStation>> GetBusStationAsync(string city);
    }
}