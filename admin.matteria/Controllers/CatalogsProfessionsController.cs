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
    public class CatalogsProfessionsController : Controller
    {
        private readonly DbmatteriaContext _context;

        public CatalogsProfessionsController(DbmatteriaContext context)
        {
            _context = context;
        }

        // GET: CatalogsProfessions
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatalogsProfessions.ToListAsync());
        }

        // GET: CatalogsProfessions/Details/5
        public async Task<IActionResult> Details(int id,string name,string nameEn,string namePt)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsProfession = await _context.CatalogsProfessions
                .FirstOrDefaultAsync(m =>  m.Id == id);
            if (catalogsProfession == null)
            {
                return NotFound();
            }

            return View(catalogsProfession);
        }

        // GET: CatalogsProfessions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatalogsProfessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Timestamp,Updated,CreatedById,UpdatedById,Status,NameEn,NamePt")] CatalogsProfession catalogsProfession)
        {

            catalogsProfession.CreatedById = 2;
            catalogsProfession.Timestamp = DateTime.Now;
            catalogsProfession.Updated = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(catalogsProfession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalogsProfession);
        }

        // GET: CatalogsProfessions/Edit/5
        public async Task<IActionResult> Edit(int id,string name,string nameEn,string namePt)
        {
            if (id == 0)
            {
                return NotFound();
            }

            if(name == null)
            {
                name = "";
            }

            if(nameEn == null)
            {
                nameEn = "";
            }
            if(namePt == null)
            {
                namePt = "";
            }

            var catalogsProfession = await _context.CatalogsProfessions.FindAsync(id);
            if (catalogsProfession == null)
            {
                return NotFound();
            }
            return View(catalogsProfession);
        }

        // POST: CatalogsProfessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Timestamp,Updated,CreatedById,UpdatedById,Status,NameEn,NamePt")] CatalogsProfession catalogsProfession)
        {
            if (id != catalogsProfession.Id)
            {
                return NotFound();
            }

            

            catalogsProfession.Updated = DateTime.Now;
            catalogsProfession.UpdatedById = 2;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogsProfession);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogsProfessionExists(catalogsProfession.NamePt))
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
            return View(catalogsProfession);
        }

        // GET: CatalogsProfessions/Delete/5
        public async Task<IActionResult> Delete(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsProfession = await _context.CatalogsProfessions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogsProfession == null)
            {
                return NotFound();
            }

            return View(catalogsProfession);
        }

        // POST: CatalogsProfessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id,string name,string nameEn,string namePt)
        {
            var catalogsProfession = await _context.CatalogsProfessions.FindAsync(id);
            _context.CatalogsProfessions.Remove(catalogsProfession);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogsProfessionExists(string id)
        {
            return _context.CatalogsProfessions.Any(e => e.NamePt == id);
        }
    }
}
