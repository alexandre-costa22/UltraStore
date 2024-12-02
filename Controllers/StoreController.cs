using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using UltraStore.Data;
using UltraStore.Models;

namespace UltraStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly UltraStoreContext _context;
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchGames(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return Json(new { results = new List<Game>() });
            }

            var games = _context.Game
                .Where(g => g.Title.Contains(query))
                .Take(5)
                .ToList();

            return Json(new { results = games });
        }
    }
}
