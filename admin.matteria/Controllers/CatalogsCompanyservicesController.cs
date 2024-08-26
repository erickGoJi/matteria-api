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
    public class CatalogsCompanyservicesController : Controller
    {
        private readonly DbmatteriaContext _context;

        public CatalogsCompanyservicesController(DbmatteriaContext context)
        {
            _context = context;
        }

        // GET: CatalogsCompanyservices
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatalogsCompanyservice.ToListAsync());
        }

        // GET: CatalogsCompanyservices/Details/5
        public async Task<IActionResult> Details(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsCompanyservice = await _context.CatalogsCompanyservice
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogsCompanyservice == null)
            {
                return NotFound();
            }

            return View(catalogsCompanyservice);
        }

        // GET: CatalogsCompanyservices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatalogsCompanyservices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Timestamp,Updated,CreatedById,Status,UpdatedById,NameEn,NamePt")] CatalogsCompanyservice catalogsCompanyservice)
        {

            catalogsCompanyservice.Timestamp = DateTime.Now;
            catalogsCompanyservice.Updated = DateTime.Now;
            catalogsCompanyservice.CreatedById = 2;
            

            if (ModelState.IsValid)
            {
                _context.Add(catalogsCompanyservice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalogsCompanyservice);
        }

        // GET: CatalogsCompanyservices/Edit/5
        public async Task<IActionResult> Edit(int? id,string name)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogsCompanyservice = await _context.CatalogsCompanyservice.FindAsync(id);
            if (catalogsCompanyservice == null)
            {
                return NotFound();
            }
            return View(catalogsCompanyservice);
        }

        // POST: CatalogsCompanyservices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Timestamp,Updated,CreatedById,Status,UpdatedById,NameEn,NamePt")] CatalogsCompanyservice catalogsCompanyservice)
        {
            if (id != catalogsCompanyservice.Id)
            {
                return NotFound();
            }

            catalogsCompanyservice.Updated = DateTime.Now;
            catalogsCompanyservice.UpdatedById = 2;
            

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogsCompanyservice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogsCompanyserviceExists(catalogsCompanyservice.Id))
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
            return View(catalogsCompanyservice);
        }

        // GET: CatalogsCompanyservices/Delete/5
        public async Task<IActionResult> Delete(int? id,string name)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogsCompanyservice = await _context.CatalogsCompanyservice
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogsCompanyservice == null)
            {
                return NotFound();
            }

            return View(catalogsCompanyservice);
        }

        // POST: CatalogsCompanyservices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id,string name)
        {
            var catalogsCompanyservice = await _context.CatalogsCompanyservice.FindAsync(id);
            _context.CatalogsCompanyservice.Remove(catalogsCompanyservice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogsCompanyserviceExists(int id)
        {
            return _context.CatalogsCompanyservice.Any(e => e.Id == id);
        }
    }
}
