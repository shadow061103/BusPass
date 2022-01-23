using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusPass.Repository.Models.Entities
{
    public class BusRouteOperator
    {
        /// <summary>
        /// 路線唯一識別碼
        /// </summary>
        public long RouteId { get; set; }

        /// <summary>
        /// 營運業者代碼
        /// </summary>
        public long OperatorId { get; set; }
    }
}