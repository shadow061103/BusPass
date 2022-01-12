using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusPass.Repository.Models.Api
{
    public class BusRoute
    {
        /// <summary>
        /// 路線唯一識別代碼，規則為 {業管機關簡碼} + {RouteID}
        /// </summary>
        public string RouteUID { get; set; }

        /// <summary>
        /// 地區既用中之路線代碼(為原資料內碼)
        /// </summary>
        public string RouteID { get; set; }

        /// <summary>
        ///實際上是否有多條附屬路線
        /// </summary>
        public bool HasSubRoutes { get; set; }

        /// <summary>
        ///營運業者
        /// </summary>
        public Operator[] Operators { get; set; }

        /// <summary>
        /// 附屬路線資料
        /// </summary>
        public SubRoute[] SubRoutes { get; set; }

        /// <summary>
        ///公車路線類別 : [11:'市區公車',12:'公路客運',13:'國道客運',14:'接駁車']
        /// </summary>
        public int BusRouteType { get; set; }

        /// <summary>
        ///
        /// </summary>
        public NameDescription RouteName { get; set; }

        /// <summary>
        ///起站中文名稱
        /// </summary>
        public string DepartureStopNameZh { get; set; }

        /// <summary>
        ///終點站中文名稱
        /// </summary>
        public string DestinationStopNameZh { get; set; }

        /// <summary>
        ///票價中文敘述
        /// </summary>
        public string TicketPriceDescriptionZh { get; set; }

        /// <summary>
        ///路線簡圖網址
        /// </summary>
        public string RouteMapImageUrl { get; set; }

        /// <summary>
        ///路線權管所屬縣市(相當於市區公車API的City參數)[若為公路/國道客運路線則為空值]
        /// </summary>
        public string City { get; set; }

        /// <summary>
        ///路線權管所屬縣市之代碼(國際ISO 3166-2 三碼城市代碼)[若為公路/國道客運路線則為空值]
        /// </summary>
        public string CityCode { get; set; }

        /// <summary>
        /// 資料更新日期時間(ISO8601格式:yyyy-MM-ddTHH:mm:sszzz)
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}