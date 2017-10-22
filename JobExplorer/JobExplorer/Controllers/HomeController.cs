using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobExplorer.Models;

namespace JobExplorer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()

        {
            ApplicationContext ac = new ApplicationContext();
            var usersAmount = ac.Users.Count();
            var resumesAmount = ac.Resumes.Count();
            var vacanciesAmount = 0;
            var specialitiesAmount = ac.Specialities.Count();
            ViewBag.UsersAmount = usersAmount;
            ViewBag.ResumesAmount = resumesAmount;
            ViewBag.VacanciesAmount = vacanciesAmount;
            ViewBag.SpecialitiesAmount = specialitiesAmount;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}