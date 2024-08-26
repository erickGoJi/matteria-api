using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using biz.matteria.Entities;
using dal.matteria.db_Context;
using admin.matteria.Models;

namespace admin.matteria.Controllers
{
    public class CatalogsStatesController : Controller
    {
        private readonly DbmatteriaContext _context;

        public CatalogsStatesController(DbmatteriaContext context)
        {
            _context = context;
        }

        // GET: CatalogsStates
        public async Task<IActionResult> Index()
        {



            return View(await _context.CatalogsStates.ToListAsync());
        }

        // GET: CatalogsStates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogsState = await _context.CatalogsStates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogsState == null)
            {
                return NotFound();
            }

            return View(catalogsState);
        }



        // GET: CatalogsStates/Create
        public IActionResult Create()
        {


            List<ddlCountry> country = _context.CatalogsCountrys
                .Select(i => new ddlCountry
                {
                    Id = i.Id,
                    Name = i.Name

                }).ToList();

            //country.Insert(0, new ddlCountry { Id = 0, Name = "Seleccione" });

            ViewBag.ListCountry = country;

            return View();
        }

        // POST: CatalogsStates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Status,Timestamp,Updated,CountryId,CreatedById,UpdatedById,NameEn,NamePt")] CatalogsState catalogsState)
        {

            catalogsState.Timestamp = DateTime.Now;
            catalogsState.Updated = DateTime.Now;
            catalogsState.CreatedById = 2;

            if (ModelState.IsValid)
            {
                _context.Add(catalogsState);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalogsState);
        }

        // GET: CatalogsStates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<ddlCountry> country = _context.CatalogsCountrys
                .Select(i => new ddlCountry
                {
                    Id = i.Id,
                    Name = i.Name

                }).ToList();

            //country.Insert(0, new ddlCountry { Id = 0, Name = "Seleccione" });

            ViewBag.ListCountry = country;



            var catalogsState = await _context.CatalogsStates.FindAsync(id);
            if (catalogsState == null)
            {
                return NotFound();
            }
            return View(catalogsState);
        }

        // POST: CatalogsStates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status,Timestamp,Updated,CountryId,CreatedById,UpdatedById,NameEn,NamePt")] CatalogsState catalogsState)
        {
            if (id != catalogsState.Id)
            {
                return NotFound();
            }

            
            catalogsState.Updated = DateTime.Now;
            catalogsState.UpdatedById = 2;



            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogsState);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogsStateExists(catalogsState.Id))
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
            return View(catalogsState);
        }

        // GET: CatalogsStates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogsState = await _context.CatalogsStates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogsState == null)
            {
                return NotFound();
            }

            return View(catalogsState);
        }

        // POST: CatalogsStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catalogsState = await _context.CatalogsStates.FindAsync(id);
            _context.CatalogsStates.Remove(catalogsState);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogsStateExists(int id)
        {
            return _context.CatalogsStates.Any(e => e.Id == id);
        }
    }
}
