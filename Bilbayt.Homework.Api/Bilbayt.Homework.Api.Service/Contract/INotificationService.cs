using System.Threading.Tasks;

namespace Bilbayt.Homework.Api.Service.Contract
{
    public interface INotificationService
    {
        Task SendMail();
    }
}