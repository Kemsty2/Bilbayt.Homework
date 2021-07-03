using AutoWrapper.Server;
using Bilbayt.Homework.Api.Infrastructure.ViewModel;
using Bilbayt.Homework.Api.Service.Features.AccountFeatures.Dtos;
using Bilbayt.Homework.Api.Test.Integration.Base;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Bilbayt.Homework.Api.Test.Integration.Controllers
{
    public class AccountsControllerTests : BaseClassFixture

    {
        public AccountsControllerTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Trait("AccountsController", "Test if register endpoint sign up user")]
        [Fact(DisplayName = "POST /api/v1/accounts/signup 200 OK")]
        public async Task ShoudRegisterUser()
        {
            //  Arrange
            var body = new RegisterDto()
            {
                FullName = "Test",
                Password = "Test@test2024",
                UserName = "test@bilbayt.com"
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/v1.0/accounts/signup")
            {
                Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8,
                    "application/json")
            };

            //  Act
            var response = await Client.SendAsync(request);

            //  Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var content = await response.Content.ReadAsStringAsync();
            var result = Unwrapper.Unwrap<UserViewModel>(content);

            Assert.Equal(body.FullName, result.FullName);
            Assert.Equal(body.UserName, result.UserName);
        }

        [Trait("AccountsController", "Test if the register endpoint verify existing account before registration")]
        [Fact(DisplayName = "POST /api/v1/accounts/signup 409 Conflict")]
        public async Task ShoudNotRegisterUserEmailAlreadyTaken()
        {
            //  Arrange
            var body = new RegisterDto()
            {
                FullName = "Test",
                Password = "Test@test2024",
                UserName = "test@test.com"
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/v1.0/accounts/signup")
            {
                Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8,
                    "application/json")
            };

            //  Act
            var response = await Client.SendAsync(request);

            //  Assert
            response.StatusCode.Should().Be(HttpStatusCode.Conflict);
        }

        [Trait("AccountsController", "Test if the register endpoint verify request")]
        [Fact(DisplayName = "POST /api/v1/accounts/signup 400 Bad Request")]
        public async Task ShoudNotRegisterUserBadRequest()
        {
            //  Arrange
            var body = new RegisterDto()
            {
                FullName = "Test",
                Password = "Test",
                UserName = "test@test.com"
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/v1.0/accounts/signup")
            {
                Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8,
                    "application/json")
            };

            //  Act
            var response = await Client.SendAsync(request);

            //  Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Trait("AccountsController", "Test if login endpoint authenticate user")]
        [Fact(DisplayName = "POST /api/v1/accounts/login 200 OK")]
        public async Task ShouldLoginUser()
        {
            //  Arrange
            var body = new LoginDto()
            {
                Password = "Kingkemsty@2021",
                UserName = "test@test.com"
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/v1.0/accounts/login")
            {
                Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8,
                    "application/json")
            };

            //  Act
            var response = await Client.SendAsync(request);

            //  Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();
            var result = Unwrapper.Unwrap<LoginViewModel>(content);

            Assert.Equal(body.UserName, result.UserName);
            Assert.NotEmpty(result.AccessToken);
        }

        [Trait("AccountsController", "Test if login endpoint doest not authenticate user on bad request")]
        [Fact(DisplayName = "POST /api/v1/accounts/login 400 Bad Request")]
        public async Task ShouldNotLoginUserBadRequest()
        {
            //  Arrange
            var body = new LoginDto()
            {
                Password = "",
                UserName = "test@test.com"
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/v1.0/accounts/login")
            {
                Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8,
                    "application/json")
            };

            //  Act
            var response = await Client.SendAsync(request);

            //  Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Trait("AccountsController", "Test if login endpoint doest not authenticate user on invalid credentials")]
        [Fact(DisplayName = "POST /api/v1/accounts/login 401 Invalid")]
        public async Task ShouldNotLoginUserInvalidCredential()
        {
            //  Arrange
            var body = new LoginDto()
            {
                Password = "Kingkemsty@201",
                UserName = "test@test.com"
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/v1.0/accounts/login")
            {
                Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8,
                    "application/json")
            };

            //  Act
            var response = await Client.SendAsync(request);

            //  Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}