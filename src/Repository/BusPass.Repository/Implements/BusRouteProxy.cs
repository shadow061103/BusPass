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
    public class BusRouteProxy : IBusRouteProxy
    {
        private readonly IApiHelper _apiHelper;

        public BusRouteProxy(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<BusRoute>> GetRouteAsync(string city)
        {
            var url = string.Format(PfxUrl.CityRouteUrl, city);
            var result = await _apiHelper.GetPTXAsync<List<BusRoute>>(url);
            return result;
        }
    }
}