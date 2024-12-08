using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LvlUp.Data;
using LvlUp.Models;

namespace LvlUp.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly LvlUpContext _context;

        public ReceiptsController(LvlUpContext context)
        {
            _context = context;
        }

        // GET: Receipts
        public async Task<IActionResult> Index()
        {
            var lvlUpContext = _context.Nota.Include(r => r.Clients).Include(r => r.Seller);
            return View(await lvlUpContext.ToListAsync());
        }

        // GET: Receipts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nota == null)
            {
                return NotFound();
            }

            var receipt = await _context.Nota
                .Include(r => r.Clients)
                .Include(r => r.Seller)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receipt == null)
            {
                return NotFound();
            }

            return View(receipt);
        }

        // GET: Receipts/Create
        public IActionResult Create()
        {
            var receipt = new Receipt
            {
                CreatedAt = DateTime.Now
            };

            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Email");
            ViewData["SellerId"] = new SelectList(_context.Seller, "Id", "Email");
            return View(receipt);
        }


        // POST: Receipts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cpf,ClientId,SellerId,TotalPrice")] Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                receipt.CreatedAt = DateTime.Now; 
                _context.Add(receipt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Email", receipt.ClientId);
            ViewData["SellerId"] = new SelectList(_context.Seller, "Id", "Email", receipt.SellerId);
            return View(receipt);
        }

        // GET: Receipts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nota == null)
            {
                return NotFound();
            }

            var receipt = await _context.Nota.FindAsync(id);
            if (receipt == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Email", receipt.ClientId);
            ViewData["SellerId"] = new SelectList(_context.Seller, "Id", "Email", receipt.SellerId);
            return View(receipt);
        }

        // POST: Receipts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cpf,ClientId,SellerId,TotalPrice")] Receipt receipt)
        {
            if (id != receipt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Busca o registro original para manter o valor de CreatedAt
                    var originalReceipt = await _context.Nota.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
                    if (originalReceipt == null)
                    {
                        return NotFound();
                    }

                    // Preserva a data de criação original
                    receipt.CreatedAt = originalReceipt.CreatedAt;

                    _context.Update(receipt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceiptExists(receipt.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Email", receipt.ClientId);
            ViewData["SellerId"] = new SelectList(_context.Seller, "Id", "Email", receipt.SellerId);
            return View(receipt);
        }


        // GET: Receipts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nota == null)
            {
                return NotFound();
            }

            var receipt = await _context.Nota
                .Include(r => r.Clients)
                .Include(r => r.Seller)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receipt == null)
            {
                return NotFound();
            }

            return View(receipt);
        }

        // POST: Receipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nota == null)
            {
                return Problem("Entity set 'LvlUpContext.Nota'  is null.");
            }
            var receipt = await _context.Nota.FindAsync(id);
            if (receipt != null)
            {
                _context.Nota.Remove(receipt);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceiptExists(int id)
        {
          return (_context.Nota?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
