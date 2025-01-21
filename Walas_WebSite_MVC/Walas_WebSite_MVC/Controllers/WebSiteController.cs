using Microsoft.AspNetCore.Mvc;
using Walas_WebSite_MVC.Models.Email;
using Walas_WebSite_MVC.Services.Email;

namespace Walas_WebSite_MVC.Controllers
{
    public class WebSiteController(IEmailService emailService) : Controller
    {

        // GET: WebSiteController
        public ActionResult WebSite()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(SendEmailDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Formulario inválido");
            }

            try
            {
                // Enviar correo
                emailService.SendEmail(model);
                return Ok("Tu mensaje ha sido enviado, !Gracias¡");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al procesar la solicitud: {ex.Message}");
            }
        }
    }
}
