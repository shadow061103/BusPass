using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusPass.Repository.Models.Api
{
    public class BusStation
    {
        /// <summary>
        /// 站位唯一識別代碼，規則為 {業管機關簡碼} + {StationID}，其中 {業管機關簡碼}
        /// </summary>
        public string StationUID { get; set; }

        /// <summary>
        /// 站位代碼
        /// </summary>
        public string StationID { get; set; }

        /// <summary>
        ///	站位名稱
        /// </summary>
        public NameDescription StationName { get; set; }

        /// <summary>
        /// 站位位置
        /// </summary>
        public StationPosition StationPosition { get; set; }

        /// <summary>
        /// 站位地址
        /// </summary>
        public string StationAddress { get; set; }

        /// <summary>
        ///
        /// </summary>
        public List<BusSimpleStop> Stops { get; set; }

        /// <summary>
        ///站牌位置縣市之代碼(國際ISO 3166-2 三碼城市代碼)
        /// </summary>
        public string LocationCityCode { get; set; }

        /// <summary>
        ///方位角，E:東行;W:西行;S:南行;N:北行;SE:東南行;NE:東北行;SW:西南行;NW:西北行
        /// </summary>
        public string Bearing { get; set; }

        /// <summary>
        ///資料更新日期時間(ISO8601格式:yyyy-MM-ddTHH:mm:sszzz)
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}