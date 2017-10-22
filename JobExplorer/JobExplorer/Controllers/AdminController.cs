using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using JobExplorer.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Mvc.Html;
using System.Security.Claims;
using Microsoft.Owin.Security;

namespace JobExplorer.Controllers
{

    public class AdminController : Controller
    {
        // GET: Admin
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

        private ApplicationRoleManager RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
        }

        public ActionResult DisplayUsers()
        {
            ApplicationContext ac = new ApplicationContext();
            List<ApplicationUser> users = ac.Users.ToList();
            ViewBag.Users = users;
            List<List<string>> roles = new List<List<string>>();
            foreach (var item in users)
            {
                roles.Add((UserManager.GetRoles(item.Id)) as List<string>);
            }
            ViewBag.Roles = roles;
            return PartialView();
        }
        

        [HttpPost]
        public ActionResult AddSpeciality(string name)
        {
            ApplicationContext ac = new ApplicationContext();
            var speciality = new Speciality() { Name = name };
            ac.Specialities.Add(speciality);
            ac.SaveChanges();
           // DisplaySpecialities();
            return PartialView("DisplaySpecialities");
        }

        [HttpPost]
        public ActionResult DeleteSpeciality(int id)
        {
            ApplicationContext ac = new ApplicationContext();
            Speciality speciality = ac.Specialities.Where(o => o.Id == id).FirstOrDefault();
            ac.Specialities.Remove(speciality);
            ac.SaveChanges();
          //  DisplaySpecialities();
            return PartialView("DisplaySpecialities");
        }

        public ActionResult EditSpecialities(string name)
        {
            ApplicationContext ac = new ApplicationContext();
            var specs = ac.Specialities.Where(a => a.Name.Contains(name)).ToList();
            ViewBag.Specialities = specs;
            return PartialView(specs);
        }

        [HttpPost]
        public ActionResult EditSpecialities(Speciality model,int id=-1)
        {
            ApplicationContext ac = new ApplicationContext();
            if (id == -1)
            {
                Speciality speciality = new Speciality() { Name = model.Name };
                ac.Specialities.Add(speciality);
                ac.SaveChanges();
            }
            else
            {
                Speciality speciality = ac.Specialities.Where(o => o.Id == id).FirstOrDefault();
                ac.Specialities.Remove(speciality);
                ac.SaveChanges();
            }
            IEnumerable<Speciality> specs = ac.Specialities;
            ViewBag.Specialities = specs;
            return View(model);
        }

    }
}