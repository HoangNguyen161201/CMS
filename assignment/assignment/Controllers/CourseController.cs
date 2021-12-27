using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using assignment.Models;
using assignment.utils;

namespace assignment.Controllers
{
    public class CourseController : Controller
    {

        // connect database
        asignmentEntities db = new asignmentEntities();
        Utils utils = new Utils();


        // get course by id
        public Course getCourse(int id)
        {
            return db.Courses.Where(s => s.CourseId == id).FirstOrDefault();
        }

        // GET: Course
        public ActionResult Index()
        {
            var auth = utils.authen(Session, "Staff");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            var data = db.Courses.ToList();
            foreach(Course item in data)
            {
                item.image = utils.background(item.CourseId.ToString());
            }
            return View(data);
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            var auth = utils.authen(Session, "Staff");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            return View(getCourse(id));
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            var auth = utils.authen(Session, "Staff");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(Course data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Courses.Add(data);
                    utils.saveDataChange(db);
                    TempData["message"] = "Create course has id is " + data.CourseId + " success";
                    return RedirectToAction("Index");
                } else
                return View();
            }
            catch
            {
                return View(data);
            }
        }


        public ActionResult Edit(int id)
        {
            var auth = utils.authen(Session, "Staff");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            return View(getCourse(id));
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Course data)
        {
            try
            {
                if (ModelState.IsValid) { 
                    db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                    utils.saveDataChange(db);
                    TempData["message"] = "update course has id is " + id + " success";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                TempData["Error"] = "update course Error";
                return View();
            }
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(Course data)
        {
            try
            {
                var auth = utils.authen(Session, "Staff");
                if (auth == false)
                    return RedirectToAction("Login", "Auth");

                data = getCourse(data.CourseId);
                db.Courses.Remove(data);
                db.SaveChanges();
                TempData["message"] = "Delete course has name is " + data.Course_name + " success";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Error"] = "course has name is " + data.Course_name + " has topics or trainees";
                return RedirectToAction("Index");
            }
        }

        public ActionResult ChooseCategory()
        {
            CourseCategory cate = new CourseCategory();
            cate.cateCollection = db.CourseCategories.ToList<CourseCategory>();
            return PartialView(cate);
        }

        public ActionResult getCoursesByCt (int id)
        {
            var auth = utils.authen(Session, "Staff");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            var data = db.Courses.Where(s => s.CategoryId == id).ToList();
            foreach (Course item in data)
            {
                item.image = utils.background(item.CourseId.ToString());
            }
            if (data.Count == 0)
            {
                ViewBag.error = "This category has no courses";
            }
            return PartialView(db.Courses.Where(s => s.CategoryId == id).ToList());
        }
    }
}
