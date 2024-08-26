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
    public class CatalogsAdchannelsController : Controller
    {
        private readonly DbmatteriaContext _context;

        public CatalogsAdchannelsController(DbmatteriaContext context)
        {
            _context = context;
        }

        // GET: CatalogsAdchannels
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatalogsAdchannels.ToListAsync());
        }

        // GET: CatalogsAdchannels/Details/5
        public async Task<IActionResult> Details(int id, string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsAdchannel = await _context.CatalogsAdchannels
                .FirstOrDefaultAsync(m => m.Name == name && m.Id == id);
            if (catalogsAdchannel == null)
            {
                return NotFound();
            }

            return View(catalogsAdchannel);
        }

        // GET: CatalogsAdchannels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatalogsAdchannels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Status,Timestamp,Updated,CreatedById,UpdatedById,NameEn,NamePt")] CatalogsAdchannel catalogsAdchannel)
        {

            catalogsAdchannel.Updated = DateTime.Now;
            catalogsAdchannel.UpdatedById = null;
            catalogsAdchannel.Timestamp = DateTime.Now;
            catalogsAdchannel.CreatedById = 10901;
            if (ModelState.IsValid)
            {
                _context.Add(catalogsAdchannel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalogsAdchannel);
        }

        // GET: CatalogsAdchannels/Edit/5
        public async Task<IActionResult> Edit(int id,string name)
        {
            
            if (id == 0)
            {
                return NotFound();
            }

            
            var catalogsAdchannel = await _context.CatalogsAdchannels.FindAsync(id);
            if (catalogsAdchannel == null)
            {
                return NotFound();
            }
            return View(catalogsAdchannel);
        }

        // POST: CatalogsAdchannels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status,Timestamp,Updated,CreatedById,UpdatedById,NameEn,NamePt")] CatalogsAdchannel catalogsAdchannel)
        {
            if (id == 0)
            {
                return NotFound();
            }

            
            catalogsAdchannel.Updated = DateTime.Now;
            catalogsAdchannel.UpdatedById = 2;
            

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogsAdchannel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogsAdchannelExists(catalogsAdchannel.Name))
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
            return View(catalogsAdchannel);
        }

        // GET: CatalogsAdchannels/Delete/5
        public async Task<IActionResult> Delete(int id, string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsAdchannel = await _context.CatalogsAdchannels
                .FirstOrDefaultAsync(m =>  m.Id == id);
            if (catalogsAdchannel == null)
            {
                return NotFound();
            }

            return View(catalogsAdchannel);
        }

        // POST: CatalogsAdchannels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id,string name)
        {
            var catalogsAdchannel = await _context.CatalogsAdchannels.FindAsync(id);
            _context.CatalogsAdchannels.Remove(catalogsAdchannel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogsAdchannelExists(string id)
        {
            return _context.CatalogsAdchannels.Any(e => e.Name == id);
        }
    }
}
