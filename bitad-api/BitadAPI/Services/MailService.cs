using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.IO;
using System.Text;
using MimeKit.Utils;

namespace BitadAPI.Services
{
    public class MailInfo
    {
        public string Receiver { get; set; }
        public string ReceiverAddress { get; set; }
        public string Subject { get; set; }
        public string TaskType { get; set; }
        public string TemplateFileName { get; set; }
        public string Code { get; set; }
    }
    public interface IMailService
    {
        public Task SendActivationMail(string address, string activationCode, string receiver);
        public Task SendPasswordResetMail(string address, string resetCode, string receiver);
        public Task SendConfirmationMail(string address, string confirmCode, string receiver);
    }
    public class MailService : IMailService
    {
        private string _emailAddress;
        private string _emailPassword;
        private string _serverUrl;
        private string _smtpServer;
        private string _emailLogin;
        public MailService()
        {
            _emailAddress = Environment.GetEnvironmentVariable("EMAIL_ADDRESS");
            _emailPassword = Environment.GetEnvironmentVariable("EMAIL_PASSWORD");
            _serverUrl = Environment.GetEnvironmentVariable("SERVER_URL");
            _smtpServer = Environment.GetEnvironmentVariable("SMTP_SERVER");
            _emailLogin = Environment.GetEnvironmentVariable("EMAIL_LOGIN");
        }

        public async Task SendActivationMail(string address, string activationCode, string receiver)
        {
            var mailInfo = new MailInfo
            {
                Receiver = receiver,
                Code = activationCode,
                ReceiverAddress = address,
                Subject = "Aktywacja konta Bitad2021",
                TaskType = "account-activation",
                TemplateFileName = "index.html"
            };
            var message = CreateMessage(mailInfo);
            await SendMail(message);

        }
        
        public async Task SendConfirmationMail(string address, string confirmCode, string receiver)
        {
            var mailInfo = new MailInfo
            {
                Receiver = receiver,
                Code = confirmCode,
                ReceiverAddress = address,
                Subject = "Potwierdzenie obecności na Bitad2021",
                TaskType = "account-confirm",
                TemplateFileName = "index_confirm.html"
            };
            var message = CreateMessage(mailInfo);
            await SendMail(message);

        }
        
        public async Task SendPasswordResetMail(string address, string resetCode, string receiver)
        {
            var mailInfo = new MailInfo
            {
                Receiver = receiver,
                Code = resetCode,
                ReceiverAddress = address,
                Subject = "Resetowanie hasła konta Bitad2021",
                TaskType = "password-reset",
                TemplateFileName = "index_password.html"
            };
            var message = CreateMessage(mailInfo);
            await SendMail(message);

        }

        private async Task SendMail(MimeMessage message)
        {
            using (var client = new SmtpClient()) {
                await client.ConnectAsync (_smtpServer, 587, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync (_emailLogin, _emailPassword);

                await client.SendAsync(message);

                await client.DisconnectAsync (true);
            }
        }

        private MimeMessage CreateMessage(MailInfo info)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Bitad2021", _emailAddress));
            message.To.Add(new MailboxAddress(info.Receiver, info.ReceiverAddress));
            message.Subject = info.Subject;
            string FullFormatPath = "/app/bitad-email-template";

            string HtmlFormat = string.Empty;

            var builder = new BodyBuilder();

            using (FileStream fs = new FileStream(Path.Combine(FullFormatPath, info.TemplateFileName), FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    HtmlFormat = sr.ReadToEnd();
                }
            }
            HtmlFormat = HtmlFormat.Replace("USER_NAME", info.Receiver);
            HtmlFormat = HtmlFormat.Replace("ACTIVITY_LINK", $"{_serverUrl}/{info.TaskType}/{info.Code}");
            builder.HtmlBody = HtmlFormat;

            message.Body = builder.ToMessageBody();
            return message;
        }
    }
}