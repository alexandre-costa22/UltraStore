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
        public IActionResult Index(string query)
        {
            ViewData["query"] = query;

            var games = string.IsNullOrEmpty(query)
                ? _context.Game.ToList()
                : _context.Game.Where(g => g.Title.Contains(query)).ToList();

            return View(games);
        }


        [HttpGet]
        public IActionResult SearchGames(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                var emptyList = new List<Game>();
                return PartialView("_GameListPartial", emptyList);
            }

            var games = _context.Game
                .Where(g => g.Title.Contains(query))
                .Take(5)
                .ToList();

            return PartialView("_GameListPartial", games);
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
