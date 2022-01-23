using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusPass.Repository.Models.Entities
{
    public class BusSubRouteOperator
    {
        /// <summary>
        /// 附屬路線唯一識別代碼
        /// </summary>
        public long SubRouteID { get; set; }

        /// <summary>
        /// 營運業者代碼
        /// </summary>
        public long OperatorID { get; set; }
    }
}