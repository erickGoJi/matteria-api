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
    public class CatalogsExpareasController : Controller
    {
        private readonly DbmatteriaContext _context;

        public CatalogsExpareasController(DbmatteriaContext context)
        {
            _context = context;
        }

        // GET: CatalogsExpareas
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatalogsExpareas.ToListAsync());
        }

        // GET: CatalogsExpareas/Details/5
        public async Task<IActionResult> Details(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsExparea = await _context.CatalogsExpareas
                .FirstOrDefaultAsync(m =>  m.Id == id);
            if (catalogsExparea == null)
            {
                return NotFound();
            }

            return View(catalogsExparea);
        }

        // GET: CatalogsExpareas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatalogsExpareas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Timestamp,Updated,CreatedById,UpdatedById,Status,NameEn,NamePt")] CatalogsExparea catalogsExparea)
        {

            catalogsExparea.CreatedById = 2;
            catalogsExparea.Timestamp = DateTime.Now;
            catalogsExparea.Updated = DateTime.Now;
            
            if (ModelState.IsValid)
            {
                _context.Add(catalogsExparea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalogsExparea);
        }

        // GET: CatalogsExpareas/Edit/5
        public async Task<IActionResult> Edit(int id,string name,string nameEn,string namePt)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsExparea = await _context.CatalogsExpareas.FindAsync(id);
            if (catalogsExparea == null)
            {
                return NotFound();
            }
            return View(catalogsExparea);
        }

        // POST: CatalogsExpareas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Timestamp,Updated,CreatedById,UpdatedById,Status,NameEn,NamePt")] CatalogsExparea catalogsExparea)
        {
            if (id != catalogsExparea.Id)
            {
                return NotFound();
            }

            
            catalogsExparea.Updated = DateTime.Now;
            catalogsExparea.UpdatedById = 2;
            


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogsExparea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogsExpareaExists(catalogsExparea.NamePt))
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
            return View(catalogsExparea);
        }

        // GET: CatalogsExpareas/Delete/5
        public async Task<IActionResult> Delete(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsExparea = await _context.CatalogsExpareas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogsExparea == null)
            {
                return NotFound();
            }

            return View(catalogsExparea);
        }

        // POST: CatalogsExpareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, string name,string NameEn,string NamePt)
        {
            var catalogsExparea = await _context.CatalogsExpareas.FindAsync(id);
            _context.CatalogsExpareas.Remove(catalogsExparea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogsExpareaExists(string id)
        {
            return _context.CatalogsExpareas.Any(e => e.NamePt == id);
        }
    }
}
