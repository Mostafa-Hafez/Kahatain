using finalproject.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace finalproject.Controllers
{
    public class VolunteerController : Controller
    {


        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Volunteer
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AllChildren()
        {
            try
            {
                var id = User.Identity.GetUserId();
                Volunteer vol = db.volunteer.FirstOrDefault(a => a.AppUserId == id);
                var children = db.Child.ToList().FirstOrDefault(z => z.Vol_ID == vol.Vol_ID);
                return View(children);
            }
            catch
            {

                return View();
            }
        }
        [HttpGet]
        public ActionResult AllGrdinprovol(int pro_id)
        {
            try
            {
                var id = User.Identity.GetUserId();
                Volunteer vol = db.volunteer.FirstOrDefault(a => a.AppUserId == id);
                var grades = db.Grades.ToList().FirstOrDefault(a => a.Pr_Id == pro_id && a.Child.Vol_ID == vol.Vol_ID);

                return View(grades);
            }
            catch
            {
                ModelState.AddModelError("", "some thing error please Try Later !!");
                return View();
            }
        }
        [HttpGet]
        public ActionResult AllGradesvol()
        {
            try
            {
                var id = User.Identity.GetUserId();
                Volunteer vol = db.volunteer.FirstOrDefault(a => a.AppUserId == id);
                var grades = db.Grades.FirstOrDefault(a => a.Child.Vol_ID == vol.Vol_ID);

                return View(grades);
            }
            catch
            {

                return View();
            }
        }
        [HttpGet]
        public ActionResult NewChild()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewChild(Child child)
        {
            if (!ModelState.IsValid)
            {
                return View(child);
            }
            try
            {
                db.Child.Add(child);
                var Id = User.Identity.GetUserId();
                Volunteer vol = db.volunteer.FirstOrDefault(z => z.AppUserId == Id);

                child.Volunteer = vol;
                db.SaveChanges();
                return View();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(child);

            }

        }

        [HttpPost]
        public ActionResult AddGrade(Grades grade, int ch_Id, int Pro_Id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                Child child = db.Child.FirstOrDefault(z => z.Ch_ID == ch_Id);
                Programs program = db.Programs.FirstOrDefault(x => x.Pr_ID == Pro_Id);

                if (child == null || program == null)
                {
                    ModelState.AddModelError("", "Invald child or program");
                    return View();
                }
                grade.Program = program;
                grade.Child = child;
                db.Grades.Add(grade);
                db.SaveChanges();
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        [HttpGet]
        public ActionResult DetailsVol()
        {

            
            editvol vol = new editvol();
            try
            {
                if (!User.IsInRole("Volunteer"))
                {
                    return RedirectToAction("Login", "Account");
                }
                var id = User.Identity.GetUserId();
                Volunteer vltr = db.volunteer.FirstOrDefault(a => a.AppUserId == id);
                if (vltr == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                vol.id = vltr.Vol_ID;
                vol.Vol_Address = vltr.Vol_Address;
                vol.Vol_Certificates = vltr.Vol_Certificates;
                vol.Vol_email = vltr.Vol_email;
                vol.Vol_Govrnate = vltr.Vol_Govrnate;
                vol.Vol_Job = vltr.Vol_Job;
                vol.Vol_Name = vltr.Vol_Name;
                vol.Vol_Number1 = vltr.Vol_Number1;
                vol.Vol_Number2 = vltr.Vol_Number2;
                vol.Vol_Place = vltr.Vol_Place;
                vol.Vol_Skills = vltr.Vol_Skills;
                return View(vol);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vol);
                
            }
                
        }


        [HttpGet]
        public ActionResult EditVol()
        {

            try
            {
                if (!User.IsInRole("Volunteer"))
                {
                    return RedirectToAction("Login", "Account");
                }
                var id = User.Identity.GetUserId();
                Volunteer volunteer = db.volunteer.FirstOrDefault(z => z.AppUserId == id);
                if (volunteer == null)
                {
                    ViewBag.result = "No Volunteer Found !";
                    return View();
                }
                editvol vol = new editvol()
                {
                    Vol_Name = volunteer.Vol_Name,
                    Vol_Address = volunteer.Vol_Address,
                    Vol_Certificates = volunteer.Vol_Certificates,
                    Vol_email = volunteer.Vol_email,
                    Vol_Govrnate = volunteer.Vol_Govrnate,
                    Vol_Job = volunteer.Vol_Job,
                    Vol_Number1 = volunteer.Vol_Number1,
                    Vol_Number2 = volunteer.Vol_Number2,
                    Vol_Place = volunteer.Vol_Place,
                    Vol_Skills = volunteer.Vol_Skills,
                    id = volunteer.Vol_ID
                };

                return View(vol);

            }
            catch 
            {
                ViewBag.result = "Some thing error try later !";
                return View();
            }

        }

        [HttpPost] 
        [ValidateAntiForgeryToken]
        public ActionResult EditVol(editvol vol)
        {
            if (!ModelState.IsValid)
            {
                return View(vol);
            }
            try
            {
                Volunteer volunteer = db.volunteer.FirstOrDefault(q => q.Vol_ID == vol.id);
                volunteer.Vol_Address = vol.Vol_Address;
                volunteer.Vol_Certificates = vol.Vol_Certificates;
                volunteer.Vol_email = vol.Vol_email;
                volunteer.Vol_Govrnate = vol.Vol_Govrnate;
                volunteer.Vol_Job = vol.Vol_Job;
                volunteer.Vol_Name = vol.Vol_Name;
                volunteer.Vol_Number1 = vol.Vol_Number1;
                volunteer.Vol_Number1 = vol.Vol_Number2;
                volunteer.Vol_Place = vol.Vol_Place;
                volunteer.Vol_Skills = vol.Vol_Skills;
                db.SaveChanges();

                return RedirectToAction("DetailsVol");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vol);
            }
            
        }

        [HttpGet]
        public ActionResult DetailsChild(int id)
        {
            try
            {
                Child ch = db.Child.FirstOrDefault(a => a.Ch_ID == id);
                var idvol = User.Identity.GetUserId();
                if (ch==null)
                {
                    ViewBag.error = "No Child Found !!";
                    return View(ch);
                }
                if (!(ch.Volunteer.AppUserId == idvol))
                {
                    ViewBag.error = "This Child Not in Your children";
                    return View(new Child());
                }
                
                return View(ch);
            }
            catch 
            {

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]        
        public ActionResult EditChild(int id)
        {
            try
            {
                Child child = db.Child.FirstOrDefault(z => z.Ch_ID == id);
                var idvol = User.Identity.GetUserId();

                if (!(child.Volunteer.AppUserId == idvol))
                {
                    ViewBag.error = "This Child Not in Your children";
                    return View(new Child());
                }
                return View(child);
            }
            catch (Exception )
            {

                ViewBag.error = "There is an error ,Please try Later !!";
                return View(new Child());
            }
        }

        [HttpPost]
        public ActionResult EditChild(Child chld)
        {
            if (!ModelState.IsValid)
            {
                return View(chld);

            }
            try
            {
                db.SaveChanges();
                return View("DetailsChild", chld.Ch_ID);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(chld);
                
            }
        }

        [HttpGet]
        public ActionResult EditGrade(int id)
        {
            try
            {
                
                Grades grade = db.Grades.FirstOrDefault(z => z.Gr_Id == id);
                var idvol = User.Identity.GetUserId();
                if(grade.Child.Volunteer.AppUserId==idvol)
                if (grade == null)
                {
                    return View("AllGradesvol");
                }
                return View(grade);
            }
            catch (Exception)
            {

                return View("AllGradesvol");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditGrade(Grades grd)
        {
            if (!ModelState.IsValid)
            {
                return View(grd);
            }
            try
            {
                var idvol = User.Identity.GetUserId();
                if (grd.Child.Volunteer.AppUserId == idvol)
                    if (grd == null)
                    {
                        return View("AllGradesvol");
                    }
                return View("AllGrdinprovol");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(grd);
                
            }

        }


    }
}