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
    public class CatalogsOpeningclassesController : Controller
    {
        private readonly DbmatteriaContext _context;

        public CatalogsOpeningclassesController(DbmatteriaContext context)
        {
            _context = context;
        }

        // GET: CatalogsOpeningclasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatalogsOpeningclasss.ToListAsync());
        }

        // GET: CatalogsOpeningclasses/Details/5
        public async Task<IActionResult> Details(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsOpeningclass = await _context.CatalogsOpeningclasss
                .FirstOrDefaultAsync(m => m.Id ==id);
            if (catalogsOpeningclass == null)
            {
                return NotFound();
            }

            return View(catalogsOpeningclass);
        }

        // GET: CatalogsOpeningclasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatalogsOpeningclasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameAcr,Name,NameEng,Status,Timestamp,Updated,CreatedById,UpdatedById")] CatalogsOpeningclass catalogsOpeningclass)
        {

            catalogsOpeningclass.CreatedById = 2;
            catalogsOpeningclass.Timestamp = DateTime.Now;
            catalogsOpeningclass.Updated = DateTime.Now;
            

            if (ModelState.IsValid)
            {
                _context.Add(catalogsOpeningclass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalogsOpeningclass);
        }

        // GET: CatalogsOpeningclasses/Edit/5
        public async Task<IActionResult> Edit(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            if(name == null)
            {
                name = "";
            }

            var catalogsOpeningclass = await _context.CatalogsOpeningclasss.FindAsync(id);
            if (catalogsOpeningclass == null)
            {
                return NotFound();
            }
            return View(catalogsOpeningclass);
        }

        // POST: CatalogsOpeningclasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameAcr,Name,NameEng,Status,Timestamp,Updated,CreatedById,UpdatedById")] CatalogsOpeningclass catalogsOpeningclass)
        {
            if (id != catalogsOpeningclass.Id)
            {
                return NotFound();
            }

            
            catalogsOpeningclass.Updated = DateTime.Now;
            catalogsOpeningclass.UpdatedById = 2;


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogsOpeningclass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogsOpeningclassExists(catalogsOpeningclass.NameAcr))
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
            return View(catalogsOpeningclass);
        }

        // GET: CatalogsOpeningclasses/Delete/5
        public async Task<IActionResult> Delete(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsOpeningclass = await _context.CatalogsOpeningclasss
                .FirstOrDefaultAsync(m =>  m.Id == id);
            if (catalogsOpeningclass == null)
            {
                return NotFound();
            }

            return View(catalogsOpeningclass);
        }

        // POST: CatalogsOpeningclasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id,string nameAcr)
        {
            var catalogsOpeningclass = await _context.CatalogsOpeningclasss.FindAsync(id);
            _context.CatalogsOpeningclasss.Remove(catalogsOpeningclass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogsOpeningclassExists(string id)
        {
            return _context.CatalogsOpeningclasss.Any(e => e.NameAcr == id);
        }
    }
}
