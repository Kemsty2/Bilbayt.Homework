using AutoMapper;
using Bilbayt.Homework.Api.Domain.Entities;
using Bilbayt.Homework.Api.Infrastructure.ViewModel;
using Bilbayt.Homework.Api.Service.Features.AccountFeatures.Commands;
using Bilbayt.Homework.Api.Service.Features.AccountFeatures.Dtos;
using Bilbayt.Homework.Api.Service.Features.AccountFeatures.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// ReSharper disable All

namespace Bilbayt.Homework.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/acconts")]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    public class AccountsController : BaseController
    {
        public AccountsController(IMapper mapper) : base(mapper)
        {
        }

        /// <summary>
        /// Authenticate a user by his username and password
        /// </summary>
        /// <returns></returns>
        [HttpPost("login"), MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(LoginViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            return Ok();
        }

        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="dto">Information about the user to register</param>
        /// <returns></returns>
        /// <response code="200">Returns the registered user</response>
        /// <response code="400">return the bad request errors</response>
        /// <response code="409">return the reason of the conflit</response>
        /// <response code="500">internal server error</response>
        [HttpPost("signup"), MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(RegisterViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var user = await Mediator.Send(new RegisterUserCommand(dto));
            //await Mediator.Publish(new UserRegisteredNotification() { User = user });

            return Ok(_mapper.Map<User, UserViewModel>(user));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("refresh-token"), MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(LoginViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto dto)
        {
            return Ok();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet("profile"), MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<IActionResult> GetProfile()
        {
            return Ok();
        }
    }
}