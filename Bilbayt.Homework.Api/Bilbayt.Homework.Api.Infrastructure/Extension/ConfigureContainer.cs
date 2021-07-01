using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Serilog;

namespace Bilbayt.Homework.Api.Infrastructure.Extension
{
    public static class ConfigureContainer
    {
        public static void ConfigureSwagger(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();

            app.UseSwaggerUI(setupAction =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    setupAction.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });
        }

        public static void ConfigureSerilogRequestLogging(this IApplicationBuilder app)
        {
            app.UseSerilogRequestLogging();
        }
    }
}