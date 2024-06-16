using Evaluation.UI.Util.Model;

namespace Evaluation.UI.IUtil
{
    public interface ISendMail
    {
        Task SendEmail(EmailModel sendMail, SendGrid.Helpers.Mail.Attachment? attachment = null);
    }
}
