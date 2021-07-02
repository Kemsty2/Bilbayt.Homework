using Bilbayt.Homework.Api.Domain.Models;
using Bilbayt.Homework.Api.Domain.Settings;
using Bilbayt.Homework.Api.Service.Contract;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bilbayt.Homework.Api.Service.Implementation
{
    /// <summary>
    /// Class to handle all jwt operation
    /// </summary>
    public class JwtAuthService : IJwtAuthService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly byte[] _secret;

        public JwtAuthService(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
            _secret = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="username"></param>
        /// <param name="claims"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        public JwtResult GenerateTokens(string username, Claim[] claims, DateTime now)
        {
            var jwtToken = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: now.AddMinutes(_jwtSettings.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_secret), SecurityAlgorithms.HmacSha256Signature));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return new JwtResult
            {
                AccessToken = accessToken
            };
        }
    }
}