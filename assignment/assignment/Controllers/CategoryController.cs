using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using assignment.Models;
using assignment.utils;

namespace assignment.Controllers
{
    public class CategoryController : Controller
    {
        // connect database
        asignmentEntities db = new asignmentEntities();

        Utils utils = new Utils();

        public CourseCategory getCategory(int id)
        {
            return db.CourseCategories.Where(s => s.CategoryId == id).FirstOrDefault();
        }

        // GET: Category
        public ActionResult Index()
        {
            var auth = utils.authen(Session, "Staff");
            if (auth == false)
                return RedirectToAction("Login", "Auth");
            var data = db.CourseCategories.ToList();
            foreach(CourseCategory item in data)
            {

                item.image = utils.background(item.CategoryId.ToString());
            }
            return View(data);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var auth = utils.authen(Session, "Staff");
            if (auth == false)
                return RedirectToAction("Login", "Auth");
            return View(getCategory(id));
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            var auth = utils.authen(Session, "Staff");
            if (auth == false)
                return RedirectToAction("Login", "Auth");
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CourseCategory data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.CourseCategories.Add(data);
                    utils.saveDataChange(db);
                    @TempData["message"] = "Create category has name is " + data.Category_name + " success";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var auth = utils.authen(Session, "Staff");
            if (auth == false)
                return RedirectToAction("Login", "Auth");
            return View(getCategory(id));
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CourseCategory data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                    utils.saveDataChange(db);
                    TempData["message"] = "update category has id is " + id + " success";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }


        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(CourseCategory data)
        {
            try
            {
                var auth = utils.authen(Session, "Staff");
                if (auth == false)
                    return RedirectToAction("Login", "Auth");

                data = getCategory(data.CategoryId);
                db.CourseCategories.Remove(data);
                utils.saveDataChange(db);
                TempData["message"] = "Delete category has id is " + data.CategoryId + " success";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Error"] = "Category has name is " + data.Category_name + " has courses";

                return RedirectToAction("Index");
            }
        }
    }
}
