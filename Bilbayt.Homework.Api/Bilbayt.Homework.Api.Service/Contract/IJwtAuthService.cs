using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Bilbayt.Homework.Api.Domain.Models;

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

        /// <summary>
        ///
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <param name="accessToken"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        JwtResult RefreshToken(string refreshToken, string accessToken, DateTime now);

        /// <summary>
        ///
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        (ClaimsPrincipal principal, JwtSecurityToken token) DecodeJwtToken(string token);

        /// <summary>
        ///
        /// </summary>
        /// <param name="now"></param>
        void RemoveExpiredRefreshTokens(DateTime now);

        /// <summary>
        ///
        /// </summary>
        /// <param name="userName"></param>
        void RemoveRefreshTokenByUserName(string userName);
    }
}