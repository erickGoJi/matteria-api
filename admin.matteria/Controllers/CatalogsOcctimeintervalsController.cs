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
    public class CatalogsOcctimeintervalsController : Controller
    {
        private readonly DbmatteriaContext _context;

        public CatalogsOcctimeintervalsController(DbmatteriaContext context)
        {
            _context = context;
        }

        // GET: CatalogsOcctimeintervals
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatalogsOcctimeintervals.ToListAsync());
        }

        // GET: CatalogsOcctimeintervals/Details/5
        public async Task<IActionResult> Details(int id,string name,string nameEng)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsOcctimeinterval = await _context.CatalogsOcctimeintervals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogsOcctimeinterval == null)
            {
                return NotFound();
            }

            return View(catalogsOcctimeinterval);
        }

        // GET: CatalogsOcctimeintervals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatalogsOcctimeintervals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,NameEng,TimeDays,Status,Timestamp,Updated,CreatedById,UpdatedById,NamePt")] CatalogsOcctimeinterval catalogsOcctimeinterval)
        {

            catalogsOcctimeinterval.CreatedById = 2;
            catalogsOcctimeinterval.Timestamp = DateTime.Now;
            catalogsOcctimeinterval.Updated = DateTime.Now;
            

            if (ModelState.IsValid)
            {
                _context.Add(catalogsOcctimeinterval);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalogsOcctimeinterval);
        }

        // GET: CatalogsOcctimeintervals/Edit/5
        public async Task<IActionResult> Edit(int id,string name,string nameEng)
        {
            if (id == 0)
            {
                return NotFound();
            }

            if(name == null)
            {
                name = "";
            }

            if(nameEng == null)
            {
                nameEng = "";
            }

            var catalogsOcctimeinterval = await _context.CatalogsOcctimeintervals.FindAsync(id);
            if (catalogsOcctimeinterval == null)
            {
                return NotFound();
            }
            return View(catalogsOcctimeinterval);
        }

        // POST: CatalogsOcctimeintervals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,NameEng,TimeDays,Status,Timestamp,Updated,CreatedById,UpdatedById,NamePt")] CatalogsOcctimeinterval catalogsOcctimeinterval)
        {
            if (id != catalogsOcctimeinterval.Id)
            {
                return NotFound();
            }

            catalogsOcctimeinterval.Updated = DateTime.Now;
            catalogsOcctimeinterval.UpdatedById = 2;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogsOcctimeinterval);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogsOcctimeintervalExists(catalogsOcctimeinterval.NameEng))
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
            return View(catalogsOcctimeinterval);
        }

        // GET: CatalogsOcctimeintervals/Delete/5
        public async Task<IActionResult> Delete(int id,string name, string nameEng)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsOcctimeinterval = await _context.CatalogsOcctimeintervals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogsOcctimeinterval == null)
            {
                return NotFound();
            }

            return View(catalogsOcctimeinterval);
        }

        // POST: CatalogsOcctimeintervals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id,string name,string nameEng)
        {
            var catalogsOcctimeinterval = await _context.CatalogsOcctimeintervals.FindAsync(id);
            _context.CatalogsOcctimeintervals.Remove(catalogsOcctimeinterval);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogsOcctimeintervalExists(string id)
        {
            return _context.CatalogsOcctimeintervals.Any(e => e.NameEng == id);
        }
    }
}
