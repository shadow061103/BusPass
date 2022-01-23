using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusPass.Repository.Models.Entities
{
    public class BusRoute
    {
        /// <summary>
        /// 路線唯一識別碼
        /// </summary>
        public long RouteId { get; set; }

        /// <summary>
        /// 實際上是否有多條附屬路線
        /// </summary>
        public byte HasSubRoutes { get; set; }

        /// <summary>
        /// 公車路線類別 : [11:'市區公車',12:'公路客運',13:'國道客運',14:'接駁車']
        /// </summary>
        public int BusRouteType { get; set; }

        /// <summary>
        /// 路線名稱
        /// </summary>
        public string RouteName { get; set; }

        /// <summary>
        /// 起站中文名稱
        /// </summary>
        public string DepartureStop { get; set; }

        /// <summary>
        /// 終點站中文名稱
        /// </summary>
        public string DestinationStop { get; set; }

        /// <summary>
        /// 票價中文敘述
        /// </summary>
        public string TicketPriceDescription { get; set; }

        /// <summary>
        /// 收費緩衝區中文敘述
        /// </summary>
        public string FareBufferZoneDescription { get; set; }

        /// <summary>
        /// 路線簡圖網址
        /// </summary>
        public string RouteMapImageUrl { get; set; }

        /// <summary>
        /// 路線權管所屬縣市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 路線權管所屬縣市之代碼
        /// </summary>
        public string CityCode { get; set; }

        /// <summary>
        /// 更新時間
        /// </summary>
        public DateTime? UpdateTime { get; set; }
    }
}