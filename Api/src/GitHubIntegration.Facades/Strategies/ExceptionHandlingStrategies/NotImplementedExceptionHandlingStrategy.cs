using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace GithubIntegration.Facades.Strategies.ExceptionHandlingStrategies
{
    public class NotImplementedExceptionHandlingStrategy : ExceptionHandlingStrategy
    {
        public override async Task<HttpContext> HandleAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = StatusCodes.Status501NotImplemented;
            return await Task.FromResult(context);
        }
    }
}
