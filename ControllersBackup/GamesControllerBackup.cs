using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UltraStore.Data;
using UltraStore.Models;

namespace UltraStore.Controllers
{
    public class GamesControllerBackup : Controller
    {
        private readonly UltraStoreContext _context;

        public GamesControllerBackup(UltraStoreContext context)
        {
            _context = context;
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            var games = await _context.Game
                .Include(g => g.Developer)
                .Include(g => g.Publisher)
                .Include(g => g.Franchise)
                .Include(g => g.Platforms)
                .ToListAsync();

            return View(games);
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.Developer)
                .Include(g => g.Publisher)
                .Include(g => g.Franchise)
                .Include(g => g.Platforms)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            ViewData["FranchiseId"] = new SelectList(_context.Franchise, "Id", "Name");
            ViewData["DeveloperId"] = new SelectList(_context.Developer, "Id", "Name");
            ViewData["PublisherId"] = new SelectList(_context.Publisher, "Id", "Name");
            ViewData["PlatformsId"] = new SelectList(_context.Platforms, "Id", "Name");

            return View();
        }

        // POST: Games/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Price,DeveloperId,PublisherId,FranchiseId,PlatformsId")] Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["FranchiseId"] = new SelectList(_context.Franchise, "Id", "Name");
            ViewData["DeveloperId"] = new SelectList(_context.Developer, "Id", "Name");
            ViewData["PublisherId"] = new SelectList(_context.Publisher, "Id", "Name");
            ViewData["PlatformsId"] = new SelectList(_context.Platforms, "Id", "Name");

            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            ViewData["FranchiseId"] = new SelectList(_context.Franchise, "Id", "Name");
            ViewData["DeveloperId"] = new SelectList(_context.Developer, "Id", "Name");
            ViewData["PublisherId"] = new SelectList(_context.Publisher, "Id", "Name");
            ViewData["PlatformsId"] = new SelectList(_context.Platforms, "Id", "Name");

            return View(game);
        }

        // POST: Games/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Price,DeveloperId,PublisherId,FranchiseId,PlatformsId")] Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["FranchiseId"] = new SelectList(_context.Franchise, "Id", "Name");
            ViewData["DeveloperId"] = new SelectList(_context.Developer, "Id", "Name");
            ViewData["PublisherId"] = new SelectList(_context.Publisher, "Id", "Name");
            ViewData["PlatformsId"] = new SelectList(_context.Platforms, "Id", "Name");

            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.Developer)
                .Include(g => g.Publisher)
                .Include(g => g.Franchise)
                .Include(g => g.Platforms)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Game.FindAsync(id);
            _context.Game.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
            return _context.Game.Any(e => e.Id == id);
        }
    }
}
