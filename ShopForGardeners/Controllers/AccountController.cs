using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ShopForGardeners.Data.Interfaces;
using ShopForGardeners.Data.Models;
using Microsoft.AspNetCore.Identity;
using ShopForGardeners.ViewModels;
using System.Net.Mail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using ShopForGardeners.Models;

namespace ShopForGardeners.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAccount _iaccount;
        private SignInManager<AppUser> signInManager;
        private Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager;
        public int VerifiticationCode = 4973;
        public AccountController(IAccount iaccount)
        {
            _iaccount = iaccount;
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
                    await Authenticate(model.Login); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        [AllowAnonymous]
        public ViewResult Login(string returnrUrl)
        {
            VerifiticationCode = new Random().Next(1000, 9999);
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
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.Login,
                    Email = model.Email
                };
                User user = _iaccount.AllAccounts.FirstOrDefault(u => u.Login == model.Login);
                Microsoft.AspNetCore.Identity.IdentityResult result
                    = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // добавляем пользователя в бд
                    await _iaccount.createUser(model);

                    await Authenticate(model.Login); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        public class Verification
        {
            public static int Code;
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User usermdl)
        {
            Verification.Code = new Random().Next(1000, 9999);
            if (ModelState.IsValid)
            {
                AppUser user =
                await userManager.FindByNameAsync(usermdl.Name);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user,
                    usermdl.Password, false, false)).Succeeded)
                    {
                        try
                        {

                            MailMessage mail = new MailMessage();
                            mail.To.Add(user.Email);
                            mail.From = new MailAddress("linuxkalibsuir@gmail.com");
                            mail.Subject = "Verification";
                            mail.Body = "Your code is: " + Verification.Code;
                            mail.IsBodyHtml = true;
                            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = new System.Net.NetworkCredential("linuxkalibsuir@gmail.com", "KaliTest123");
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                            return Redirect("/Account/Confirm");
                        }
                        catch (Exception e)
                        {
                            ModelState.AddModelError("", "An error occured during the process, please try again!");
                            return View(usermdl);
                        }

                    }
                }
            }
            ModelState.AddModelError("", "Invalid name or password");
            return View(usermdl);
        }
        [HttpPost]

        public IActionResult Confirm(AuthenticationModel model)
        {
            if (ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("debug: " + Verification.Code + " and " + VerifiticationCode.ToString() + " and ");
                if (model.Verification.Equals(Verification.Code.ToString()))
                {
                    return Redirect("/Product/Index");

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

        private void AddErrorsFromResult(Microsoft.AspNetCore.Identity.IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }



}
