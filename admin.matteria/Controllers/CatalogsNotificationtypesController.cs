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
    public class CatalogsNotificationtypesController : Controller
    {
        private readonly DbmatteriaContext _context;

        public CatalogsNotificationtypesController(DbmatteriaContext context)
        {
            _context = context;
        }

        // GET: CatalogsNotificationtypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatalogsNotificationtypes.ToListAsync());
        }

        // GET: CatalogsNotificationtypes/Details/5
        public async Task<IActionResult> Details(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsNotificationtype = await _context.CatalogsNotificationtypes
                .FirstOrDefaultAsync(m =>  m.Id==id);
            if (catalogsNotificationtype == null)
            {
                return NotFound();
            }

            return View(catalogsNotificationtype);
        }

        // GET: CatalogsNotificationtypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatalogsNotificationtypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Status,Timestamp,Updated,CreatedById,UpdatedById,NameEn,NamePt")] CatalogsNotificationtype catalogsNotificationtype)
        {

            catalogsNotificationtype.CreatedById = 2;
            catalogsNotificationtype.Timestamp = DateTime.Now;
            catalogsNotificationtype.Updated = DateTime.Now;
            

            if (ModelState.IsValid)
            {
                _context.Add(catalogsNotificationtype);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalogsNotificationtype);
        }

        // GET: CatalogsNotificationtypes/Edit/5
        public async Task<IActionResult> Edit(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsNotificationtype = await _context.CatalogsNotificationtypes.FindAsync(id);
            if (catalogsNotificationtype == null)
            {
                return NotFound();
            }
            return View(catalogsNotificationtype);
        }

        // POST: CatalogsNotificationtypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status,Timestamp,Updated,CreatedById,UpdatedById,NameEn,NamePt")] CatalogsNotificationtype catalogsNotificationtype)
        {
            if (id != catalogsNotificationtype.Id)
            {
                return NotFound();
            }

            catalogsNotificationtype.Updated = DateTime.Now;
            catalogsNotificationtype.UpdatedById = 2;


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogsNotificationtype);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogsNotificationtypeExists(catalogsNotificationtype.Name))
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
            return View(catalogsNotificationtype);
        }

        // GET: CatalogsNotificationtypes/Delete/5
        public async Task<IActionResult> Delete(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsNotificationtype = await _context.CatalogsNotificationtypes
                .FirstOrDefaultAsync(m =>  m.Id ==id);
            if (catalogsNotificationtype == null)
            {
                return NotFound();
            }

            return View(catalogsNotificationtype);
        }

        // POST: CatalogsNotificationtypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id,string name)
        {
            var catalogsNotificationtype = await _context.CatalogsNotificationtypes.FindAsync(id);
            _context.CatalogsNotificationtypes.Remove(catalogsNotificationtype);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogsNotificationtypeExists(string id)
        {
            return _context.CatalogsNotificationtypes.Any(e => e.Name == id);
        }
    }
}
