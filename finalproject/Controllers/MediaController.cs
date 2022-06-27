using finalproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace finalproject.Controllers
{
    public class MediaController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Media
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddVideo(Videos video,int Pro_Id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                Programs program = db.Programs.FirstOrDefault(z => z.Pr_ID == Pro_Id);
                if (program == null)
                {
                    ModelState.AddModelError("", "No Program found");
                    return View();
                }

                video.Program = program;
                db.Videos.Add(video);
                db.SaveChanges();
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
                
            }
        }

        [HttpPost]
        public ActionResult AddSound(Sounds sound, int Pro_Id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                Programs program = db.Programs.FirstOrDefault(z => z.Pr_ID == Pro_Id);
                if (program == null)
                {
                    ModelState.AddModelError("", "No Program found");
                    return View();
                }

                sound.Program = program;
                db.Sounds.Add(sound);
                db.SaveChanges();
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();

            }
        }

        [HttpPost]
        public ActionResult AddFile(Files file, int Pro_Id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                Programs program = db.Programs.FirstOrDefault(z => z.Pr_ID == Pro_Id);
                if (program == null)
                {
                    ModelState.AddModelError("", "No Program found");
                    return View();
                }

                file.Program = program;
                db.Files.Add(file);
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
        public ActionResult AllMediainPr(int pro_id)
        {
            try
            {
                var vids = db.Videos.ToList().FirstOrDefault(a => a.Pr_Id == pro_id);
                var snds = db.Sounds.ToList().FirstOrDefault(a => a.Pr_Id == pro_id);
                var fils = db.Files.ToList().FirstOrDefault(a => a.Pr_Id == pro_id);
                ViewBag.Sounds = snds;
                ViewBag.videos = vids;
                ViewBag.Files = fils;
                return View();

            }
            catch {
                ViewBag.Sounds = null;
                ViewBag.videos = null;
                ViewBag.Files = null;
                return View();
            }
        }
    }
}