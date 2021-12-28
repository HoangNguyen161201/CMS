using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using assignment.Models;
using assignment.utils;

namespace assignment.Controllers
{
    public class TrainerController : Controller
    {
        // connect database
        asignmentEntities db = new asignmentEntities();

        Utils utils = new Utils();

        public Trainer getTrainer(string id)
        {
            return db.Trainers.Where(s => s.TrainerId == id).FirstOrDefault();
        }

        // GET: Trainee
        public ActionResult Index()
        {
            var auth = utils.authen(Session, "Staff");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            var data = db.Trainers.ToList();
            foreach (Trainer trainer in data)
            {
                trainer.image = utils.icon(trainer.Trainer_fullname);
            }
            return View(data);
        }

        // GET: Trainee/Details/5
        public ActionResult Details(string id)
        {
            var auth = utils.authen(Session, "Staff");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            var trainer = getTrainer(id);
            trainer.image = utils.icon(trainer.Trainer_fullname);
            return View(trainer);
        }

        // GET: Trainee/Edit/5
        public ActionResult Edit(string id)
        {
            var auth = utils.authen(Session, "Staff");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            var data = getTrainer(id);
            return View(data);
        }

        // POST: Trainee/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Trainer data)
        {
            try
            {
          
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                utils.saveDataChange(db);
                TempData["message"] = "update trainer has id is " + id + " success";
                return RedirectToAction("Index");
        
            }
            catch
            {
                TempData["Error"] = "update trainer has id is " + id + " success";
                return View();
            }
        }


        // post => Trainer/Delete/{id}
        // delete trainer
        [HttpPost]
        public ActionResult Delete(Trainer data)
        {

            try
            {
                // check roll 
                var auth = utils.authen(Session, "Admin");
                if (auth == false)
                    return RedirectToAction("Login", "Auth");

                // delete trainer
                data = getTrainer(data.TrainerId);
                db.Trainers.Remove(data);
                utils.saveDataChange(db);

                // alert success
                TempData["message"] = "Delete trainer has id is " + data.TrainerId + " success";
            }
            catch
            {
                // alert error
                TempData["Error"] = "Trainer has id id " + data.TrainerId + " wrong";
            }
            return Redirect("/admin/show-accounts");
        }




        // edit account has roll is trainer
        // get => /admin/edit-trainer/{id}
        public ActionResult EditAccount(string id)
        {
            var auth = utils.authen(Session, "Admin");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            var data = getTrainer(id);
            return View(data);
        }

        // edit account has roll is trainer
        // post => /admin/edit-trainer/{id}
        [HttpPost]
        public ActionResult EditAccount(string id, Trainer data)
        {
            try
            {
                //Check if the username already exists or not, check null or not
                var checkAccount = db.Trainers.SingleOrDefault(s => s.Trainer_username.Equals(data.Trainer_username));
                if (checkAccount != null && !id.Equals(checkAccount.TrainerId))
                {
                    // alert error
                    TempData["Error"] = "update account false nha";
                    return View();
                }
                
                // check password null or not
                if(data.Trainer_password != null)
                {
                    data.Trainer_password = utils.CreateHashPassword(data.Trainer_password);
                }

                // update account
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                // alert success
                TempData["message"] = "update trainer has id is " + id + " success";
                return Redirect("/admin/show-accounts");
            }
            catch
            {
                // alert error
                TempData["Error"] = "ban chua cap nhap du lieu";
                return View();
            }
        }


        public ActionResult getCourses()
        {
            var auth = utils.authen(Session, "Trainer");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            var id = Session["id"];
            List<AssignTopic> assignTopics = db.AssignTopics.Where(assignTopic => assignTopic.TrainerId == id.ToString()).ToList();
            List<Course> courses = new List<Course>();
            List<AssignTopic> TopicsGrByCourse = new List<AssignTopic>();

            foreach (AssignTopic assignTopic in assignTopics)
            {
                if(!courses.Contains(assignTopic.Topic.Course))
                {
                    TopicsGrByCourse.Add(assignTopic);
                    courses.Add(assignTopic.Topic.Course);
                }
                assignTopic.Topic.Course.image = utils.background(assignTopic.Topic.Course.CourseId.ToString());
            }
            return View(TopicsGrByCourse);
        }

        // get => /trainer/details-course/{id}
        // show detail
        public ActionResult CourseDetail(int id)
        {
            var auth = utils.authen(Session, "Trainer");
            if (auth == false)
                return RedirectToAction("Login", "Auth");
            
            return View(db.Courses.Where(course=> course.CourseId == id).FirstOrDefault());
        }
    }
}