using System.Threading.Tasks;
using Bilbayt.Homework.Api.Domain.Common;

namespace Bilbayt.Homework.Api.Service.Contract
{
    public interface INotificationService
    {
        Task SendMail(EmailRequest request);
    }
}