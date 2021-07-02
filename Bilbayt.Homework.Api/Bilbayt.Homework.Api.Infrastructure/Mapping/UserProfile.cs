using AutoMapper;
using Bilbayt.Homework.Api.Domain.Entities;
using Bilbayt.Homework.Api.Infrastructure.ViewModel;

namespace Bilbayt.Homework.Api.Infrastructure.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}