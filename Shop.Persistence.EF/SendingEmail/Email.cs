using FluentEmail.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;

namespace Shop.Persistence.EF.SendingEmail
{
    public class Email : IEmail
    {
        private readonly IOptions<EmailAppSettingsConfig> _config;

        public Email(IOptions<EmailAppSettingsConfig> config)
        {
            _config = config;
        }
        public async Task SendEmail(MessageParams messageParams)
        {
            SmtpClient smtpClient = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = _config.Value.UserName,
                    Password = _config.Value.Password
                }
            };
            MailAddress FromEmail = new MailAddress("MyShopKamil94@gmail.com", "MyShop");
            MailAddress ToEmail = new MailAddress(messageParams.Email, messageParams.Name);
            MailMessage message = new MailMessage()
            {
                From = FromEmail,
                Subject = messageParams.Subcject,
                Body = messageParams.Text,
            };
            message.To.Add(ToEmail);

            await smtpClient.SendMailAsync(message);

        }
    }
}
