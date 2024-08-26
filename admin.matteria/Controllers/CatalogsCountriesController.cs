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
    public class CatalogsCountriesController : Controller
    {
        private readonly DbmatteriaContext _context;

        public CatalogsCountriesController(DbmatteriaContext context)
        {
            _context = context;
        }

        // GET: CatalogsCountries
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatalogsCountrys.ToListAsync());
        }

        // GET: CatalogsCountries/Details/5
        public async Task<IActionResult> Details(int? id,string name)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogsCountry = await _context.CatalogsCountrys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogsCountry == null)
            {
                return NotFound();
            }

            return View(catalogsCountry);
        }

        // GET: CatalogsCountries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatalogsCountries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Abreviation,Timestamp,Updated,CreatedById,Status,UpdatedById,NameEn,NamePt")] CatalogsCountry catalogsCountry)
        {

            catalogsCountry.CreatedById = 2;
            catalogsCountry.Timestamp = DateTime.Now;
            catalogsCountry.Updated = DateTime.Now;
            
            if (ModelState.IsValid)
            {
                _context.Add(catalogsCountry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalogsCountry);
        }

        // GET: CatalogsCountries/Edit/5
        public async Task<IActionResult> Edit(int? id,string name)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogsCountry = await _context.CatalogsCountrys.FindAsync(id);
            if (catalogsCountry == null)
            {
                return NotFound();
            }
            return View(catalogsCountry);
        }

        // POST: CatalogsCountries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Abreviation,Timestamp,Updated,CreatedById,Status,UpdatedById,NameEn,NamePt")] CatalogsCountry catalogsCountry)
        {
            if (id != catalogsCountry.Id)
            {
                return NotFound();
            }

            catalogsCountry.Updated = DateTime.Now;
            catalogsCountry.UpdatedById = 2;


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogsCountry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogsCountryExists(catalogsCountry.Id))
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
            return View(catalogsCountry);
        }

        // GET: CatalogsCountries/Delete/5
        public async Task<IActionResult> Delete(int? id,string name)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogsCountry = await _context.CatalogsCountrys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogsCountry == null)
            {
                return NotFound();
            }

            return View(catalogsCountry);
        }

        // POST: CatalogsCountries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id,string name)
        {
            var catalogsCountry = await _context.CatalogsCountrys.FindAsync(id);
            _context.CatalogsCountrys.Remove(catalogsCountry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogsCountryExists(int id)
        {
            return _context.CatalogsCountrys.Any(e => e.Id == id);
        }
    }
}
