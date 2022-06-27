using finalproject.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace finalproject.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AllVolunteers()
        {
            try
            {
                List<Volunteer> vols = db.volunteer.ToList();
                return View(vols);
            }
            catch 
            {
                
                return RedirectToAction("Index","Home");
               
            }
        }
        
        [HttpGet]
        public ActionResult AllBenfactors()
        {
            try
            {
                List<Benefactor> bens = db.benefactor.ToList();
                return View(bens);

            }
            catch 
            {
                return View("Index","Home");
            }
        }
        [HttpGet]
        public ActionResult AllGradesinpro(int pro_id)
        {
            try
            {
                var grades = db.Grades.FirstOrDefault(a => a.Pr_Id == pro_id);
                return View(grades);
            }
            catch
            {

                return View("Index", "Home");
            }
        }
        [HttpGet]
        public ActionResult AllProgrms()
        {
            try
            {
                List<Programs> pros = db.Programs.ToList();
                return View(pros);
            }
            catch 
            {

                return View();
                   
            }
        }
        
        [HttpGet]
        [AllowAnonymous]
        public ActionResult AddProgram()
        {
            ViewBag.res = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProgram(Programs program )
        {
            if (!ModelState.IsValid)
            {
                ViewBag.res = "Not Added";
                return View(program);
            }
            try
            {
                
                db.Programs.Add(program);
                db.SaveChanges();
                ViewBag.res = "Added Succefully";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.res = "Not Added";
                ModelState.AddModelError("", ex.Message);
                return View(program);
            }
            
        }

        [HttpGet]
        public ActionResult DetailsProgram(int id)
        {
            Programs pro = new Programs();
            try
            {
                pro = db.Programs.FirstOrDefault(q => q.Pr_ID == id);
                if (pro == null)
                {
                    ModelState.AddModelError("", "No Program Found");
                    return View(pro);
                }
                return View(pro);

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(pro);
            }
            
        }

        [HttpPost]
        public ActionResult EditProgram(int id )
        {
            try
            {
                Programs prgm = db.Programs.FirstOrDefault(a => a.Pr_ID == id);
                if (prgm == null)
                {
                    ModelState.AddModelError("", "No Program Found");
                    return View(prgm);
                }
                return View(prgm);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View("DetailsProgram", id);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProgram(Programs prog)
        {
            if (!ModelState.IsValid)
            {
                return View(prog);
            }
            try
            {
                db.SaveChanges();
                return View("DetailsProgram", prog.Pr_ID);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(prog);
            }
        }

        [HttpGet]
        public ActionResult AllGradesinProAdmin(int pro_Id)
        {
            try
            {
                var grades = db.Grades.ToList().FirstOrDefault(a => a.Pr_Id == pro_Id);
                if (grades == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                return View(grades);
            }
            catch 
            {
                return RedirectToAction("Index", "Home");
            }
        }


        [HttpGet]
        public ActionResult DetailsAdmin()
        {
            try
            {
                var id = User.Identity.GetUserId();
                Admins adm = db.Admin.FirstOrDefault(z => z.AppUserId == id);
                if (adm == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                return View(adm);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(new Admins());
                
            }
            
        }  
        
        [HttpGet]
        public ActionResult EditAdmin()
        {
            try
            {
                var id = User.Identity.GetUserId();
                Admins adm = db.Admin.FirstOrDefault(z => z.AppUserId == id);
                if (adm == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                return View(adm); 
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("DetailsAdmin");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAdmin(Admins admin)
        {
            if (!ModelState.IsValid)
            {
                return View(admin);
            }
            try
            {
                db.SaveChanges();
                return RedirectToAction("DetailsAdmin");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(admin);
                
            }
        }


    }
}