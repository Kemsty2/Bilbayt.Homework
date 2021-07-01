using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Bilbayt.Homework.Api.Infrastructure.Filters
{
    public class ReplaceVersionWithExactValuePathFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var paths = new OpenApiPaths();
            foreach (var (key, value) in swaggerDoc.Paths)
            {
                paths.Add(key.Replace("{version}", swaggerDoc.Info.Version), value);
            }
            swaggerDoc.Paths = paths;
        }
    }
}