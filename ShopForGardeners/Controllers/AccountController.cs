using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopForGardeners.Data.Interfaces;
using ShopForGardeners.Data.Models;
using ShopForGardeners.Models;
using ShopForGardeners.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShopForGardeners.Controllers
{

    public class AccountController : Controller
    {
        private readonly IAccount _iaccount;
        private int VerificationCode;
        public AccountController(IAccount iaccount)
        {
            _iaccount = iaccount;
            VerificationCode = new Random().Next(1000, 9999);
            
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _iaccount.AllAccounts.FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(model.Login);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        [AllowAnonymous]
        public ViewResult Login(string returnrUrl)
        {
            VerificationCode = new Random().Next(1000, 9999);
            return View(new LoginModel
            {
                ReturnUrl = returnrUrl
            });
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _iaccount.AllAccounts.FirstOrDefault(u => u.Login == model.Login);
                if (user == null)
                {
                    await _iaccount.createUser(model);
                    await Authenticate(model.Login);

                    MailMessage mail = new MailMessage();
                    mail.To.Add(model.Email);
                    mail.From = new MailAddress("lab6spo@gmail.com");
                    mail.Subject = "Verification";
                    mail.Body = "Your code is: " + VerificationCode;
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("lab6spo@gmail.com", "My##my00");
                    smtp.EnableSsl = true;

                    smtp.Send(mail);
                    return RedirectToAction("Confirm", "Account");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        public ViewResult Confirm(string returnUrl)
        {
            return View(new AuthenticationModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public IActionResult Confirm(AuthenticationModel model)
        {
            if (ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("debug: " + VerificationCode + " and " + VerificationCode.ToString() + " and ");
                if (model.Verification.Equals(VerificationCode.ToString()))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Code");
                    return View(model);
                }

            }
            ModelState.AddModelError("", "Invalid Code");
            return View(model);
        }
    }

    public class Verification
    {
        public static int Code;
    }
}
