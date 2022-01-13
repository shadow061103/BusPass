using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusPass.Common.Constants
{
    public class PfxUrl
    {
        /// <summary>
        /// 公車路線資料
        /// </summary>
        public static readonly string CityBusRouteUrl = "https://ptx.transportdata.tw/MOTC/v2/Bus/Route/City/{0}?$top=30&$format=JSON";

        /// <summary>
        /// 公車站牌資料
        /// </summary>
        public static readonly string CityBusStopUrl = "https://ptx.transportdata.tw/MOTC/v2/Bus/Stop/City/{0}?$top=30&$format=JSON";

        /// <summary>
        /// 公車站位資料
        /// </summary>
        public static readonly string CityBusStationUrl = "https://ptx.transportdata.tw/MOTC/v2/Bus/Station/City/{0}?$top=30&$format=JSON";
    }
}