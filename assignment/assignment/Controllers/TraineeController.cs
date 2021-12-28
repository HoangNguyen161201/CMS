using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using assignment.Models;
using assignment.utils;

namespace assignment.Controllers
{
    public class TraineeController : Controller
    {
        // connect database
        asignmentEntities db = new asignmentEntities();

        Utils utils = new Utils();

        public Trainee getTrainee (string id)
        {
            return db.Trainees.Where(s => s.TraineeId == id).FirstOrDefault();
        }

        // GET: Trainee
        public ActionResult Index()
        {
            var auth = utils.authen(Session, "Staff");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            var data = db.Trainees.ToList();
            foreach (Trainee trainee in data)
            {
                trainee.image = utils.icon(trainee.Trainee_fullname);
            }
            return View(data);

        }

        // GET: Trainee/Details/5
        public ActionResult Details(string id)
        {
            var auth = utils.authen(Session, "Staff");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            var trainee = getTrainee(id);
            trainee.image = utils.icon(trainee.Trainee_fullname);
            return View(trainee);
        }

        // GET: Trainee/Create
        public ActionResult Create()
        {
            var auth = utils.authen(Session, "Staff");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            return View();
        }

        // POST: Trainee/Create
        [HttpPost]
        public ActionResult Create(Trainee data)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var checkAccount = db.Trainees.SingleOrDefault(s => s.Trainee_username.Equals(data.Trainee_username));
                    if (checkAccount != null)
                    {
                        TempData["Error"] = "Username already exists";
                        return View();
                    }

                    data.Trainee_password = utils.CreateHashPassword(data.Trainee_password);
                    db.Trainees.Add(data);
                    utils.saveDataChange(db);
                    TempData["message"] = "Create trainee has id is " + data.TraineeId + " success";
                    return Redirect("show-trainees");
                }

                return View();
            }
            catch
            {
                TempData["Error"] = "Id trainee already exists";
                return View(data);
            }
        }

        // GET: Trainee/Edit/5
        public ActionResult Edit(string id)
        {
            var auth = utils.authen(Session, "Staff");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            var data = getTrainee(id);
            string[] date= data.Trainee_birthday.ToString().Split(' ');
            ViewBag.date = date[0];

            return View(data);
        }

        // POST: Trainee/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Trainee data)
        {
            try
            {
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                utils.saveDataChange(db);
                TempData["message"] = "update trainee has id is " + id + " success";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(Trainee data)
        {

            try
            {
                var auth = utils.authen(Session, "Staff");
                if (auth == false)
                    return RedirectToAction("Login", "Auth");

                data = getTrainee(data.TraineeId);
                db.Trainees.Remove(data);
                utils.saveDataChange(db);
                TempData["message"] = "Delete trainee has id is " + data.TraineeId + " success";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Error"] = "Trainee has id id " + data.TraineeId + " da trong 1 course";
                return RedirectToAction("Index");
            }
        }

        public ActionResult CourseDetail(int id)
        {
            var auth = utils.authen(Session, "Trainee");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            return View(db.Courses.Where(course => course.CourseId == id).FirstOrDefault());
        }
    }
}
