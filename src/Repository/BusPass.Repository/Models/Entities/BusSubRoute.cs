using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusPass.Repository.Models.Entities
{
    public class BusSubRoute
    {
        /// <summary>
        /// 附屬路線唯一識別代碼
        /// </summary>
        public long SubRouteID { get; set; }

        /// <summary>
        /// 附屬路線名稱
        /// </summary>
        public string SubRouteName { get; set; }

        /// <summary>
        /// 去返程 : [0:'去程',1:'返程',2:'迴圈',255:'未知']
        /// </summary>
        public int? Direction { get; set; }

        /// <summary>
        /// 平日第一班發車時間
        /// </summary>
        public string FirstBusTime { get; set; }

        /// <summary>
        /// 平日返程第一班發車時間
        /// </summary>
        public string LastBusTime { get; set; }

        /// <summary>
        /// 假日去程第一班發車時間
        /// </summary>
        public string HolidayFirstBusTime { get; set; }

        /// <summary>
        /// 假日返程第一班發車時間
        /// </summary>
        public string HolidayLastBusTime { get; set; }

        /// <summary>
        ///公車路線ID
        /// </summary>
        public long? RouteId { get; set; }

        /// <summary>
        /// 營運業者代號
        /// </summary>
        public List<long> OperatorIds { get; set; }
    }
}