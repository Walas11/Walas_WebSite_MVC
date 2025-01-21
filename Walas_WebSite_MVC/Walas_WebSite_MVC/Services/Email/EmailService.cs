using System.Net;
using System.Net.Mail;
using Walas_WebSite_MVC.Models.Email;

namespace Walas_WebSite_MVC.Services.Email
{
    public class EmailService : IEmailService
    {
        public void SendEmail(SendEmailDto model)
        {
            var fromAddress = new MailAddress("sebastianaceroleon@gmail.com", "Sebastian Acero Leon");
            var toAddress = new MailAddress("sebastianaceroleon@gmail.com");
            const string fromPassword = "ecel pzjl paot plxx"; // Usa un app password para más seguridad

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com", // Cambia al servidor SMTP de tu proveedor
                Port = 587, // Cambia según tu proveedor de correo
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = model.Subject,
                Body =  $"De: {model.Name}\n" +
                        $"Asunto: {model.Subject}\n" +
                        $"Email: {model.Email}\n" +
                        $"Mensaje:\n{model.Message}",
                IsBodyHtml = false
            };

            // Agregar la dirección del remitente original como "ReplyTo"
            message.ReplyToList.Add(new MailAddress(model.Email));

            smtp.Send(message);
        }
    }
}
