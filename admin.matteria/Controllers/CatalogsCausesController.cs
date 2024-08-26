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
    public class CatalogsCausesController : Controller
    {
        private readonly DbmatteriaContext _context;

        public CatalogsCausesController(DbmatteriaContext context)
        {
            _context = context;
        }

        // GET: CatalogsCauses
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatalogsCauses.ToListAsync());
        }

        // GET: CatalogsCauses/Details/5
        public async Task<IActionResult> Details(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsCause = await _context.CatalogsCauses
                .FirstOrDefaultAsync(m =>  m.Id == id);
            if (catalogsCause == null)
            {
                return NotFound();
            }

            return View(catalogsCause);
        }

        // GET: CatalogsCauses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatalogsCauses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Timestamp,Updated,CreatedById,Status,UpdatedById,NameEn,NamePt")] CatalogsCause catalogsCause)
        {

            catalogsCause.CreatedById = 2;
            catalogsCause.Timestamp = DateTime.Now;
            catalogsCause.Updated = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(catalogsCause);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalogsCause);
        }

        // GET: CatalogsCauses/Edit/5
        public async Task<IActionResult> Edit(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsCause = await _context.CatalogsCauses.FindAsync(id);
            if (catalogsCause == null)
            {
                return NotFound();
            }
            return View(catalogsCause);
        }

        // POST: CatalogsCauses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Timestamp,Updated,CreatedById,Status,UpdatedById,NameEn,NamePt")] CatalogsCause catalogsCause)
        {
            if (id == null)
            {
                return NotFound();
            }

            catalogsCause.Updated = DateTime.Now;
            catalogsCause.UpdatedById = 2;
            

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogsCause);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogsCauseExists(catalogsCause.Name))
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
            return View(catalogsCause);
        }

        // GET: CatalogsCauses/Delete/5
        public async Task<IActionResult> Delete(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsCause = await _context.CatalogsCauses
                .FirstOrDefaultAsync(m =>  m.Id == id);
            if (catalogsCause == null)
            {
                return NotFound();
            }

            return View(catalogsCause);
        }

        // POST: CatalogsCauses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id,string name)
        {
            var catalogsCause = await _context.CatalogsCauses.FindAsync(id);
            _context.CatalogsCauses.Remove(catalogsCause);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogsCauseExists(string id)
        {
            return _context.CatalogsCauses.Any(e => e.Name == id);
        }
    }
}
