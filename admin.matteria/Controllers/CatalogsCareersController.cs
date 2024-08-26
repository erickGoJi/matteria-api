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
    public class CatalogsCareersController : Controller
    {
        private readonly DbmatteriaContext _context;

        public CatalogsCareersController(DbmatteriaContext context)
        {
            _context = context;
        }

        // GET: CatalogsCareers
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatalogsCareers.ToListAsync());
        }

        // GET: CatalogsCareers/Details/5
        public async Task<IActionResult> Details(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsCareer = await _context.CatalogsCareers
                .FirstOrDefaultAsync(m =>  m.Id == id);
            if (catalogsCareer == null)
            {
                return NotFound();
            }

            return View(catalogsCareer);
        }

        // GET: CatalogsCareers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatalogsCareers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Timestamp,Updated,CreatedById,Status,UpdatedById,NameEn,NamePt")] CatalogsCareer catalogsCareer)
        {
            catalogsCareer.CreatedById = 2;
            catalogsCareer.Timestamp = DateTime.Now;
            catalogsCareer.Updated = DateTime.Now; ;

            if (ModelState.IsValid)
            {
                _context.Add(catalogsCareer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalogsCareer);
        }

        // GET: CatalogsCareers/Edit/5
        public async Task<IActionResult> Edit(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsCareer = await _context.CatalogsCareers.FindAsync(id);
            if (catalogsCareer == null)
            {
                return NotFound();
            }
            return View(catalogsCareer);
        }

        // POST: CatalogsCareers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Timestamp,Updated,CreatedById,Status,UpdatedById,NameEn,NamePt")] CatalogsCareer catalogsCareer)
        {
            if (id == 0)
            {
                return NotFound();
            }


            catalogsCareer.Updated = DateTime.Now;
            catalogsCareer.UpdatedById = 2;
            

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogsCareer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogsCareerExists(catalogsCareer.Name))
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
            return View(catalogsCareer);
        }

        // GET: CatalogsCareers/Delete/5
        public async Task<IActionResult> Delete(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsCareer = await _context.CatalogsCareers
                .FirstOrDefaultAsync(m =>  m.Id == id);
            if (catalogsCareer == null)
            {
                return NotFound();
            }

            return View(catalogsCareer);
        }

        // POST: CatalogsCareers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id,string name)
        {
            var catalogsCareer = await _context.CatalogsCareers.FindAsync(id);
            _context.CatalogsCareers.Remove(catalogsCareer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogsCareerExists(string id)
        {
            return _context.CatalogsCareers.Any(e => e.Name == id);
        }
    }
}
