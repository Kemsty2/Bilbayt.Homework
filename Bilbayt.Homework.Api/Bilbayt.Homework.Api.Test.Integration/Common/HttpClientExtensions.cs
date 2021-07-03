using System.Net.Http;
using System.Net.Http.Headers;

namespace Bilbayt.Homework.Api.Test.Integration.Common
{
    public static class HttpClientExtensions
    {
        public static void SetClaimsViaHeader(this HttpClient client, Settings settings)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GenerateBearerToken(settings));
        }

        private static string GenerateBearerToken(Settings settings)
        {
            return "";
        }
    }
}