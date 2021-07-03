using Bilbayt.Homework.Api.Test.Integration.Common;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Xunit;

namespace Bilbayt.Homework.Api.Test.Integration.Base
{
    public class BaseClassFixture : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        protected readonly HttpClient Client;
        private readonly Settings _settings;

        protected BaseClassFixture(CustomWebApplicationFactory<Startup> factory)
        {
            Client = factory.SetupClient();
            factory.CreateClient();

            var config = new ConfigurationBuilder().AddJsonFile("./appsettings.Test.json").Build();
            _settings = config.GetSection("Settings").Get<Settings>();
        }

        protected void SetupClaimsViaHeaders()
        {
            Client.SetClaimsViaHeader(_settings);
        }
    }
}