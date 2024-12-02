using Microsoft.AspNetCore.Mvc;

namespace UltraStore.Controllers
{
    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
