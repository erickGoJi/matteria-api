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
    public class CatalogsOpeningphasesController : Controller
    {
        private readonly DbmatteriaContext _context;

        public CatalogsOpeningphasesController(DbmatteriaContext context)
        {
            _context = context;
        }

        // GET: CatalogsOpeningphases
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatalogsOpeningphases.ToListAsync());
        }

        // GET: CatalogsOpeningphases/Details/5
        public async Task<IActionResult> Details(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsOpeningphase = await _context.CatalogsOpeningphases
                .FirstOrDefaultAsync(m => m.Id ==id);
            if (catalogsOpeningphase == null)
            {
                return NotFound();
            }

            return View(catalogsOpeningphase);
        }

        // GET: CatalogsOpeningphases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatalogsOpeningphases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Status,Timestamp,Updated,CreatedById,UpdatedById,NameEn,NamePt")] CatalogsOpeningphase catalogsOpeningphase)
        {

            catalogsOpeningphase.CreatedById = 2;
            catalogsOpeningphase.Updated = DateTime.Now;
            catalogsOpeningphase.Timestamp = DateTime.Now;



            if (ModelState.IsValid)
            {
                _context.Add(catalogsOpeningphase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalogsOpeningphase);
        }

        // GET: CatalogsOpeningphases/Edit/5
        public async Task<IActionResult> Edit(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsOpeningphase = await _context.CatalogsOpeningphases.FindAsync(id);
            if (catalogsOpeningphase == null)
            {
                return NotFound();
            }
            return View(catalogsOpeningphase);
        }

        // POST: CatalogsOpeningphases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status,Timestamp,Updated,CreatedById,UpdatedById,NameEn,NamePt")] CatalogsOpeningphase catalogsOpeningphase)
        {
            if (id != catalogsOpeningphase.Id)
            {
                return NotFound();
            }
            
            catalogsOpeningphase.Updated = DateTime.Now;
            catalogsOpeningphase.UpdatedById = 2;
            



            

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogsOpeningphase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogsOpeningphaseExists(catalogsOpeningphase.Name))
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
            return View(catalogsOpeningphase);
        }

        // GET: CatalogsOpeningphases/Delete/5
        public async Task<IActionResult> Delete(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsOpeningphase = await _context.CatalogsOpeningphases
                .FirstOrDefaultAsync(m =>  m.Id == id);
            if (catalogsOpeningphase == null)
            {
                return NotFound();
            }

            return View(catalogsOpeningphase);
        }

        // POST: CatalogsOpeningphases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id,string name)
        {
            var catalogsOpeningphase = await _context.CatalogsOpeningphases.FindAsync(id);
            _context.CatalogsOpeningphases.Remove(catalogsOpeningphase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogsOpeningphaseExists(string id)
        {
            return _context.CatalogsOpeningphases.Any(e => e.Name == id);
        }
    }
}
