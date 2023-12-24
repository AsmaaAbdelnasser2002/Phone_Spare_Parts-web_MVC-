using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Numerics;
using WebApplication6.mode;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class HomeController : Controller
    {
        PhoneSparePartsContext db = new PhoneSparePartsContext();
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Brands()
        {
            return View();
        }
        public IActionResult main()
        {
            return View();
        }
        public IActionResult contact()
        {
            return View();
        }
        public IActionResult about()
        {
            return View();
        }

        public async Task<IActionResult> profile()
        {
            Response.Headers.Add("Cache-Control", "no-cache,no-store,must-revalidate"); Response.Headers.Add("Pragma", "no-cache");
            var name = HttpContext.Session.GetString("Email");
            if (String.IsNullOrEmpty(name))
            {

                var returnUrl = Request.Path.Value;
                return RedirectToAction("Login", "user", new { returnUrl });
            }
            var user = await db.Users.FirstOrDefaultAsync(m => m.EMail == HttpContext.Session.GetString("Email"));
            return View(user);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}