using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Xml.Serialization;
using WebApplication6.mode;

namespace WebApplication6.Controllers
{
    public class OrdersController : Controller
    {
        PhoneSparePartsContext db = new PhoneSparePartsContext();


        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var phoneSparePartsContext = db.Orders.Include(o => o.SIdNavigation).Include(o => o.UIdNavigation);
            return View(await phoneSparePartsContext.ToListAsync());
        }

        public async Task<ActionResult> create(int partId)
        {

            Response.Headers.Add("Cache-Control", "no-cache,no-store,must-revalidate");
            Response.Headers.Add("Pragma", "no-cache");

            var name = HttpContext.Session.GetString("Email");
            if (String.IsNullOrEmpty(name))
            {

                return RedirectToAction("Login", "user");
            }


            var user = await db.Users.FirstOrDefaultAsync(m => m.EMail == HttpContext.Session.GetString("Email"));

            var model = db.Orders.Where(p => p.UId == user.UId && String.IsNullOrEmpty(p.ODate.ToString())); foreach (var item in model)
            {
                if (partId == item.SId)
                    return RedirectToAction("CartForUser", item.OId);
            }

            var sparePart = await db.SpareParts.FirstOrDefaultAsync(m => m.SId == partId);
            var cat = await db.Catagories.FirstOrDefaultAsync(m => m.CId == sparePart.CId);
            sparePart.CIdNavigation = cat;

            var viewModel = new mode.Order
            {
                SIdNavigation = sparePart,
                UIdNavigation = user,

                SId = partId,

                Price = sparePart.price,
                UId = user.UId,
                Quantity = 1

            };



            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OId,SId,UId,ODate,Quantity,Price")] mode.Order order)
        {
            if (ModelState.IsValid)
            {
                db.Add(order);
                await db.SaveChangesAsync();
                return RedirectToAction("CartForUser");
            }

            ViewData["SId"] = new SelectList(db.SpareParts, "SId", "SId", order.SId);
            ViewData["UId"] = new SelectList(db.Users, "UId", "Addres", order.UId);
            return RedirectToAction("CartForUser");
        }


        public async Task<IActionResult> CartForUser()
        {

            Response.Headers.Add("Cache-Control", "no-cache,no-store,must-revalidate");
            Response.Headers.Add("Pragma", "no-cache");

            var name = HttpContext.Session.GetString("Email");
            if (String.IsNullOrEmpty(name))
            {
                var returnUrl = Request.Path.Value;
                return RedirectToAction("Login", "user", new { returnUrl });
            }
            var user = await db.Users.FirstOrDefaultAsync(m => m.EMail == HttpContext.Session.GetString("Email"));
            var model = db.Orders.Where(p => p.UId == user.UId && String.IsNullOrEmpty(p.ODate.ToString())).Include(o => o.SIdNavigation).Include(o => o.UIdNavigation).Include(o => o.SIdNavigation.CIdNavigation);

            return View(await model.ToListAsync());
        }
        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || db.Orders == null)
            {
                return NotFound();
            }

            var order = await db.Orders
                .Include(o => o.SIdNavigation)
                .Include(o => o.UIdNavigation)
                .FirstOrDefaultAsync(m => m.OId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }


        public async Task<IActionResult> Edit(int? id, int? quantity)
        {
            if (id == null || db.Orders == null)
            {
                return NotFound();
            }

            var order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["SId"] = new SelectList(db.SpareParts, "SId", "SId", order.SId);
            ViewData["UId"] = new SelectList(db.Users, "UId", "Addres", order.UId);
            return View(order);
        }

        //POST: Orders/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OId,SId,UId,ODate,Quantity,Price")] mode.Order order)
        {
            if (id != order.OId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(order);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("CartForUser");
            }
            ViewData["SId"] = new SelectList(db.SpareParts, "SId", "SId", order.SId);
            ViewData["UId"] = new SelectList(db.Users, "UId", "Addres", order.UId);
            return RedirectToAction("CartForUser");
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || db.Orders == null)
            {
                return NotFound();
            }

            var order = await db.Orders
                .Include(o => o.SIdNavigation)
                .Include(o => o.UIdNavigation)
                .FirstOrDefaultAsync(m => m.OId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (db.Orders == null)
            {
                return Problem("Entity set 'PhoneSparePartsContext.Orders'  is null.");
            }
            var order = await db.Orders.FindAsync(id);
            if (order != null)
            {
                db.Orders.Remove(order);
            }

            await db.SaveChangesAsync();
            return RedirectToAction("CartForUser");
        }

        private bool OrderExists(int id)
        {
            return (db.Orders?.Any(e => e.OId == id)).GetValueOrDefault();
        }



    }
}
