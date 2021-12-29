using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using assignment.Models;
using assignment.utils;

namespace assignment.Controllers
{
    public class StaffController : Controller
    {
        // connect database
        asignmentEntities db = new asignmentEntities();

        Utils utils = new Utils();

        public Training_staff getStaff (string id)
        {
            return db.Training_staff.Where(s => s.StaffId == id).FirstOrDefault();
        }

        // edit account has roll is trainer
        // get => /admin/edit-satff/{id}
        public ActionResult EditAccount(string id)
        {
            // check roll
            var auth = utils.authen(Session, "Admin");
            if (auth == false)
                return RedirectToAction("Login", "Auth");

            var data = getStaff(id);
            return View(data);
        }

        // save informaution change
        // post => /admin/edit-staff/{id}
        [HttpPost]
        public ActionResult EditAccount(string id, Training_staff data)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    //Check if the username already exists or not, check null or not
                    var checkAccount = db.Training_staff.SingleOrDefault(s => s.Staff_username.Equals(data.Staff_username));
                    if (checkAccount != null && !id.Equals(checkAccount.StaffId))
                    {
                        // alert error
                        TempData["Error"] = "update account false nha";
                        return View();
                    }

                    // check passwrord null or not
                    if (data.Staff_password != null)
                        data.Staff_password = utils.CreateHashPassword(data.Staff_password);

                    // update account
                    db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                    utils.saveDataChange(db);

                    // alert success
                    TempData["message"] = "update staff has id is " + id + " success";
                    return Redirect("/admin/show-accounts");
                }
                return View();

            }
            catch
            {
                return View();
            }
        }


        // post => Staff/Delete/{id}
        // delete staff 
        [HttpPost]
        public ActionResult Delete(Training_staff data)
        {

            try
            {
                // check roll
                var auth = utils.authen(Session, "Admin");
                if (auth == false)
                    return RedirectToAction("Login", "Auth");

                // delete staff
                data = getStaff(data.StaffId);
                db.Training_staff.Remove(data);
                utils.saveDataChange(db);

                // alert success
                TempData["message"] = "Delete staff has id is " + data.StaffId + " success";
            }
            catch
            {
                // alert error
                TempData["Error"] = "Staff has id id " + data.StaffId + " wrong";
            }
            return Redirect("/admin/show-accounts");
        }

    }
}