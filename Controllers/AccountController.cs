using Microsoft.AspNetCore.Mvc;

namespace LvlUp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View("~/Areas/Identity/Pages/Account/AccessDenied.cshtml");
        }
    }
}
