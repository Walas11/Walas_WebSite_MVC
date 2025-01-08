using Walas_WebSite_MVC.Models.Email;

namespace Walas_WebSite_MVC.Services.Email
{
    public interface IEmailService
    {
        public void SendEmail(SendEmailDto model);
    }
}
