using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusPass.Repository.Models.Api
{
    public class PtxSubRoute
    {
        /// <summary>
        ///附屬路線唯一識別代碼，規則為 {業管機關簡碼} + {SubRouteID}
        /// </summary>
        public string SubRouteUID { get; set; }

        /// <summary>
        ///地區既用中之附屬路線代碼(為原資料內碼)
        /// </summary>
        public string SubRouteID { get; set; }

        /// <summary>
        ///
        /// </summary>
        public PtxNameDescription SubRouteName { get; set; }

        /// <summary>
        ///去返程 : [0:'去程',1:'返程',2:'迴圈',255:'未知']
        /// </summary>
        public int Direction { get; set; }

        /// <summary>
        ///平日第一班發車時間
        /// </summary>
        public string FirstBusTime { get; set; }

        /// <summary>
        ///平日返程第一班發車時間
        /// </summary>
        public string LastBusTime { get; set; }

        /// <summary>
        ///假日去程第一班發車時間
        /// </summary>
        public string HolidayFirstBusTime { get; set; }

        /// <summary>
        ///假日返程第一班發車時間
        /// </summary>
        public string HolidayLastBusTime { get; set; }
    }
}