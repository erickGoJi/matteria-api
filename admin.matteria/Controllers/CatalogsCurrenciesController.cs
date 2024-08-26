using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using biz.matteria.Entities;
using dal.matteria.db_Context;

namespace admin.matteria.Controllers
{
    public class CatalogsCurrenciesController : Controller
    {
        private readonly DbmatteriaContext _context;

        public CatalogsCurrenciesController(DbmatteriaContext context)
        {
            _context = context;
        }

        // GET: CatalogsCurrencies
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatalogsCurrencys.ToListAsync());
        }

        // GET: CatalogsCurrencies/Details/5
        public async Task<IActionResult> Details(int? id,string name)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogsCurrency = await _context.CatalogsCurrencys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogsCurrency == null)
            {
                return NotFound();
            }

            return View(catalogsCurrency);
        }

        // GET: CatalogsCurrencies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatalogsCurrencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Abreviation,NameEn,Status,Timestamp,Updated,CreatedById,UpdatedById,NamePt")] CatalogsCurrency catalogsCurrency)
        {


            catalogsCurrency.CreatedById = 2;
            catalogsCurrency.Timestamp = DateTime.Now;
            catalogsCurrency.Updated = DateTime.Now;
            
            if (ModelState.IsValid)
            {
                _context.Add(catalogsCurrency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalogsCurrency);
        }

        // GET: CatalogsCurrencies/Edit/5
        public async Task<IActionResult> Edit(int? id,string name)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogsCurrency = await _context.CatalogsCurrencys.FindAsync(id);
            if (catalogsCurrency == null)
            {
                return NotFound();
            }
            return View(catalogsCurrency);
        }

        // POST: CatalogsCurrencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Abreviation,NameEn,Status,Timestamp,Updated,CreatedById,UpdatedById,NamePt")] CatalogsCurrency catalogsCurrency)
        {
            if (id != catalogsCurrency.Id)
            {
                return NotFound();
            }

            catalogsCurrency.Updated = DateTime.Now;
            catalogsCurrency.UpdatedById = 2;


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogsCurrency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogsCurrencyExists(catalogsCurrency.Id))
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
            return View(catalogsCurrency);
        }

        // GET: CatalogsCurrencies/Delete/5
        public async Task<IActionResult> Delete(int? id,string name)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogsCurrency = await _context.CatalogsCurrencys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogsCurrency == null)
            {
                return NotFound();
            }

            return View(catalogsCurrency);
        }

        // POST: CatalogsCurrencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id,string name)
        {
            var catalogsCurrency = await _context.CatalogsCurrencys.FindAsync(id);
            _context.CatalogsCurrencys.Remove(catalogsCurrency);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogsCurrencyExists(int id)
        {
            return _context.CatalogsCurrencys.Any(e => e.Id == id);
        }
    }
}
