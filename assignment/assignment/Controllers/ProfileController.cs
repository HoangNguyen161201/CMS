using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using assignment.Models;
using assignment.utils;

namespace assignment.Controllers
{
    public class ProfileController : Controller
    {
        // connect database
        asignmentEntities db = new asignmentEntities();

        Utils utils = new Utils();

        // GET: Profile
        public ActionResult showProfileStaff()
        {
            var auth = utils.authen(Session, "Staff");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            var id = Session["id"];

            var data = db.Training_staff.Where(s => s.StaffId == id.ToString()).FirstOrDefault();
            data.image = utils.icon(data.Staff_fullname);
            return View(data);
        }

        public ActionResult showProfileTrainer()
        {
            var auth = utils.authen(Session, "Trainer");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            var id = Session["id"];
            var data = db.Trainers.Where(s => s.TrainerId == id.ToString()).FirstOrDefault();
            data.image = utils.icon(data.Trainer_fullname);
            return View(data);
        }

        public ActionResult showProfileTrainee()
        {
            var auth = utils.authen(Session, "Trainee");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            var id = Session["id"];
            var data = db.Trainees.Where(s => s.TraineeId == id.ToString()).FirstOrDefault();
            data.image = utils.icon(data.Trainee_fullname);
            return View(data);
        }

        [HttpGet]
        public ActionResult UpdateProfileStaff()
        {
            var auth = utils.authen(Session, "Staff");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            var id = Session["id"];
            return View(db.Training_staff.Where(s => s.StaffId == id.ToString()).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult UpdateProfileStaff(Training_staff data)
        {
            try
            {
                var auth = utils.authen(Session, "Staff");
                if (auth == false)
                    return RedirectToAction("Login", "Auth");

                data.Staff_password = utils.CreateHashPassword(data.Staff_password);
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                utils.saveDataChange(db);
                Session["fullName"] = data.Staff_fullname;
                Session["image"] = utils.icon(Session["fullName"].ToString());
                TempData["message"] = "Update profile success";
                return RedirectToAction("showProfileStaff");

            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult UpdateProfileTrainer()
        {
            var auth = utils.authen(Session, "Trainer");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            var id = Session["id"];
            return View(db.Trainers.Where(s => s.TrainerId == id.ToString()).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult UpdateProfileTrainer(Trainer data)
        {
            try
            {
                if (ModelState.IsValid)
                { 
                
                    var auth = utils.authen(Session, "Trainer");
                    if (auth == false)
                        return RedirectToAction("Login", "Auth");
    
                    db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                    utils.saveDataChange(db);
                    Session["fullName"] = data.Trainer_fullname;
                    Session["image"] = utils.icon(Session["fullName"].ToString());
                    TempData["message"] = "Update profile success";
                    return RedirectToAction("showProfileTrainer"); 
                }
                return View();
               
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult UpdateProfileTrainee()
        {
            var auth = utils.authen(Session, "Trainee");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            var id = Session["id"];
            var data = db.Trainees.Where(s => s.TraineeId == id.ToString()).FirstOrDefault();
            string[] date = data.Trainee_birthday.ToString().Split(' ');
            ViewBag.date = date[0];

            return View(data);
        }

        // POST: Trainee/Edit/5
        [HttpPost]
        public ActionResult UpdateProfileTrainee( Trainee data)
        {
            try
            {

                var auth = utils.authen(Session, "Trainee");
                if (auth == false)
                    return RedirectToAction("Login", "Auth");

                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                utils.saveDataChange(db);
                Session["fullName"] = data.Trainee_fullname;
                Session["image"] = utils.icon(Session["fullName"].ToString());
                TempData["message"] = "Update profile success";
                return RedirectToAction("showProfileTrainee");
   
            }
            catch
            {
                return View();
            }
        }
    }
} 