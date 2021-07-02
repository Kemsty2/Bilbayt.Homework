using Bilbayt.Homework.Api.Domain.Entities;
using MediatR;

namespace Bilbayt.Homework.Api.Service.Features.AccountFeatures.Notifications
{
    public class UserRegisteredNotification : INotification
    {
        public User User { get; set; }
    }
}