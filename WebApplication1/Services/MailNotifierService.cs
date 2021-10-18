using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public class MailNotifierService
    {
        public async Task NotifyGidra(string Subject, string MailBody)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("m.radevic@vegait.rs");
            message.To.Add(new MailAddress("m.radevic@vegait.rs"));
            message.To.Add(new MailAddress("d.vucetic@vegait.rs"));
            message.Subject = Subject;
            message.IsBodyHtml = true; //to make message body as html  
            message.Body = MailBody;
            smtp.Port = 587;
            smtp.Host = "smtp.sendgrid.net";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("apikey", "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");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(message);
        }
    }
}
