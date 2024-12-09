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

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(string name, string email, string message)
        {
            if (ModelState.IsValid)
            {
                // Lógica para processar o formulário (enviar email, salvar em banco de dados, etc.)
                TempData["Message"] = "Sua mensagem foi enviada com sucesso!";
                return RedirectToAction("Contact");
            }

            return View();
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
