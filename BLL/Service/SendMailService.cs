using BLL.Helper;
using BLL.IService;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;


namespace BLL.Service
{
    public class SendMailService:ISendMailService
    {
        private readonly MailSettings _mailservice;
        public SendMailService(IOptions<MailSettings> mailservic)
        {
            _mailservice = mailservic.Value;
        }
        public async Task sendEmailAsync(string mailTo, string subject, string body)
        {
            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_mailservice.Email),
                Subject = subject
            };
            email.To.Add(MailboxAddress.Parse(mailTo));

            var builder = new BodyBuilder();
            builder.HtmlBody = body;
            email.Body = builder.ToMessageBody();
            email.From.Add(new MailboxAddress(_mailservice.DisplayName, _mailservice.Email));

            using var smtp = new SmtpClient();
            smtp.Connect(_mailservice.Host, _mailservice.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailservice.Email, _mailservice.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);

        }
    }
}
