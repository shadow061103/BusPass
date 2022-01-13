using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusPass.Repository.Models.Api
{
    public class StopPosition
    {
        /// <summary>
        /// 位置經度
        /// </summary>
        public float PositionLon { get; set; }

        /// <summary>
        /// 位置緯度
        /// </summary>
        public float PositionLat { get; set; }

        /// <summary>
        /// 地理空間編碼
        /// </summary>
        public string GeoHash { get; set; }
    }
}