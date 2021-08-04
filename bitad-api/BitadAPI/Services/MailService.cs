using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace BitadAPI.Services
{
    public interface IMailService
    {
        public Task SendActivationMail(string address, string activationCode, string receiver);
    }
    public class MailService : IMailService
    {
        
        public MailService()
        {
        }
        
        public async Task SendActivationMail(string address, string activationCode, string receiver)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Bitad2021", "io2020ksf@gmail.com"));
            message.To.Add(new MailboxAddress(receiver, address));
            message.Subject = "Aktywacja konta Bitad2021";
            var text = $"http://localhost:8080/User/ActivateAccount?activationCode={activationCode}";
            message.Body = new TextPart("plain"){ Text = text };
            
            using (var client = new SmtpClient()) {
                await client.ConnectAsync ("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
                await client.AuthenticateAsync ("io2020ksf@gmail.com", "iofirebase2020");

                await client.SendAsync(message);

                await client.DisconnectAsync (true);
            }

        }
    }
}