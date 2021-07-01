using System.Threading.Tasks;
using AutoMapper;
using Bilbayt.Homework.Api.Domain.Models;
using Bilbayt.Homework.Api.Infrastructure.ViewModel;
using Bilbayt.Homework.Api.Service.Features.AccountFeatures.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        ///
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("signup"), MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(RegisterViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            return Ok();
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
        public async Task<IActionResult> Register([FromBody] RefreshTokenDto dto)
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