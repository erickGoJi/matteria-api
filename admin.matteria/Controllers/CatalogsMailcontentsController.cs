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
    public class CatalogsMailcontentsController : Controller
    {
        private readonly DbmatteriaContext _context;

        public CatalogsMailcontentsController(DbmatteriaContext context)
        {
            _context = context;
        }

        // GET: CatalogsMailcontents
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatalogsMailcontents.ToListAsync());
        }

        // GET: CatalogsMailcontents/Details/5
        public async Task<IActionResult> Details(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsMailcontent = await _context.CatalogsMailcontents
                .FirstOrDefaultAsync(m =>  m.Id ==id);
            if (catalogsMailcontent == null)
            {
                return NotFound();
            }

            return View(catalogsMailcontent);
        }

        // GET: CatalogsMailcontents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatalogsMailcontents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Title,TitleEn,Subject,SubjectEn,Content,ContentEn,NameEn,NamePt")] CatalogsMailcontent catalogsMailcontent)
        {

            

            if (ModelState.IsValid)
            {
                _context.Add(catalogsMailcontent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalogsMailcontent);
        }

        // GET: CatalogsMailcontents/Edit/5
        public async Task<IActionResult> Edit(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsMailcontent = await _context.CatalogsMailcontents.FindAsync(id);
            if (catalogsMailcontent == null)
            {
                return NotFound();
            }
            return View(catalogsMailcontent);
        }

        // POST: CatalogsMailcontents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Title,TitleEn,Subject,SubjectEn,Content,ContentEn,NameEn,NamePt")] CatalogsMailcontent catalogsMailcontent)
        {
            if (id != catalogsMailcontent.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogsMailcontent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogsMailcontentExists(catalogsMailcontent.Name))
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
            return View(catalogsMailcontent);
        }

        // GET: CatalogsMailcontents/Delete/5
        public async Task<IActionResult> Delete(int id,string name)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var catalogsMailcontent = await _context.CatalogsMailcontents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogsMailcontent == null)
            {
                return NotFound();
            }

            return View(catalogsMailcontent);
        }

        // POST: CatalogsMailcontents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id,string name)
        {
            var catalogsMailcontent = await _context.CatalogsMailcontents.FindAsync(id);
            _context.CatalogsMailcontents.Remove(catalogsMailcontent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogsMailcontentExists(string id)
        {
            return _context.CatalogsMailcontents.Any(e => e.Name == id);
        }
    }
}
