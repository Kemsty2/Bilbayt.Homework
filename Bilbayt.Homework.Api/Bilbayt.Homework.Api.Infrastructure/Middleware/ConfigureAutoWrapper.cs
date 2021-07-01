using AutoWrapper;
using Microsoft.AspNetCore.Builder;

namespace Bilbayt.Homework.Api.Infrastructure.Middleware
{
    public static class ConfigureAutoWrapper
    {
        public static void UseAutoWrapper(this IApplicationBuilder app)
        {
            app.UseApiResponseAndExceptionWrapper(new AutoWrapperOptions
            {
                ShouldLogRequestData = false,
                UseApiProblemDetailsException = false,
                EnableResponseLogging = false,
                EnableExceptionLogging = false,
                IsApiOnly = false
            });
        }
    }
}