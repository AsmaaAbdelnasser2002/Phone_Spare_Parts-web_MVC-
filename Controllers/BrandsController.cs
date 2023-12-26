using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication6.mode;

namespace WebApplication6.Controllers
{
    public class BrandsController : Controller
    {
        private readonly PhoneSparePartsContext _context;

        public BrandsController(PhoneSparePartsContext context)
        {
            _context = context;
        }

        // GET: Brands
        public async Task<IActionResult> Index()
        {
                return _context.Brands != null ?
                            View(await _context.Brands.ToListAsync()) :
                            Problem("Entity set 'PhoneSparePartsContext.Brands'  is null.");
         
        }
        public async Task<IActionResult> brands(string Search)
        {
            if (!String.IsNullOrEmpty(Search))
            {
                var search = _context.Brands.Where(n => n.BName.ToLower().Contains(Search.ToLower())).ToList();
                return View(search);
            }
            else
            {
                return _context.Brands != null ?
                            View(await _context.Brands.ToListAsync()) :
                            Problem("Entity set 'PhoneSparePartsContext.Brands'  is null.");
            }
        }
        // GET: Brands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Brands == null)
            {
                return NotFound();
            }

            var brand = await _context.Brands
                .FirstOrDefaultAsync(m => m.BId == id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // GET: Brands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Brands/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BId,BName,Country,clientFile")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                if (brand.clientFile != null)
                {
                    MemoryStream stream = new MemoryStream();
                    brand.clientFile.CopyTo(stream);
                    brand.Photo = stream.ToArray();
                }
                _context.Add(brand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        // GET: Brands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Brands == null)
            {
                return NotFound();
            }

            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        // POST: Brands/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BId,BName,Country,clientFile")] Brand brand)
        {
            if (id != brand.BId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (brand.clientFile != null)
                {
                    MemoryStream stream = new MemoryStream();
                    brand.clientFile.CopyTo(stream);
                    brand.Photo = stream.ToArray();
                }
                try
                {
                    _context.Update(brand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandExists(brand.BId))
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
            return View(brand);
        }

        // GET: Brands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Brands == null)
            {
                return NotFound();
            }

            var brand = await _context.Brands
                .FirstOrDefaultAsync(m => m.BId == id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // POST: Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Brands == null)
            {
                return Problem("Entity set 'PhoneSparePartsContext.Brands'  is null.");
            }
            var brand = await _context.Brands.FindAsync(id);
            if (brand != null)
            {
                _context.Brands.Remove(brand);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrandExists(int id)
        {
          return (_context.Brands?.Any(e => e.BId == id)).GetValueOrDefault();
        }
    }
}
