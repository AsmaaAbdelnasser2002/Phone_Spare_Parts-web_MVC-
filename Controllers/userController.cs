using Microsoft.AspNetCore.Mvc;
using phone_spare_partes.data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using WebApplication6.mode;
using static System.Runtime.InteropServices.JavaScript.JSType;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace WebApplication6.Controllers
{
    public class userController : Controller
    {
        private readonly IHttpContextAccessor _context;
        private readonly IHostingEnvironment _host;
        PhoneSparePartsContext db = new PhoneSparePartsContext();
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Users _user)
        {
            if (ModelState.IsValid)
            {

                if (_user.clientFile != null)
                {
                    MemoryStream stream = new MemoryStream();
                    _user.clientFile.CopyTo(stream);
                    _user.Photo = stream.ToArray();
                }
                var check = db.Users.FirstOrDefault(s => s.EMail == _user.EMail);
                if (check == null)
                {

                    string input = _user.Pass;
                    if (!string.IsNullOrEmpty(input))
                    {
                        _user.Pass = pass_hash.Hashpassword(input);

                    }
                    db.Users.Add(_user);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }

            }
            return View();

        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(mode.Users us, string returnUrl)
        {
            var obj = db.Users.Where(a => a.EMail.Equals(us.EMail) && a.Pass.Equals(pass_hash.Hashpassword(us.Pass))).FirstOrDefault();
            if (obj != null)
            {
                if (us.EMail == "Admin2@gmail.com")
                {
                    return RedirectToAction("Index", "AdminSpare");
                }
                else
                {
                    var sessionId = HttpContext.Session.Id;
                    HttpContext.Session.SetString("Email", us.EMail);
                    Response.Cookies.Append("SessionId", sessionId, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        Expires = DateTime.UtcNow.AddMinutes(30)
                    });
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                        return RedirectToAction("Home", "Home");
                }


            }
            else
            {
                ViewBag.ErrorMessage = "Email or PassWord Is Not Correct";
                return View();
            }
            return View();
        }
        public ActionResult Logout()
        {
            Response.Cookies.Delete("SessionId");
            HttpContext.Session.Clear();
            return RedirectToAction("Home", "Home");
        }

    }
}
