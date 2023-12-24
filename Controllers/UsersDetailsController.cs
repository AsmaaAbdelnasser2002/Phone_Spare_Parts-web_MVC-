using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.mode;

namespace WebApplication6.Controllers
{
    public class UsersDetailsController : Controller
    {
        private readonly PhoneSparePartsContext _context;

        public UsersDetailsController(PhoneSparePartsContext context)
        {
            _context = context;
        }

        // GET: UsersDetails
        public async Task<IActionResult> Index()
        {
            return _context.Users != null ?
                        View(await _context.Users.ToListAsync()) :
                        Problem("Entity set 'PhoneSparePartsContext.Users'  is null.");
        }


        // GET: UsersDetails/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Users == null)
        //    {
        //        return NotFound();
        //    }

        //    var users = await _context.Users.FindAsync(id);
        //    if (users == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(users);
        //}

        // POST: UsersDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("UId,FName,LName,EMail,Pass,Addres,Phone,PankCode,clientFile")] Users users)
        //{
        //    if (id != users.UId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        if (users.clientFile != null)
        //        {
        //            MemoryStream stream = new MemoryStream();
        //            users.clientFile.CopyTo(stream);
        //            users.Photo = stream.ToArray();
        //        }
        //        try
        //        {
        //            _context.Update(users);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UsersExists(users.UId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(users);
        //}


        private bool UsersExists(int id)
        {
            return (_context.Users?.Any(e => e.UId == id)).GetValueOrDefault();
        }
    }
}
