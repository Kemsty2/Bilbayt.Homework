using Bilbayt.Homework.Api.Domain.Models;
using System;
using System.Security.Claims;

namespace Bilbayt.Homework.Api.Service.Contract
{
    public interface IJwtAuthService
    {
        /// <summary>
        /// Generate the accessToken and refreshToken for an authenticated user
        /// </summary>
        /// <param name="username">username of the user, to identify the refresh token</param>
        /// <param name="claims">claims of the user</param>
        /// <param name="now">Exact now datime, pass when the user logged in</param>
        /// <returns></returns>
        JwtResult GenerateTokens(string username, Claim[] claims, DateTime now);
    }
}