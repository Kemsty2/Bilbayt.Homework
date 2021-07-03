using AutoMapper;
using Bilbayt.Homework.Api.Domain.Entities;
using Bilbayt.Homework.Api.Infrastructure.ViewModel;
using Bilbayt.Homework.Api.Service.Features.AccountFeatures.Commands;
using Bilbayt.Homework.Api.Service.Features.AccountFeatures.Dtos;
using Bilbayt.Homework.Api.Service.Features.AccountFeatures.Notifications;
using Bilbayt.Homework.Api.Service.Features.AccountFeatures.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// ReSharper disable All

namespace Bilbayt.Homework.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/accounts")]
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
        /// <param name="dto">Username and Password to authenticate</param>
        /// <response code="200">Returns the accessToken and refreshToken</response>
        /// <response code="400">return the bad request errors</response>
        /// <response code="401">Returns unauthorized when username or password is incorrect</response>
        /// <response code="500">internal server error</response>
        [HttpPost("login"), MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(LoginViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var loginResult = await Mediator.Send(new LoginUserQuery(dto));
            return Ok(new LoginViewModel(dto.UserName, loginResult.AccessToken));
        }

        /// <summary>
        /// Register new user informations (username, password, fullname)
        /// </summary>
        /// <param name="dto">Information about the user to register</param>
        /// <response code="200">Returns the registered user</response>
        /// <response code="400">return the bad request errors</response>
        /// <response code="409">return the reason of the conflit</response>
        /// <response code="500">internal server error</response>
        [HttpPost("signup"), MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(RegisterViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var user = await Mediator.Send(new RegisterUserCommand(dto));
            await Mediator.Publish(new UserRegisteredNotification() { User = user });

            return Created(new Uri("/api/accounts/profile", UriKind.Relative), _mapper.Map<User, UserViewModel>(user));
        }

        /// <summary>
        /// Get the profile of the authenticated user
        /// </summary>
        /// <response code="200">Returns the profile of the authenticated user</response>
        /// <response code="404">If the user is deleted or doesn't exist</response>
        /// <response code="500">internal server error</response>
        [HttpGet("profile"), MapToApiVersion("1.0")]
        [Authorize]
        [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<IActionResult> GetProfile()
        {
            var username = User.Identity?.Name;

            var user = await Mediator.Send(new GetUserProfileByUsernameQuery() { UserName = username });
            return Ok(_mapper.Map<User, UserViewModel>(user));
        }
    }
}