using AdminSiteUseMVC.Models.Services.UserEmailOption;

namespace AdminSiteUseMVC.Models.Services.Email
{
    public interface IEmailService
    {
        Task SendEmail(UserEmailOptions userEmailOptions);
        Task SendEmailForEmailConfirmation(UserEmailOptions userEmailOptions);
        Task SendEmailForForgotPassword(UserEmailOptions userEmailOptions);
        Task SendTestEmail(UserEmailOptions userEmailOptions);
        //Task SendEmail(UserEmailOptions userEmailOptions);
        //Task SendTestEmail(UserEmailOptions userEmailOptions);
        //Task SendEmailForEmailConfirmation(UserEmailOptions userEmailOptions);
        //Task SendEmailForForgotPassword(UserEmailOptions userEmailOptions);
    }
}