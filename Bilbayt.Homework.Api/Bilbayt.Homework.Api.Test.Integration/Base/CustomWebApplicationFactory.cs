using Bilbayt.Homework.Api.Persistence.Repositories.Contracts;
using Bilbayt.Homework.Api.Test.Integration.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace Bilbayt.Homework.Api.Test.Integration.Base
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = new ServiceDescriptor(typeof(IMongoRepository<>), typeof(FakeMongoRepository<>),
                    ServiceLifetime.Scoped);

                services.Replace(descriptor);
            });
        }

        protected override IHostBuilder CreateHostBuilder() =>
            base.CreateHostBuilder()
                .ConfigureHostConfiguration(
                    config => config.AddInMemoryCollection(new Dictionary<string, string> { ["ASPNETCORE_ENVIRONMENT"] = "Test" }));
    }
}