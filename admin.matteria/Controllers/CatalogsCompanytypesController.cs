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
    public class CatalogsCompanytypesController : Controller
    {
        private readonly DbmatteriaContext _context;

        public CatalogsCompanytypesController(DbmatteriaContext context)
        {
            _context = context;
        }

        // GET: CatalogsCompanytypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatalogsCompanytypes.ToListAsync());
        }

        // GET: CatalogsCompanytypes/Details/5
        public async Task<IActionResult> Details(int? id,string name)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogsCompanytype = await _context.CatalogsCompanytypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogsCompanytype == null)
            {
                return NotFound();
            }

            return View(catalogsCompanytype);
        }

        // GET: CatalogsCompanytypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatalogsCompanytypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Status,Timestamp,Updated,CreatedById,UpdatedById,NameEn,NamePt")] CatalogsCompanytype catalogsCompanytype)
        {

            catalogsCompanytype.Timestamp = DateTime.Now;
            catalogsCompanytype.Updated = DateTime.Now;
            
            catalogsCompanytype.CreatedById = 2;
            
            if (ModelState.IsValid)
            {
                _context.Add(catalogsCompanytype);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalogsCompanytype);
        }

        // GET: CatalogsCompanytypes/Edit/5
        public async Task<IActionResult> Edit(int? id,string name)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogsCompanytype = await _context.CatalogsCompanytypes.FindAsync(id);
            if (catalogsCompanytype == null)
            {
                return NotFound();
            }
            return View(catalogsCompanytype);
        }

        // POST: CatalogsCompanytypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status,Timestamp,Updated,CreatedById,UpdatedById,NameEn,NamePt")] CatalogsCompanytype catalogsCompanytype)
        {
            if (id != catalogsCompanytype.Id)
            {
                return NotFound();
            }

            catalogsCompanytype.UpdatedById = 2;
            catalogsCompanytype.Updated = DateTime.Now;



            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogsCompanytype);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogsCompanytypeExists(catalogsCompanytype.Id))
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
            return View(catalogsCompanytype);
        }

        // GET: CatalogsCompanytypes/Delete/5
        public async Task<IActionResult> Delete(int? id,string name)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogsCompanytype = await _context.CatalogsCompanytypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogsCompanytype == null)
            {
                return NotFound();
            }

            return View(catalogsCompanytype);
        }

        // POST: CatalogsCompanytypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id,string name)
        {
            var catalogsCompanytype = await _context.CatalogsCompanytypes.FindAsync(id);
            _context.CatalogsCompanytypes.Remove(catalogsCompanytype);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogsCompanytypeExists(int id)
        {
            return _context.CatalogsCompanytypes.Any(e => e.Id == id);
        }
    }
}
