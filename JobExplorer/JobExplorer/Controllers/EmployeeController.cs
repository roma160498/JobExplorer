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
using System.Net;

namespace JobExplorer.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class EmployeeController : Controller
    {
        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        private void ActionBeforeIndex(ApplicationUser user)
        {
            ApplicationContext ac = new ApplicationContext();
            ViewBag.AuthUser = user;

            var a = ac.Resumes
            .Where(o => o.CreatorLogin == User.Identity.Name)
            .Count();
            ViewBag.ResumesCount = a;

            IEnumerable<Resume> resumes = ac.Resumes
            .Where(o => o.CreatorLogin == User.Identity.Name);
            List<Speciality> specs2 = new List<Speciality>(ac.Specialities);

            List<string> ResumesSpecs = new List<string>();
            foreach (var i in resumes)
            {
                foreach (var j in (specs2))
                    if (i.SpecialityId == (j as Speciality).Id)
                        ResumesSpecs.Add(j.Name);
            }
            SelectList specs = new SelectList(ac.Specialities, "Id", "Name");
            ViewBag.Specialities = specs;
            ViewBag.Resumes = resumes;
            ViewBag.SpecialitiesInResume = ResumesSpecs;
        }

        public async Task<ActionResult> Index()
        {
            

            string id = User.Identity.GetUserId();
            ApplicationUser user = await UserManager.FindByIdAsync(id);

            ActionBeforeIndex(user);


            return View();
        }

        public ActionResult CreateResume()
        {
            ApplicationContext ac = new ApplicationContext();
            SelectList specs = new SelectList(ac.Specialities, "Id", "Name");
            ViewBag.Specialities = specs;
            return View();
        }

        [HttpPost]
        public ActionResult CreateResume(Resume model)
        {
            //if (ModelState.IsValid)
            {
                ApplicationContext ac = new ApplicationContext();

                Resume resume = new Resume()
                {
                    sex = (model.sex).ToString(),
                    City = model.City,
                    Relocation = model.Relocation,
                    BusinessTrip = model.BusinessTrip,
                    PhoneNumber = model.PhoneNumber,
                    Skype = model.Skype,
                    Email = model.Email,
                    EducationLevel = model.EducationLevel,
                    Institution = model.Institution,
                    Faculty = model.Faculty,
                    SpecialityId = model.Speciality.Id,
                    AdditionalInformation = model.AdditionalInformation,
                    DateOfCreation = DateTime.Now,
                    CreatorLogin = User.Identity.Name
                };
                ac.Resumes.Add(resume);
                ac.SaveChanges();
            }
            string id = User.Identity.GetUserId();
            ApplicationUser user = UserManager.FindById(id);

            ActionBeforeIndex(user);
            return View("Index");

        }

        public ActionResult HideResume()
        {
            return PartialView();
        }

        public ActionResult DisplayResume()
        {
            string id = User.Identity.GetUserId();
            ApplicationUser user = UserManager.FindById(id);

            ActionBeforeIndex(user);
            return PartialView();
        }

        [HttpPost]
        public ActionResult DisplayResume(int id)
        {
            return View("Index");
        }
    }
}