using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataBase.Models;
using WebManager.Data;

namespace WebManager.Controllers
{
    public class SaleLogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SaleLogController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: SaleLog
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SaleLogSet.Include(s => s.Client).Include(s => s.Product).Include(s => s.Report);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SaleLog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleLogSet = await _context.SaleLogSet
                .Include(s => s.Client)
                .Include(s => s.Product)
                .Include(s => s.Report)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (saleLogSet == null)
            {
                return NotFound();
            }

            return View(saleLogSet);
        }

        // GET: SaleLog/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Set<ClientSet>(), "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Set<ProductSet>(), "Id", "Id");
            ViewData["ReportId"] = new SelectList(_context.Set<ReportSet>(), "Id", "Id");
            return View();
        }

        // POST: SaleLog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,ReportId,ClientId,ProductId")] SaleLogSet saleLogSet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleLogSet);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ClientId"] = new SelectList(_context.Set<ClientSet>(), "Id", "Id", saleLogSet.ClientId);
            ViewData["ProductId"] = new SelectList(_context.Set<ProductSet>(), "Id", "Id", saleLogSet.ProductId);
            ViewData["ReportId"] = new SelectList(_context.Set<ReportSet>(), "Id", "Id", saleLogSet.ReportId);
            return View(saleLogSet);
        }

        // GET: SaleLog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleLogSet = await _context.SaleLogSet.SingleOrDefaultAsync(m => m.Id == id);
            if (saleLogSet == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Set<ClientSet>(), "Id", "Id", saleLogSet.ClientId);
            ViewData["ProductId"] = new SelectList(_context.Set<ProductSet>(), "Id", "Id", saleLogSet.ProductId);
            ViewData["ReportId"] = new SelectList(_context.Set<ReportSet>(), "Id", "Id", saleLogSet.ReportId);
            return View(saleLogSet);
        }

        // POST: SaleLog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,ReportId,ClientId,ProductId")] SaleLogSet saleLogSet)
        {
            if (id != saleLogSet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleLogSet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleLogSetExists(saleLogSet.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["ClientId"] = new SelectList(_context.Set<ClientSet>(), "Id", "Id", saleLogSet.ClientId);
            ViewData["ProductId"] = new SelectList(_context.Set<ProductSet>(), "Id", "Id", saleLogSet.ProductId);
            ViewData["ReportId"] = new SelectList(_context.Set<ReportSet>(), "Id", "Id", saleLogSet.ReportId);
            return View(saleLogSet);
        }

        // GET: SaleLog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleLogSet = await _context.SaleLogSet
                .Include(s => s.Client)
                .Include(s => s.Product)
                .Include(s => s.Report)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (saleLogSet == null)
            {
                return NotFound();
            }

            return View(saleLogSet);
        }

        // POST: SaleLog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleLogSet = await _context.SaleLogSet.SingleOrDefaultAsync(m => m.Id == id);
            _context.SaleLogSet.Remove(saleLogSet);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SaleLogSetExists(int id)
        {
            return _context.SaleLogSet.Any(e => e.Id == id);
        }
    }
}
