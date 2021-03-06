using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusPass.Repository.Models.Api
{
    /// <summary>
    /// 營運業者
    /// </summary>
    public class PtxOperator
    {
        /// <summary>
        ///營運業者代碼
        /// </summary>
        public string OperatorID { get; set; }

        /// <summary>
        ///
        /// </summary>
        public PtxNameDescription OperatorName { get; set; }

        /// <summary>
        ///營運業者連絡電話
        /// </summary>
        public string OperatorPhone { get; set; }

        /// <summary>
        ///營運業者網址鏈結
        /// </summary>
        public string OperatorUrl { get; set; }

        /// <summary>
        ///營運業者簡碼
        /// </summary>
        public string OperatorCode { get; set; }

        /// <summary>
        ///營運業者編號[交通部票證資料系統定義]
        /// </summary>
        public string OperatorNo { get; set; }
    }
}