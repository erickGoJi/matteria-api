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
    public class CatalogsOpeningservicesController : Controller
    {
        private readonly DbmatteriaContext _context;

        public CatalogsOpeningservicesController(DbmatteriaContext context)
        {
            _context = context;
        }

        // GET: CatalogsOpeningservices
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatalogsOpeningservices.ToListAsync());
        }

        // GET: CatalogsOpeningservices/Details/5
        public async Task<IActionResult> Details(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsOpeningservice = await _context.CatalogsOpeningservices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogsOpeningservice == null)
            {
                return NotFound();
            }

            return View(catalogsOpeningservice);
        }

        // GET: CatalogsOpeningservices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatalogsOpeningservices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,NameEn,Timestamp,Status,Updated,CreatedById,UpdatedById,NamePt")] CatalogsOpeningservice catalogsOpeningservice)
        {

            catalogsOpeningservice.CreatedById = 2;
            catalogsOpeningservice.Timestamp = DateTime.Now;
            catalogsOpeningservice.Updated = DateTime.Now;




            if (ModelState.IsValid)
            {
                _context.Add(catalogsOpeningservice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalogsOpeningservice);
        }

        // GET: CatalogsOpeningservices/Edit/5
        public async Task<IActionResult> Edit(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsOpeningservice = await _context.CatalogsOpeningservices.FindAsync(id);
            if (catalogsOpeningservice == null)
            {
                return NotFound();
            }
            return View(catalogsOpeningservice);
        }

        // POST: CatalogsOpeningservices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,NameEn,Timestamp,Status,Updated,CreatedById,UpdatedById,NamePt")] CatalogsOpeningservice catalogsOpeningservice)
        {

            if (id != catalogsOpeningservice.Id)
            {
                return NotFound();
            }

            


            catalogsOpeningservice.Updated = DateTime.Now;
            catalogsOpeningservice.UpdatedById = 2;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogsOpeningservice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogsOpeningserviceExists(catalogsOpeningservice.Name))
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
            return View(catalogsOpeningservice);
        }

        // GET: CatalogsOpeningservices/Delete/5
        public async Task<IActionResult> Delete(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsOpeningservice = await _context.CatalogsOpeningservices
                .FirstOrDefaultAsync(m =>  m.Id == id);
            if (catalogsOpeningservice == null)
            {
                return NotFound();
            }

            return View(catalogsOpeningservice);
        }

        // POST: CatalogsOpeningservices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id,string name)
        {
            var catalogsOpeningservice = await _context.CatalogsOpeningservices.FindAsync(id);
            _context.CatalogsOpeningservices.Remove(catalogsOpeningservice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogsOpeningserviceExists(string id)
        {
            return _context.CatalogsOpeningservices.Any(e => e.Name == id);
        }
    }
}
