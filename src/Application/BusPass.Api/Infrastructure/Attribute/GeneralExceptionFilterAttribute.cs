using BusPass.Api.Models.ViewModels;
using BusPass.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BusPass.Api.Infrastructure.Attribute
{
    public class GeneralExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="logHelperFactory"></param>
        public GeneralExceptionFilterAttribute(ILogger<GeneralExceptionFilterAttribute> logger)
        {
            _logger = logger;
        }

        private ILogger<GeneralExceptionFilterAttribute> _logger;

        /// <summary>
        ///
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            var model = GetExceptionFailResultViewModel(context.HttpContext.Request.Path,
                context.HttpContext.Request.Method, context.Exception);

            context.Result = new ObjectResult(model)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
            context.ExceptionHandled = true;

            //if (context.Exception is FluentValidationException)
            //{
            //    return;
            //}
            _logger.LogError(context.Exception, "some error happened.");
        }

        private static FailResultViewModel GetExceptionFailResultViewModel(string path, string method, Exception exception)
        {
            var ex = exception as BaseException;
            var errCode = ex?.Code ?? 500;
            var description = ex?.Description ?? "some error happened.";
            var message = ex?.Message ?? exception.Message;

            var model = new FailResultViewModel()
            {
                Version = "v1.0",
                Status = "Error",
                Method = $"{path}.{method}",
                ErrorCode = errCode,
                Description = description,
                Message = message
            };

            return model;
        }
    }
}