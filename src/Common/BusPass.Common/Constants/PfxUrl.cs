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
        /// The route URL
        /// </summary>
        public static readonly string CityRouteUrl = "https://ptx.transportdata.tw/MOTC/v2/Bus/Route/City/{0}?$top=99999&$format=JSON";
    }
}