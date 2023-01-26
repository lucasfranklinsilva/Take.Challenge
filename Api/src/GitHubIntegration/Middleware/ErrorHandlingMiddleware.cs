using Lime.Protocol;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GithubIntegration.Facades.Strategies.ExceptionHandlingStrategies;

namespace GithubIntegration.Middleware
{
    /// <summary>
    /// Wraps all controller actions with a try-catch latch to avoid code repetition
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Dictionary<Type, ExceptionHandlingStrategy> _exceptionHandling;

        #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public ErrorHandlingMiddleware(RequestDelegate next, Dictionary<Type, ExceptionHandlingStrategy> exceptionHandling)
        {
            _next = next;
            _exceptionHandling = exceptionHandling;
        }
        #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        /// <summary>
        /// Invoke Method, to validate requisition errors
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.EnableBuffering();

            using (var reader = new StreamReader(context.Request.Body, leaveOpen: true))
            {
                context.Request.Body.Position = default;
            }
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (_exceptionHandling.TryGetValue(exception.GetType(), out var handler))
            {
                context = await handler.HandleAsync(context, exception);
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }

            context.Response.ContentType = MediaType.ApplicationJson;
            await context.Response.WriteAsync(JsonConvert.SerializeObject($"{exception.Message}| traceId: {context.TraceIdentifier}"));
        }
    }
}
