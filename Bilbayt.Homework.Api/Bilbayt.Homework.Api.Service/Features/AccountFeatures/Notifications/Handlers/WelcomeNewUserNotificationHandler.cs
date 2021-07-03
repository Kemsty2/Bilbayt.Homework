using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Bilbayt.Homework.Api.Domain.Common;
using Bilbayt.Homework.Api.Service.Contract;
using Microsoft.Extensions.Logging;
using Polly;

namespace Bilbayt.Homework.Api.Service.Features.AccountFeatures.Notifications.Handlers
{
    public class WelcomeNewUserNotificationHandler : INotificationHandler<UserRegisteredNotification>
    {
        private readonly INotificationService _notificationService;
        private readonly ILogger<WelcomeNewUserNotificationHandler> _logger;

        public WelcomeNewUserNotificationHandler(INotificationService notificationService, ILogger<WelcomeNewUserNotificationHandler> logger)
        {
            _notificationService = notificationService;
            _logger = logger;
        }

        public async Task Handle(UserRegisteredNotification notification, CancellationToken cancellationToken)
        {
            const string welcomeSubject = "Welcome to Bilbayt Homework";
            const string welcomeMessage = "Welcome to Bilbayt Homework";

            var policy = GetPollyPolicy();
            await policy.Execute(async () =>
            {
                await _notificationService.SendMail(new EmailRequest()
                {
                    EmailToName = notification.User.FullName,
                    EmailTo = notification.User.UserName,
                    Content = welcomeMessage,
                    Subject = welcomeSubject
                });
            });
        }

        #region Private Methods

        private Policy GetPollyPolicy(int retryCount = 2)
        {
            return Policy.Handle<Exception>().Retry(retryCount, (exception, retryCount, context) =>
            {
                _logger.LogError(exception, $"Polly Retry {context["methodName"]} {retryCount}");
            });
        }

        #endregion Private Methods
    }
}