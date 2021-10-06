using Bilbayt.Homework.Api.Domain.Entities;
using Bilbayt.Homework.Api.Persistence.Repositories.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Bilbayt.Homework.Api.Service.Exceptions;
using Bilbayt.Homework.Api.Service.Features.AccountFeatures.Dtos;

namespace Bilbayt.Homework.Api.Service.Features.AccountFeatures.Commands
{
    public class RegisterUserCommand : IRequest<User>
    {
        public RegisterDto Dto { get; set; }

        public RegisterUserCommand(RegisterDto dto)
        {
            Dto = dto;
        }

        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
        {
            private readonly IMongoRepository<User> _userRepository;

            public RegisterUserCommandHandler(IMongoRepository<User> userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                //  Verify if the username is not already taken

                if (await _userRepository.IsExist(x => x.UserName == request.Dto.UserName))
                {
                    throw new ConflictException("UserName already exist, please choose another one");
                }

                var user = new User()
                {
                    UserName = request.Dto.UserName,
                    Password = HashPassword(request.Dto.Password),
                    FullName = request.Dto.FullName
                };

                await _userRepository.InsertOneAsync(user);

                return user;
            }

            #region Private Methods

            /// <summary>
            /// Hash clear text password using bcrypt algorithm
            /// </summary>
            /// <param name="password">the cleartext password to hash</param>
            /// <returns></returns>
            private static string HashPassword(string password)
            {
                return BCrypt.Net.BCrypt.HashPassword(password);
            }

            #endregion Private Methods
        }
    }
}