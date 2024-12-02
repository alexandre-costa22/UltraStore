using Microsoft.AspNetCore.Mvc;

namespace LvlUp.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error404")]
        public IActionResult Error404()
        {
            Response.StatusCode = 404; // Define o status HTTP 404
            return View("Error404"); // Renderiza a View localizada em Views/Shared/Error404.cshtml
        }
    }

}
