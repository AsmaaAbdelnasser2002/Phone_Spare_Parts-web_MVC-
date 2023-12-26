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
    public class PaymentsController : Controller
    {
        private readonly PhoneSparePartsContext _context;
        PhoneSparePartsContext db = new PhoneSparePartsContext();
        public PaymentsController(PhoneSparePartsContext context)
        {
            _context = context;
        }

        // GET: Payments

        public async Task<IActionResult> Index()
        {
             Response.Headers.Add("Cache-Control", "no-cache,no-store,must-revalidate");
             Response.Headers.Add("Pragma", "no-cache");

             var name = HttpContext.Session.GetString("Email");
             if (System.String.IsNullOrEmpty(name))
             {
                  var returnUrl = Request.Path.Value;
                   return RedirectToAction("Login", "user");
             }
            var phoneSparePartsContext = _context.Payments.Include(p => p.OIdNavigation).Include(p => p.OIdNavigation.SIdNavigation)
                .Include(p => p.OIdNavigation.SIdNavigation.CIdNavigation).Include(p => p.OIdNavigation.UIdNavigation);
            return View(await phoneSparePartsContext.ToListAsync());
        }
        public async Task<IActionResult> paiedforuser()
        {

            Response.Headers.Add("Cache-Control", "no-cache,no-store,must-revalidate");
            Response.Headers.Add("Pragma", "no-cache");

            var name = HttpContext.Session.GetString("Email");
            if (String.IsNullOrEmpty(name))
            {
                var returnUrl = Request.Path.Value;
                return RedirectToAction("Login", "user", new { returnUrl });
            }
            var user = await _context.Users.FirstOrDefaultAsync(m => m.EMail == HttpContext.Session.GetString("Email"));

            var pay = _context.Payments.Where(p => p.OIdNavigation.UId == user.UId && p.OIdNavigation.ODate != null)
                .Include(o => o.OIdNavigation).Include(o => o.OIdNavigation.SIdNavigation).Include(o => o.OIdNavigation.SIdNavigation.CIdNavigation);

            return View(await pay.ToListAsync());
        }
        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Payments == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments
                .Include(p => p.OIdNavigation)
                .FirstOrDefaultAsync(m => m.PId == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Payments/Create

        public async Task<IActionResult> Create(int ordid)
        {
            Response.Headers.Add("Cache-Control", "no-cache,no-store,must-revalidate");
            Response.Headers.Add("Pragma", "no-cache");

            var name = HttpContext.Session.GetString("Email");
            if (String.IsNullOrEmpty(name))
            {

                return RedirectToAction("Login", "user");
            }


            var user = await _context.Users.FirstOrDefaultAsync(m => m.EMail == HttpContext.Session.GetString("Email"));

            var order = await _context.Orders.FirstOrDefaultAsync(m => m.OId == ordid);
            var sparepart = await _context.SpareParts.FirstOrDefaultAsync(m => m.SId == order.SId);
            order.SIdNavigation = sparepart;
            var viewModel = new Payment
            {
                OIdNavigation = order,
                PDate = DateTime.Now,
                PMethod = "Cach",
                TotalPrice = order.Price * order.Quantity


            };
            order.ODate = DateTime.Now;
            _context.Update(order);
            await _context.SaveChangesAsync();

            _context.Add(viewModel);
            await _context.SaveChangesAsync();
            ViewData["OId"] = new SelectList(_context.Orders, "OId", "OId");
            return RedirectToAction("CartForUser", "Orders");
        }
        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Payments == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            ViewData["OId"] = new SelectList(_context.Orders, "OId", "OId", payment.OId);
            return View(payment);
        }

        // POST: Payments/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PId,PMethod,PDate,TotalPrice,OId")] Payment payment)
        {
            if (id != payment.PId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(payment.PId))
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
            ViewData["OId"] = new SelectList(_context.Orders, "OId", "OId", payment.OId);
            return View(payment);
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Payments == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments
                .Include(p => p.OIdNavigation)
                .FirstOrDefaultAsync(m => m.PId == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Payments == null)
            {
                return Problem("Entity set 'PhoneSparePartsContext.Payments'  is null.");
            }
            var payment = await _context.Payments.FindAsync(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("CartForUser", "Orders");
        }

        private bool PaymentExists(int id)
        {
            return (_context.Payments?.Any(e => e.PId == id)).GetValueOrDefault();
        }
    }
}
