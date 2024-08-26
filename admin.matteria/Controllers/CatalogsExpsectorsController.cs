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
    public class CatalogsExpsectorsController : Controller
    {
        private readonly DbmatteriaContext _context;

        public CatalogsExpsectorsController(DbmatteriaContext context)
        {
            _context = context;
        }

        // GET: CatalogsExpsectors
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatalogsExpsectors.ToListAsync());
        }

        // GET: CatalogsExpsectors/Details/5
        public async Task<IActionResult> Details(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsExpsector = await _context.CatalogsExpsectors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogsExpsector == null)
            {
                return NotFound();
            }

            return View(catalogsExpsector);
        }

        // GET: CatalogsExpsectors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatalogsExpsectors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Timestamp,Updated,CreatedById,UpdatedById,Status,NameEn,NamePt")] CatalogsExpsector catalogsExpsector)
        {


            catalogsExpsector.CreatedById = 2;
            catalogsExpsector.Timestamp = DateTime.Now;
            catalogsExpsector.Updated = DateTime.Now;
            
            if (ModelState.IsValid)
            {
                _context.Add(catalogsExpsector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalogsExpsector);
        }

        // GET: CatalogsExpsectors/Edit/5
        public async Task<IActionResult> Edit(int id,string name,string nameEn,string namePt)
        {
            if (id == 0)
            {
                return NotFound();
            }

            if(nameEn == null)
            {
                nameEn = "";
            }

            if(namePt == null)
            {
                namePt = "";
            }

            var catalogsExpsector = await _context.CatalogsExpsectors.FindAsync(id);
            if (catalogsExpsector == null)
            {
                return NotFound();
            }
            return View(catalogsExpsector);
        }

        // POST: CatalogsExpsectors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Timestamp,Updated,CreatedById,UpdatedById,Status,NameEn,NamePt")] CatalogsExpsector catalogsExpsector)
        {
            if (id != catalogsExpsector.Id)
            {
                return NotFound();
            }

            catalogsExpsector.Updated = DateTime.Now;
            catalogsExpsector.UpdatedById = 2;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogsExpsector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogsExpsectorExists(catalogsExpsector.NamePt))
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
            return View(catalogsExpsector);
        }

        // GET: CatalogsExpsectors/Delete/5
        public async Task<IActionResult> Delete(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsExpsector = await _context.CatalogsExpsectors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogsExpsector == null)
            {
                return NotFound();
            }

            return View(catalogsExpsector);
        }

        // POST: CatalogsExpsectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id,string name,string nameEn,string NamePt)
        {
            var catalogsExpsector = await _context.CatalogsExpsectors.FindAsync(id);
            _context.CatalogsExpsectors.Remove(catalogsExpsector);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogsExpsectorExists(string id)
        {
            return _context.CatalogsExpsectors.Any(e => e.NamePt == id);
        }
    }
}
