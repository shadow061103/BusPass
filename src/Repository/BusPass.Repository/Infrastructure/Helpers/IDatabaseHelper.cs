using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusPass.Repository.Infrastructure.Helpers
{
    public interface IDatabaseHelper
    {
        /// <summary>
        /// 取得Hangfire資料庫
        /// </summary>
        /// <returns></returns>
        DbConnection GetHangfireConnection();

        /// <summary>
        /// 取得BusPass資料庫
        /// </summary>
        /// <returns></returns>
        DbConnection GetBusPassConnection();
    }
}