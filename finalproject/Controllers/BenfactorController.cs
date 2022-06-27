using finalproject.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace finalproject.Controllers
{
    public class BenfactorController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Benfactor
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult DetailsBenf()
        {
            try
            {
                var id = User.Identity.GetUserId();
                Benefactor benf = db.benefactor.FirstOrDefault(z => z.AppUserId == id);
                if (benf == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                return View(benf);
            }
            catch (Exception)
            {

                return View(new Benefactor());
            }


        }
        
        [HttpGet]
        public ActionResult EditBenf()
        {
            try
            {
                var id = User.Identity.GetUserId();
                Benefactor benf = db.benefactor.FirstOrDefault(z => z.AppUserId == id);
                if (benf == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                return View(benf);
            }catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("DetailsBenf");
            }
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBenf(Benefactor benfactor)
        {
            if (!ModelState.IsValid)
            {
                return View(benfactor);
            }
            try
            {
                db.SaveChanges();
                return RedirectToAction("DetailsBenf");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(benfactor);
            }
           
        }
    }
}