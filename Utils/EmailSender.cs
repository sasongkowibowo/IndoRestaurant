using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace IndoRestaurant.Utils
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "";

        public void Send(String toEmail, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@indoori.com", "Indonesian Original Recipes administrator");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }

        public void SendMultiple(List<string> toEmails, String subject, String contents, String attachmentPath, string fileName)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@indoori.com", "Indonesian Original Recipes administrator");
            var to = toEmails.Select(x => MailHelper.StringToEmailAddress(x)).ToList();
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, subject, plainTextContent, htmlContent);

            if (attachmentPath != null)
            {
                var bytes = File.ReadAllBytes(attachmentPath);
                var file = Convert.ToBase64String(bytes);
                msg.AddAttachment(fileName, file);
            }

            var response = client.SendEmailAsync(msg);
        }
    }
}