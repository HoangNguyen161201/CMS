using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using assignment.Models;
using BC = BCrypt.Net.BCrypt;

namespace assignment.utils
{
    public class Utils: Controller
    {

        public ActionResult goPage(string roll)
        {
            switch (roll)
            {
                case "Admin":

                    {
                        return Redirect("admin/show-accounts");
                    }
                case "Staff":
                    {

                        return Redirect("staff/show-trainees");
                    }
                case "Trainer":
                    {

                        return Redirect("/trainer/show-course");
                    }
                case "Trainee":
                    {

                        return Redirect("/trainee/show-course");
                    }
            }
            return View();
        }

        // save data
        public void saveDataChange(asignmentEntities db)
        {
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
        }

        // create HashPassword
        public string CreateHashPassword(string password)
        {
            return BC.HashPassword(password);
        }

        public Boolean verifyPassword (string oldPassword, string hashPassword)
        {
            return BC.Verify(oldPassword, hashPassword);
        }

        public Boolean authen (HttpSessionStateBase rollUser, string userRoll)
        {
            if (rollUser["roll"] != null)
            {
                var roll = rollUser["roll"];
                if (roll.ToString() == userRoll)
                {
                    return true;
                }
            } 
            return false;
        }

        public string icon(string item)
        {
            return "https://avatars.dicebear.com/api/big-smile/" + item + ".svg";
        }

        public string background(string item)
        {
            return "https://source.unsplash.com/random/?pink,blue," + item;
        }
    }
}