using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UltraStore.Data;
using UltraStore.Models;

namespace UltraStore.Controllers
{
    public class NFControllerBackup : Controller
    {
        private readonly UltraStoreContext _context;

        public NFControllerBackup(UltraStoreContext context)
        {
            _context = context;
        }

        // GET: NF
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nota.ToListAsync());
        }

        // GET: NF/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nf = await _context.Nota
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nf == null)
            {
                return NotFound();
            }

            return View(nf);
        }

        // GET: NF/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NF/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientId,Date,Amount,GameId")] Receipt nf)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nf);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nf);
        }

        // GET: NF/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nf = await _context.Nota.FindAsync(id);
            if (nf == null)
            {
                return NotFound();
            }
            return View(nf);
        }

        // POST: NF/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientId,Date,Amount,GameId")] Receipt nf)
        {
            if (id != nf.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nf);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NFExists(nf.Id))
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
            return View(nf);
        }

        // GET: NF/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nf = await _context.Nota
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nf == null)
            {
                return NotFound();
            }

            return View(nf);
        }

        // POST: NF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nf = await _context.Nota.FindAsync(id);
            _context.Nota.Remove(nf);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NFExists(int id)
        {
            return _context.Nota.Any(e => e.Id == id);
        }
    }
}
