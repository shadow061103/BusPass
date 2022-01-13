using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusPass.Api.Infrastructure.Middlerwares
{
    /// <summary>
    /// Middleware Extensions
    /// </summary>
    public static class MiddlewareExtensions
    {
        /// <summary>
        /// 使用 HousePrice Exception handler
        /// </summary>
        /// <param name="app"></param>
        public static void UseExceptionhandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}