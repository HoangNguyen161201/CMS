using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using assignment.Models;
using assignment.utils;

namespace assignment.Controllers
{

    public class TopicController : Controller
    {
        // connect database
        asignmentEntities db = new asignmentEntities();

        Utils utils = new Utils();

        public Topic getTopic(int id)
        {
            return db.Topics.Where(s => s.TopicId == id).FirstOrDefault();
        }


        // GET: Topic
        public ActionResult Index()
        {
            var auth = utils.authen(Session, "Staff");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            var data = db.Topics.ToList();
            foreach (Topic item in data)
            {
                item.image = utils.background(item.TopicId.ToString());
            }
            return View(data);
        }

        // GET: Topic/Details/5
        public ActionResult Details(int id)
        {
            var auth = utils.authen(Session, "Staff");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            return View(getTopic(id));
        }

        // GET: Topic/Create
        public ActionResult Create()
        {
            var auth = utils.authen(Session, "Staff");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            return View();
        }

        // POST: Topic/Create
        [HttpPost]
        public ActionResult Create(Topic data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Topics.Add(data);
                    utils.saveDataChange(db);
                    TempData["message"] = "Create course has id is " + data.CourseId + " success";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View(data);
            }
        }

        // GET: Topic/Edit/5
        public ActionResult Edit(int id)
        {
            var auth = utils.authen(Session, "Staff");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            return View(getTopic(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Topic data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                    utils.saveDataChange(db);
                    TempData["message"] = "update topic has id is " + id + " success";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult Delete( Topic data)
        {
            try
            {
                var auth = utils.authen(Session, "Staff");
                if (auth == false)
                    return RedirectToAction("Login", "Auth");

                data = getTopic(data.TopicId);
                db.Topics.Remove(data);
                utils.saveDataChange(db);
                TempData["message"] = "Delete topic has name is " + data.Topic_name + " success";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Error"] = "Topic has name is " + data.Topic_name + " has trainers";
                return RedirectToAction("Index");
            }
        }

        public ActionResult ChooseCourse()
        {
            Course course = new Course();
            course.CourseCollection = db.Courses.ToList<Course>();
            return PartialView(course);
        }

        public ActionResult getTopicByCourse(int id)
        {
            var data = db.Topics.Where(s => s.CourseId == id).ToList();
            foreach (Topic item in data)
            {
                item.image = utils.background(item.TopicId.ToString());
            }
            if (data.Count == 0)
            {
                ViewBag.error = "This course has no topics";
            }
            return PartialView(data);
        } 
    }
}
