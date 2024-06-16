using Evaluation.UI.Util.Model;
using Evaluation.UI.Wrapper;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Evaluation.UI.Util
{
    public class SendMail
    {
        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;
        public SendMail(ILoggerManager logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public async Task SendEmail(EmailModel sendMail, SendGrid.Helpers.Mail.Attachment? attachment = null)
        {
            try
            {
                var apiKey = _configuration["SendGridKey"];
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(sendMail.FromEmail, "Clover Broker");
                var subject = sendMail.Subject;
                var to = new EmailAddress(sendMail.ToEmail, "User");
                var plainTextContent = sendMail.TextBody;
                var htmlContent = sendMail.HtmlBody;
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                if (attachment != null)
                {
                    msg.AddAttachment(attachment);
                }

                var response = await client.SendEmailAsync(msg);
                if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    //  Console.WriteLine("Email sent successfully.");
                    _logger.LogDebug($"Error sending email: {response.StatusCode}");
                }
                else
                {
                    //Console.WriteLine($"Error sending email: {response.StatusCode}");
                    _logger.LogDebug($"Error sending email: {response.StatusCode}");
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error sending email Exception: ", e);
            }
        }
    }
}
