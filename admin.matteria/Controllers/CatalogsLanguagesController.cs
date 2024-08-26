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
    public class CatalogsLanguagesController : Controller
    {
        private readonly DbmatteriaContext _context;

        public CatalogsLanguagesController(DbmatteriaContext context)
        {
            _context = context;
        }

        // GET: CatalogsLanguages
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatalogsLanguages.ToListAsync());
        }

        // GET: CatalogsLanguages/Details/5
        public async Task<IActionResult> Details(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsLanguage = await _context.CatalogsLanguages
                .FirstOrDefaultAsync(m =>  m.Id == id);
            if (catalogsLanguage == null)
            {
                return NotFound();
            }

            return View(catalogsLanguage);
        }

        // GET: CatalogsLanguages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatalogsLanguages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Status,Timestamp,Updated,CreatedById,UpdatedById,NameEn,NamePt")] CatalogsLanguage catalogsLanguage)
        {


            catalogsLanguage.CreatedById = 2;
            catalogsLanguage.Timestamp = DateTime.Now;
            catalogsLanguage.Updated = DateTime.Now;
            

            if (ModelState.IsValid)
            {
                _context.Add(catalogsLanguage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalogsLanguage);
        }

        // GET: CatalogsLanguages/Edit/5
        public async Task<IActionResult> Edit(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsLanguage = await _context.CatalogsLanguages.FindAsync(id);
            if (catalogsLanguage == null)
            {
                return NotFound();
            }
            return View(catalogsLanguage);
        }

        // POST: CatalogsLanguages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status,Timestamp,Updated,CreatedById,UpdatedById,NameEn,NamePt")] CatalogsLanguage catalogsLanguage)
        {
            if (id != catalogsLanguage.Id)
            {
                return NotFound();
            }

            
            catalogsLanguage.Updated = DateTime.Now;
            catalogsLanguage.UpdatedById = 2;


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogsLanguage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogsLanguageExists(catalogsLanguage.Name))
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
            return View(catalogsLanguage);
        }

        // GET: CatalogsLanguages/Delete/5
        public async Task<IActionResult> Delete(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsLanguage = await _context.CatalogsLanguages
                .FirstOrDefaultAsync(m =>  m.Id == id);
            if (catalogsLanguage == null)
            {
                return NotFound();
            }

            return View(catalogsLanguage);
        }

        // POST: CatalogsLanguages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id,string name)
        {
            var catalogsLanguage = await _context.CatalogsLanguages.FindAsync(id);
            _context.CatalogsLanguages.Remove(catalogsLanguage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogsLanguageExists(string id)
        {
            return _context.CatalogsLanguages.Any(e => e.Name == id);
        }
    }
}
