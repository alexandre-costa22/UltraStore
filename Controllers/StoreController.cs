using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using LvlUp.Data;
using LvlUp.Models;

namespace LvlUp.Controllers
{
    public class StoreController : Controller
    {
        private readonly LvlUpContext _context;

        public StoreController (LvlUpContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var games = _context.Game.ToList();
            return View(games);
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
