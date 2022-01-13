using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusPass.Repository.Models.Api
{
    public class BusSimpleStop
    {
        /// <summary>
        /// 站牌唯一識別代碼，規則為 {業管機關簡碼} + {StopID}
        /// </summary>
        public string StopUID { get; set; }

        /// <summary>
        /// 地區既用中之站牌代碼(為原資料內碼)
        /// </summary>
        public string StopID { get; set; }

        /// <summary>
        ///
        /// </summary>
        public NameDescription StopName { get; set; }

        /// <summary>
        /// 路線唯一識別代碼，規則為 {業管機關簡碼} + {RouteID}
        /// </summary>
        public string RouteUID { get; set; }

        /// <summary>
        ///地區既用中之路線代碼(為原資料內碼)
        /// </summary>
        public string RouteID { get; set; }

        /// <summary>
        ///路線名稱
        /// </summary>
        public NameDescription RouteName { get; set; }
    }
}