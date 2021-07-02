using Bilbayt.Homework.Api.Domain.Entities;
using Bilbayt.Homework.Api.Domain.Models;
using Bilbayt.Homework.Api.Persistence.Repositories.Contracts;
using Bilbayt.Homework.Api.Service.Contract;
using Bilbayt.Homework.Api.Service.Features.AccountFeatures.Dtos;
using MediatR;
using System;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Bilbayt.Homework.Api.Service.Features.AccountFeatures.Queries
{
    public class LoginUserQuery : IRequest<JwtResult>
    {
        public LoginDto Dto { get; set; }

        public LoginUserQuery(LoginDto dto)
        {
            Dto = dto;
        }

        public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, JwtResult>
        {
            private readonly IMongoRepository<User> _userRepository;
            private readonly IJwtAuthService _jwtAuthService;

            public LoginUserQueryHandler(IMongoRepository<User> userRepository, IJwtAuthService jwtAuthService)
            {
                _userRepository = userRepository;
                _jwtAuthService = jwtAuthService;
            }

            public async Task<JwtResult> Handle(LoginUserQuery request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.FindOneAsync(x => x.UserName == request.Dto.UserName);
                if (user == null)
                    throw new AuthenticationException("Invalid UserName or Password");

                if (!IsVerifyPassword(request.Dto.Password, user.Password))
                    throw new AuthenticationException("Invalid UserName or Password");

                return _jwtAuthService.GenerateTokens(user.UserName, GetClaims(user), DateTime.Now);
            }

            #region Private Methods

            private static bool IsVerifyPassword(string clearTextPassword, string hashPassword)
            {
                return BCrypt.Net.BCrypt.Verify(clearTextPassword, hashPassword);
            }

            private static Claim[] GetClaims(User user)
            {
                return new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.UserName)
                };
            }

            #endregion Private Methods
        }
    }
}