using LinkConverter.API.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;
using LinkConverter.API.Model.Exceptions;

namespace LinkConverter.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        static readonly ILogger Log = Serilog.Log.ForContext<ExceptionMiddleware>();
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

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

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var now = DateTime.UtcNow;
            Log.Error(ex, $"{now.ToString("HH:mm:ss")} : {ex}");
            return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorResultModel()
            {
                StatusCode = ex.GetHttpStatusCode(),
                Message = ex.Message
            }));
        }
    }
}
