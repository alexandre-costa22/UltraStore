using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LvlUp.Data;
using LvlUp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;


namespace LvlUp.Controllers
{
    [Authorize(Roles = "Admin")]

    public class GamesController : Controller
    {
        private readonly LvlUpContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public GamesController(LvlUpContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;

        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            var LvlUpContext = _context.Game.Include(g => g.Developer).Include(g => g.Franchise).Include(g => g.Software).Include(g => g.Publisher);
            return View(await LvlUpContext.ToListAsync());
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Game == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.Developer)
                .Include(g => g.Franchise)
                .Include(g => g.Software)
                .Include(g => g.Publisher)
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
            ViewData["DeveloperId"] = new SelectList(_context.Developer, "Id", "Name");
            ViewData["FranchiseId"] = new SelectList(_context.Franchise, "Id", "Name");
            ViewData["SoftwareId"] = new SelectList(_context.Software, "Id", "Manufacturer");
            ViewData["PublisherId"] = new SelectList(_context.Publisher, "Id", "ComercialEmail");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,ReleaseDate,Price,DeveloperId,PublisherId,FranchiseId,SoftwareId,Rating,IsMultiplayer")] Game game, IFormFile? imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var fileName = Path.GetRandomFileName() + Path.GetExtension(imageFile.FileName);

                    var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "games");
                    Directory.CreateDirectory(uploadPath);

                    var filePath = Path.Combine(uploadPath, fileName);


                    using(var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    game.ImagePath = Path.Combine("images", "games", fileName).Replace("\\", "/");
                }


                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["DeveloperId"] = new SelectList(_context.Developer, "Id", "Name", game.DeveloperId);
            ViewData["FranchiseId"] = new SelectList(_context.Franchise, "Id", "Name", game.FranchiseId);
            ViewData["SoftwareId"] = new SelectList(_context.Software, "Id", "Manufacturer", game.SoftwareId);
            ViewData["PublisherId"] = new SelectList(_context.Publisher, "Id", "ComercialEmail", game.PublisherId);
            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Game == null)
            {
                return NotFound();
            }

            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            ViewData["DeveloperId"] = new SelectList(_context.Developer, "Id", "Name", game.DeveloperId);
            ViewData["FranchiseId"] = new SelectList(_context.Franchise, "Id", "Name", game.FranchiseId);
            ViewData["SoftwareId"] = new SelectList(_context.Software, "Id", "Manufacturer", game.SoftwareId);
            ViewData["PublisherId"] = new SelectList(_context.Publisher, "Id", "ComercialEmail", game.PublisherId);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,ReleaseDate,Price,DeveloperId,PublisherId,FranchiseId,SoftwareId,Rating,IsMultiplayer,ImagePath")] Game game)
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
            ViewData["DeveloperId"] = new SelectList(_context.Developer, "Id", "Name", game.DeveloperId);
            ViewData["FranchiseId"] = new SelectList(_context.Franchise, "Id", "Name", game.FranchiseId);
            ViewData["SoftwareId"] = new SelectList(_context.Software, "Id", "Manufacturer", game.SoftwareId);
            ViewData["PublisherId"] = new SelectList(_context.Publisher, "Id", "ComercialEmail", game.PublisherId);
            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Game == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.Developer)
                .Include(g => g.Franchise)
                .Include(g => g.Software)
                .Include(g => g.Publisher)
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
            if (_context.Game == null)
            {
                return Problem("Entity set 'LvlUpContext.Game'  is null.");
            }
            var game = await _context.Game.FindAsync(id);
            if (game != null)
            {
                _context.Game.Remove(game);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
          return (_context.Game?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
