using Bilbayt.Homework.Api.Domain.Entities;
using Bilbayt.Homework.Api.Persistence.Repositories.Contracts;
using Bilbayt.Homework.Api.Service.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bilbayt.Homework.Api.Service.Features.AccountFeatures.Queries
{
    public class GetUserProfileByUsernameQuery : IRequest<User>
    {
        public string UserName { get; set; }

        public class GetUserProfileByUsernameQueryHandler : IRequestHandler<GetUserProfileByUsernameQuery, User>
        {
            private readonly IMongoRepository<User> _mongoRepository;

            public GetUserProfileByUsernameQueryHandler(IMongoRepository<User> mongoRepository)
            {
                _mongoRepository = mongoRepository;
            }

            public async Task<User> Handle(GetUserProfileByUsernameQuery request, CancellationToken cancellationToken)
            {
                var user = await _mongoRepository.FindOneAsync(x => x.UserName == request.UserName);
                if (user == null)
                    throw new NotFoundException("User", request.UserName);

                return user;
            }
        }
    }
}