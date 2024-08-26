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
    public class CatalogsInterestsController : Controller
    {
        private readonly DbmatteriaContext _context;

        public CatalogsInterestsController(DbmatteriaContext context)
        {
            _context = context;
        }

        // GET: CatalogsInterests
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatalogsInterests.ToListAsync());
        }

        // GET: CatalogsInterests/Details/5
        public async Task<IActionResult> Details(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsInterest = await _context.CatalogsInterests
                .FirstOrDefaultAsync(m =>  m.Id == id);
            if (catalogsInterest == null)
            {
                return NotFound();
            }

            return View(catalogsInterest);
        }

        // GET: CatalogsInterests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatalogsInterests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Timestamp,Updated,CreatedById,UpdatedById,Status,NameEn,NamePt")] CatalogsInterest catalogsInterest)
        {


            catalogsInterest.CreatedById = 2;
            catalogsInterest.Updated = DateTime.Now;
            
            catalogsInterest.Timestamp = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(catalogsInterest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalogsInterest);
        }

        // GET: CatalogsInterests/Edit/5
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

            var catalogsInterest = await _context.CatalogsInterests.FindAsync(id);
            if (catalogsInterest == null)
            {
                return NotFound();
            }
            return View(catalogsInterest);
        }

        // POST: CatalogsInterests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Timestamp,Updated,CreatedById,UpdatedById,Status,NameEn,NamePt")] CatalogsInterest catalogsInterest)
        {
            if (id != catalogsInterest.Id)
            {
                return NotFound();
            }

            
            catalogsInterest.Updated = DateTime.Now;
            catalogsInterest.UpdatedById = 2;
            

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogsInterest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogsInterestExists(catalogsInterest.NamePt))
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
            return View(catalogsInterest);
        }

        // GET: CatalogsInterests/Delete/5
        public async Task<IActionResult> Delete(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsInterest = await _context.CatalogsInterests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogsInterest == null)
            {
                return NotFound();
            }

            return View(catalogsInterest);
        }

        // POST: CatalogsInterests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id,string name,string nameEn,string namePt)
        {
            var catalogsInterest = await _context.CatalogsInterests.FindAsync(id);
            _context.CatalogsInterests.Remove(catalogsInterest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogsInterestExists(string id)
        {
            return _context.CatalogsInterests.Any(e => e.NamePt == id);
        }
    }
}
