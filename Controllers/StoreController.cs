using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using LvlUp.Data;
using LvlUp.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> GameInfo(int id)
        {
            var game = await _context.Game
                .Include(g => g.Developer)
                .Include(g => g.Publisher)
                .Include(g => g.Franchise)
                .Include(g => g.Software)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }
    }
}
