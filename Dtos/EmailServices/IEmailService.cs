using Dtos.UserEmailOption;

namespace Dtos.EmailServices
{
    public interface IEmailService
    {
        Task SendEmail(UserEmailOptions userEmailOptions);
        Task SendEmailForEmailConfirmation(UserEmailOptions userEmailOptions);
        Task SendEmailForForgotPassword(UserEmailOptions userEmailOptions);
        Task SendTestEmail(UserEmailOptions userEmailOptions);
    }
}