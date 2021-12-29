using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using assignment.Models;
using assignment.utils;

namespace assignment.Controllers
{
    public class AssignTopicController : Controller
    {
        // connect database
        asignmentEntities db = new asignmentEntities();

        Utils utils = new Utils();

        public ActionResult TrainersInTopic(int id)
        {
            var userInTopic = db.AssignTopics.Where(s => s.TopicId == id).Select(s => s.TrainerId).ToList();
            var allUser = db.Trainers.ToList();
            List<Trainer> TrainerInTopic = new List<Trainer>();
            foreach (Trainer item in allUser)
            {
                if (userInTopic.Contains(item.TrainerId) == true)
                {
                    TrainerInTopic.Add(item);
                }
            }
            ViewBag.IdTopic = id;
            if (TrainerInTopic.Count == 0)
            {
                ViewBag.error = "This topic  has no trainers yet";
            }
            return PartialView(TrainerInTopic);
        }

        // GET: AssignCourse
        public ActionResult Create(int id)
        {
            var auth = utils.authen(Session, "Staff");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            var userInTopic = db.AssignTopics.Where(s => s.TopicId == id).Select(s => s.TrainerId).ToList();
            var allUser = db.Trainers.ToList();
            List<Trainer> TrainerInTopic = new List<Trainer>();
            foreach (Trainer item in allUser)
            {
                if (userInTopic.Contains(item.TrainerId) == false)
                {
                    item.image = utils.icon(item.Trainer_fullname);
                    TrainerInTopic.Add(item);
                }
            }

            if (TrainerInTopic.Count == 0)
            {
                ViewBag.error = "No more trainers";
            }
            return View(TrainerInTopic);
        }

        [HttpPost]
        public ActionResult Create(int id, FormCollection collection)
        {
            string[] trainer = collection["trainer"].Split(',');

            foreach (string item in trainer)
            {
                AssignTopic addTraineeToTopic = new AssignTopic();
                addTraineeToTopic.TopicId = id;
                addTraineeToTopic.TrainerId = item;
                db.AssignTopics.Add(addTraineeToTopic);
            }
            utils.saveDataChange(db);
            TempData["message"] = "add trainers success";
            return RedirectToAction("Details", "Topic", new { id = id });
        }

        public ActionResult DeleteTrainer(string idTrainer, int idTopic)
        {
            AssignTopic data = db.AssignTopics.Where(s => s.TopicId == idTopic && s.TrainerId == idTrainer).FirstOrDefault();
            db.AssignTopics.Remove(data);
            utils.saveDataChange(db);
            TempData["message"] = "delete trainer has id is " + idTrainer + " in topic success";
            return RedirectToAction("Details", "Topic", new { id = idTopic });
        }

        public ActionResult TopicsByIdAndCourse(int courseId)
        {
            var auth = utils.authen(Session, "Trainer");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            var idTrainer = Session["id"];

            List<AssignTopic> AssignTopics = db.AssignTopics.Where(s => s.TrainerId == idTrainer.ToString() && s.Topic.CourseId == courseId).ToList();

            foreach(AssignTopic assigntopic in AssignTopics)
            {
                assigntopic.Topic.image = utils.background(assigntopic.TopicId.ToString());
            }

            return PartialView(AssignTopics);
        }

        // show course trainer by topic and id traner
        // get => /trainer/show-course
        public ActionResult CoursesByTrainerAndTopic()
        {
            // check roll
            var auth = utils.authen(Session, "Trainer");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            var id = Session["id"];

            // get all assigntopic have this id trainer
            List<AssignTopic> assignTopics = db.AssignTopics.Where(assignTopic => assignTopic.TrainerId == id.ToString()).ToList();

            // create list course to add course
            List<Course> courses = new List<Course>();
            List<AssignTopic> TopicsGrByCourse = new List<AssignTopic>();

            foreach (AssignTopic assignTopic in assignTopics)
            {
                // If this course does not exist in the list, add this assignTopic to the list TopicsGrByCourse
                if (!courses.Contains(assignTopic.Topic.Course))
                {
                    TopicsGrByCourse.Add(assignTopic);
                    courses.Add(assignTopic.Topic.Course);
                }

                assignTopic.Topic.Course.image = utils.background(assignTopic.Topic.Course.CourseId.ToString());
            }

            // if this trainer have not any course
            if (TopicsGrByCourse.Count == 0)
            {
                ViewBag.error = "You have not taken any courses yet";
            }
            return View(TopicsGrByCourse);
        }

        public ActionResult TrainersNameId(int id)
        {
            List<AssignTopic> userInTopic = db.AssignTopics.Where(s => s.TopicId == id).ToList();
            
            return PartialView(userInTopic);
        }
    }
}