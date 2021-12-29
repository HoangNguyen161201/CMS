using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using assignment.Models;
using assignment.utils;

namespace assignment.Controllers
{
    public class AssignCourseController : Controller
    {
        // connect database
        asignmentEntities db = new asignmentEntities();

        Utils utils = new Utils();

        public ActionResult TraineesInCourse(int id)
        {
            var userInCourse = db.AssignCourses.Where(s => s.CourseId == id).Select(s => s.TraineeId).ToList();
            var allUser = db.Trainees.ToList();
            List<Trainee> TraineesInCourse = new List<Trainee>();
            foreach (Trainee item in allUser)
            {
                if (userInCourse.Contains(item.TraineeId) == true)
                {
                    TraineesInCourse.Add(item);
                }
            }
            ViewBag.IdCourse = id;
            if (TraineesInCourse.Count == 0)
            {
                ViewBag.error = "This course has no trainees yet";
            }
            return PartialView(TraineesInCourse);
        }

        // GET: AssignCourse
        public ActionResult Create(int id)
        {
            var auth = utils.authen(Session, "Staff");
            if (auth == false)
                return RedirectToAction("Login", "Auth"); 

            var userInCourse = db.AssignCourses.Where(s => s.CourseId == id).Select(s => s.TraineeId).ToList();
            var allUser = db.Trainees.ToList();
            List<Trainee> TraineesNotInCourse = new List<Trainee>();
            foreach (Trainee item in allUser)
            {
                if (userInCourse.Contains(item.TraineeId) == false)
                {
                    item.image = utils.icon(item.Trainee_fullname);
                    TraineesNotInCourse.Add(item);
                }
            }

            if (TraineesNotInCourse.Count == 0)
            {
                ViewBag.error = "No more trainees";
            }
                return View(TraineesNotInCourse);
        }

        [HttpPost]
        public ActionResult Create(int id, FormCollection collection)
        {
            string[] trainee = collection["trainee"].Split(',');
            
             foreach(string item in trainee)
            {
                AssignCourse addTraineeToCourse = new AssignCourse();
                addTraineeToCourse.CourseId = id;
                addTraineeToCourse.TraineeId = item;
                db.AssignCourses.Add(addTraineeToCourse);
            }
            utils.saveDataChange(db);
            TempData["message"] = "add trainees success";
            return RedirectToAction("Details", "Course", new { id = id });
        }

        public ActionResult DeleteTrainee(string idTrainee, int IdCourse)
        {
            AssignCourse data = db.AssignCourses.Where(s => s.CourseId == IdCourse && s.TraineeId == idTrainee).FirstOrDefault();
            db.AssignCourses.Remove(data);
            utils.saveDataChange(db);
            TempData["message"] = "Delete trainee has id is "+idTrainee+" in course success";
            return RedirectToAction("Details", "Course", new { id = IdCourse });
        }

        public ActionResult ShowCourseOfTrainee()
        {
            var auth = utils.authen(Session, "Trainee");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            var idTrainee = Session["id"];
            List<AssignCourse> AssignCourses = db.AssignCourses.Where(s => s.TraineeId == idTrainee.ToString()).ToList();
            foreach(AssignCourse assigncourse in AssignCourses)
            {
                assigncourse.Course.image = utils.background(assigncourse.CourseId.ToString());
            }
            if (AssignCourses.Count == 0)
            {
                ViewBag.error = "You have not taken any courses yet";
            }

            return View(AssignCourses);
        }
    }
}