using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RestEase;

namespace GithubIntegration.Facades.Strategies.ExceptionHandlingStrategies
{
    public class ApiExceptionHandlingStrategy : ExceptionHandlingStrategy
    {
        public override async Task<HttpContext> HandleAsync(HttpContext context, Exception exception)
        {
            var apiException = exception as ApiException;
            context.Response.StatusCode = (int)apiException.StatusCode;

            return await Task.FromResult(context);
        }
    }
}
