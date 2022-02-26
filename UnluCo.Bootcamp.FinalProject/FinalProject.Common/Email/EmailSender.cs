using System.Net;
using System.Net.Mail;

namespace FinalProject.Common.Email
{
    public class EmailSender
    {
        public void SendEmail(EmailModel emailModel)
        {
            MailMessage sender = new MailMessage();
            sender.From = new MailAddress($"{emailModel.SenderEmail}", $"{emailModel.SenderTitle}");
            sender.To.Add(emailModel.ReceiverEmail);
            sender.Subject = emailModel.Subject;
            sender.Body = emailModel.Body;

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("ensarerenoglu@hotmail.com", "@Candle2022");
            smtp.Port = 587;
            smtp.Host = "smtp-mail.outlook.com";
            smtp.EnableSsl = true;

            smtp.Send(sender);
        }
    }
}
