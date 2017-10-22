using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using JobExplorer.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Mvc.Html;
using System.Security.Claims;
using Microsoft.Owin.Security;

namespace JobExplorer.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        public ActionResult RegisterEmployer()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RegisterEmployer(RegisterEmployerModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser {
                    UserName = model.UserName,
                    Email = model.Email,
                    WebSite = model.WebSite,
                    WorkPlace = model.WorkPlace,
                    City = model.City,
                    FirstName = model.FirstName,
                    SurName = model.SurName
                };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var currentUser = UserManager.FindByName(user.UserName);
                    var roleresult = UserManager.AddToRole(currentUser.Id, "Employer");
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View(model);
        }

        public ActionResult RegisterEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RegisterEmployee(RegisterEmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    WebSite = null,
                    WorkPlace = null,
                    City = null,
                    FirstName = model.FirstName,
                    SurName = model.SurName
                };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var currentUser = UserManager.FindByName(user.UserName);
                    var roleresult = UserManager.AddToRole(currentUser.Id, "Employee");
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View(model);
        }

        public ActionResult AddSpeciality()
        {
            return View();
        }

        

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await UserManager.FindAsync(model.Email, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    ClaimsIdentity claim = await UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    if (String.IsNullOrEmpty(returnUrl))
                        return RedirectToAction("Index", "Home");
                    return Redirect(returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(model);
        }
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }

    }
}