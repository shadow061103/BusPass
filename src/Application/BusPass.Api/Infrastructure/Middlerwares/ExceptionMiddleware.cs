using BusPass.Api.Models.ViewModels;
using BusPass.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Text.Json;

namespace BusPass.Api.Infrastructure.Middlerwares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        ///
        /// </summary>
        /// <param name="next"></param>
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var ex = exception as BaseException;
            var errCode = ex?.Code ?? 500;
            var description = ex?.Description ?? "some error happened.";
            var message = ex?.Message ?? exception.Message;

            var model = new FailResultViewModel()
            {
                Version = "v1.0",
                Status = "Error",
                Method = $"{context.Request.Path}.{context.Request.Method}",
                ErrorCode = errCode,
                Description = description,
                Message = message
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(model));
        }
    }
}