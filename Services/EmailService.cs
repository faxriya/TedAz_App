using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;

namespace TedAzApp.Services
{
    public class EmailService
    {
        private static string appEmail = "pshapplication@rabita.az";
        private static string appEmailPass = "development#819";
        public static async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Site Administration", appEmail));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using(var client = new SmtpClient())
            {
                await client.ConnectAsync("mail.rabita.az", 465, true);
                await client.AuthenticateAsync(appEmail, appEmailPass);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
