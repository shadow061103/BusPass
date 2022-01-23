using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusPass.Repository.Models.Api
{
    public class PtxBusStop
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
        /// 業管機關代碼
        /// </summary>
        public string AuthorityID { get; set; }

        /// <summary>
        /// 站牌名稱
        /// </summary>
        public PtxNameDescription StopName { get; set; }

        /// <summary>
        /// 站牌位置
        /// </summary>
        public PtxStopPosition StopPosition { get; set; }

        /// <summary>
        ///站牌地址
        /// </summary>
        public string StopAddress { get; set; }

        /// <summary>
        ///方位角，E:東行;W:西行;S:南行;N:北行;SE:東南行;NE:東北行;SW:西南行;NW:西北行
        /// </summary>
        public string Bearing { get; set; }

        /// <summary>
        ///站牌所屬的站位ID
        /// </summary>
        public string StationID { get; set; }

        /// <summary>
        ///站牌權管所屬縣市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        ///站牌權管所屬縣市之代碼(國際ISO 3166-2 三碼城市代碼)[若為公路/國道客運路線則為空值]
        /// </summary>
        public string CityCode { get; set; }

        /// <summary>
        ///站牌位置縣市之代碼(國際ISO 3166-2 三碼城市代碼)[若為公路/國道客運路線則為空值]
        /// </summary>
        public string LocationCityCode { get; set; }

        /// <summary>
        ///資料更新日期時間(ISO8601格式:yyyy-MM-ddTHH:mm:sszzz)
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}