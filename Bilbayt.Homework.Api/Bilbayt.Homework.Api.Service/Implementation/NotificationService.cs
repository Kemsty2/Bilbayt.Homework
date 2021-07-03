using Bilbayt.Homework.Api.Domain.Common;
using Bilbayt.Homework.Api.Service.Contract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Bilbayt.Homework.Api.Service.Implementation
{
    public class NotificationService : INotificationService
    {
        private readonly ISendGridClient _client;
        private readonly IConfiguration _configuration;
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(ISendGridClient client, IConfiguration configuration, ILogger<NotificationService> logger)
        {
            _client = client;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task SendMail(EmailRequest request)
        {
            try
            {
                var msg = new SendGridMessage()
                {
                    From = new EmailAddress(_configuration[$"{Constants.SendGridSettingsSectionName}:SenderEmail"], _configuration[$"{Constants.SendGridSettingsSectionName}:SenderName"]),
                    Subject = request.Subject
                };
                msg.SetTemplateId(_configuration[$"{Constants.SendGridSettingsSectionName}:TemplateId"]);
                msg.SetTemplateData(new
                {
                    first_name = request.EmailToName.Split(" ")[0]
                });
                msg.AddTo(request.EmailTo, request.EmailToName);

                var response = await _client.SendEmailAsync(msg);
                _logger.LogInformation("Email Send {0}", response.StatusCode);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Email {0} not send", JsonConvert.SerializeObject(request));
            }
        }
    }
}