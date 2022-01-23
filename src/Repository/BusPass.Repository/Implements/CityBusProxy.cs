using BusPass.Common.Constants;
using BusPass.Repository.Infrastructure.Helpers;
using BusPass.Repository.Interfaces;
using BusPass.Repository.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusPass.Repository.Implements
{
    public class CityBusProxy : ICityBusProxy
    {
        private readonly IApiHelper _apiHelper;

        public CityBusProxy(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        /// <summary>
        /// 取得指定[縣市]的市區公車路線資料
        /// </summary>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        public async Task<List<PtxBusRoute>> GetRouteAsync(string city)
        {
            var url = string.Format(PfxUrl.CityBusRouteUrl, city);
            var result = await _apiHelper.GetPTXAsync<List<PtxBusRoute>>(url);
            return result;
        }

        /// <summary>
        /// 取得指定[縣市]的市區公車站牌資料
        /// </summary>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        public async Task<List<PtxBusStop>> GetBusStopAsync(string city)
        {
            var url = string.Format(PfxUrl.CityBusStopUrl, city);
            var result = await _apiHelper.GetPTXAsync<List<PtxBusStop>>(url);
            return result;
        }

        /// <summary>
        /// 取得指定[縣市]的市區公車站位資料
        /// </summary>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        public async Task<List<PtxBusStation>> GetBusStationAsync(string city)
        {
            var url = string.Format(PfxUrl.CityBusStationUrl, city);
            var result = await _apiHelper.GetPTXAsync<List<PtxBusStation>>(url);
            return result;
        }

        /// <summary>
        /// 取得指定[縣市]的市區公車營運業者資料
        /// </summary>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        public async Task<List<PtxOperator>> GetBusOperator(string city)
        {
            var url = string.Format(PfxUrl.CityBusOperatorUrl, city);
            var result = await _apiHelper.GetPTXAsync<List<PtxOperator>>(url);
            return result;
        }
    }
}