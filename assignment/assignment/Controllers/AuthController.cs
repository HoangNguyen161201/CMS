using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using assignment.Models;
using assignment.utils;

namespace assignment.Controllers
{
    public class AuthController : Controller
    {


        // connect database
        asignmentEntities db = new asignmentEntities();

        Utils utils = new Utils();
         

        // save account in session
        public ActionResult saveSession(string roll, string fullName, string id)
        {
            Session["fullName"] = fullName;
            Session["roll"] = roll;
            Session["id"] = id;
            Session["image"] = utils.icon(Session["fullName"].ToString());
            return utils.goPage(roll);
        }


        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            var roll = Session["roll"];
            if (roll != null)
            {
                return utils.goPage(roll.ToString());
            }
            return View();
        }

        // POST: Login
        [HttpPost]
        public ActionResult Login(Login data)
        {
            // check valdation model state
            if (ModelState.IsValid)
            {

                switch (data.Roll)
                {
                    case "Admin":
                        {
                            var checkAccount = db.Admins.SingleOrDefault(s => s.Admin_username.Equals(data.Username));
                            if (checkAccount == null || !utils.verifyPassword(data.Password, checkAccount.Admin_password))
                            {
                                TempData["Error"] = "Username or password wrong";
                                return View();
                            }
                            return saveSession(data.Roll, checkAccount.Admin_fullname, checkAccount.AdminId.ToString());
                        }
                    case "Staff":
                        {
                            var checkAccount = db.Training_staff.SingleOrDefault(s => s.Staff_username.Equals(data.Username));
                            if (checkAccount == null || !utils.verifyPassword(data.Password, checkAccount.Staff_password))
                            {
                                TempData["Error"] = "Username or password wrong";
                                return View();
                            }
                            return saveSession(data.Roll, checkAccount.Staff_fullname, checkAccount.StaffId);
                        }
                    case "Trainer":
                        {
                            var checkAccount = db.Trainers.SingleOrDefault(s => s.Trainer_username.Equals(data.Username));
                            if (checkAccount == null || !utils.verifyPassword(data.Password, checkAccount.Trainer_password))
                            {
                                TempData["Error"] = "Username or password wrong";
                                return View();
                            }
                            return saveSession(data.Roll, checkAccount.Trainer_fullname, checkAccount.TrainerId);
                        }
                    case "Trainee":
                        {
                            var checkAccount = db.Trainees.SingleOrDefault(s => s.Trainee_username.Equals(data.Username));
                            if (checkAccount == null || !utils.verifyPassword(data.Password, checkAccount.Trainee_password))
                            {
                                TempData["Error"] = "Username or password wrong";
                                return View();
                            }
                            return saveSession(data.Roll, checkAccount.Trainee_fullname, checkAccount.TraineeId);
                        }
                }
            }
            return View();
        }

        /*show page to create account*/
        // get => /admin/create-account
        [HttpGet]
        public ActionResult CreateAccount()
        {
            // check roll
            var auth = utils.authen(Session, "Admin");
            if (auth == false)
                return RedirectToAction("Login");
            
            return View();
        }

        /*add new account (trainer or staff)*/
        // post => /admin/create-account
        [HttpPost]
        public ActionResult CreateAccount(Register data)
        {
            try
            {
                // check valdation model state
                if (ModelState.IsValid)
                {
                    // check roll to create and save account to database
                    switch (data.Roll)
                    {
                        case "Staff":
                            {
                                // Check if the account exists or not 
                                var checkAccount = db.Training_staff.SingleOrDefault(s => s.Staff_username.Equals(data.Username));
                                if (checkAccount != null)
                                {
                                    // alert error
                                    TempData["Error"] = "Username already exists";
                                    return View();
                                }

                                // add new staff
                                Training_staff user = new Training_staff();
                                user.Staff_username = data.Username;

                                // create hashPassword
                                user.Staff_password = utils.CreateHashPassword(data.Password);
                                user.Staff_fullname = data.FullName;
                                user.StaffId = data.Id;

                                db.Training_staff.Add(user);
                                utils.saveDataChange(db);

                                // alert success
                                TempData["message"] = "Create user has id is " + user.StaffId + " success";
                                return Redirect("show-accounts");
                            }
                        case "Trainer":
                            {
                                // Check if the account exists or not 
                                var checkAccount = db.Trainers.SingleOrDefault(s => s.Trainer_username.Equals(data.Username));
                                if (checkAccount != null)
                                {
                                    // alert error
                                    TempData["Error"] = "Username already exists";
                                    return View();
                                }

                                // add new trainer
                                Trainer user = new Trainer();
                                user.Trainer_username = data.Username;
                                user.Trainer_password = utils.CreateHashPassword(data.Password);
                                user.Trainer_fullname = data.FullName;
                                user.TrainerId = data.Id;

                                db.Trainers.Add(user);
                                utils.saveDataChange(db);

                                // alert success
                                TempData["message"] = "Create user has id is " + user.TrainerId + " success";
                                return Redirect("show-accounts");
                            }
                    }
                }
                return View();
            }
            catch
            {
                // alert error
                TempData["Error"] = "User id already exists";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return Redirect("login");
        }

        /* get => /admin/show-accounts  */    
        public ActionResult ShowAccounts()
        {
            /*check roll*/
            var auth = utils.authen(Session, "Admin");
            if (auth == false)
                return RedirectToAction("Login");
            return View();
        }

        /* use PartialView to import lisr staffs in /admin/show-accounts */
        public ActionResult Staffs()
        {
            var data = db.Training_staff.ToList();
            foreach (Training_staff staff in data)
            {
                /*random image*/
                staff.image = utils.icon(staff.Staff_fullname);
                staff.roll = "Staff";
            }
            return PartialView(data);
        }

        /* use PartialView to import lisr staffs in /admin/show-accounts */
        public ActionResult Trainers()
        {
            var data = db.Trainers.ToList();
            foreach (Trainer trainer in data)
            {
                /*random image*/
                trainer.image = utils.icon(trainer.Trainer_fullname);
                trainer.roll = "Trainer";
            }
            return PartialView(data);
        }
    }
}