using Bilbayt.Homework.Api.Test.Integration.Base;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;

namespace Bilbayt.Homework.Api.Test.Integration.Common
{
    public static class WebApplicationFactoryExtensions
    {
        public static HttpClient SetupClient(this CustomWebApplicationFactory<Startup> fixture)
        {
            var options = new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            };

            return fixture.CreateClient(options);
        }
    }
}