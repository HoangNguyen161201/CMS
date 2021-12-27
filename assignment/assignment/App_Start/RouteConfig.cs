using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace assignment
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // login
            routes.MapRoute(
                name: "login",
                url: "login",
                defaults: new { controller = "Auth", action = "Login"}
            );


            // admin
            routes.MapRoute(
                name: "admin-show-account",
                url: "admin/show-accounts",
                defaults: new { controller = "Auth", action = "ShowAccounts" }
            );

            routes.MapRoute(
                name: "admin-create-account",
                url: "admin/create-account",
                defaults: new { controller = "Auth", action = "CreateAccount" }
            );

            routes.MapRoute(
                name: "admin-edit-trainer",
                url: "admin/edit-trainer/{id}",
                defaults: new { controller = "Trainer", action = "EditAccount", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "admin-edit-staff",
                url: "admin/edit-staff/{id}",
                defaults: new { controller = "Staff", action = "EditAccount", id = UrlParameter.Optional }
            );











            // staff
            routes.MapRoute(
                name: "show-trainees",
                url: "staff/show-trainees",
                defaults: new { controller = "Trainee", action = "Index" }
            );

            routes.MapRoute(
                name: "create-trainee",
                url: "staff/create-trainee",
                defaults: new { controller = "Trainee", action = "Create" }
            );

            routes.MapRoute(
                name: "details-trainee",
                url: "staff/details-trainee/{id}",
                defaults: new { controller = "Trainee", action = "Details", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "update-trainee",
                url: "staff/update-trainee/{id}",
                defaults: new { controller = "Trainee", action = "Edit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "delete-trainee",
                url: "staff/delete-trainee",
                defaults: new { controller = "Trainee", action = "Delete"}
            );
            routes.MapRoute(
                name: "show-profile-staff",
                url: "staff/show-profile",
                defaults: new { controller = "Profile", action = "showProfileStaff" }
            );
            routes.MapRoute(
                name: "edit-profile-staff",
                url: "staff/edit-profile",
                defaults: new { controller = "Profile", action = "UpdateProfileStaff"}
            );
            routes.MapRoute(
                name: "staff/show-trainers",
                url: "staff/show-trainers",
                defaults: new { controller = "Trainer", action = "Index" }
            );
            routes.MapRoute(
                name: "details-trainer",
                url: "staff/details-trainer/{id}",
                defaults: new { controller = "Trainer", action = "Details", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "update-trainer",
                url: "staff/update-trainer/{id}",
                defaults: new { controller = "Trainer", action = "Edit", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "show-categories",
                url: "staff/show-categories",
                defaults: new { controller = "Category", action = "Index"}
            );
            routes.MapRoute(
                name: "create-category",
                url: "staff/create-category",
                defaults: new { controller = "Category", action = "Create" }
            );
            routes.MapRoute(
                name: "show-details-category",
                url: "staff/details-category/{id}",
                defaults: new { controller = "Category", action = "Details", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "update-category",
                url: "staff/update-category/{id}",
                defaults: new { controller = "Category", action = "Edit", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "delete-category",
                url: "staff/delete-category",
                defaults: new { controller = "Category", action = "Delete" }
            );
            routes.MapRoute(
                name: "show-courses",
                url: "staff/show-courses",
                defaults: new { controller = "Course", action = "Index" }
            );
            routes.MapRoute(
                name: "delete-course",
                url: "staff/delete-course",
                defaults: new { controller = "Course", action = "Delete" }
            );
            routes.MapRoute(
                name: "update-course",
                url: "staff/update-course/{id}",
                defaults: new { controller = "Course", action = "Edit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "create-course",
                url: "staff/create-course",
                defaults: new { controller = "Course", action = "Create" }
            );
            routes.MapRoute(
                name: "details-course",
                url: "staff/details-course/{id}",
                defaults: new { controller = "Course", action = "Details", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "add-trainees-course",
                url: "staff/add-trainees/{id}",
                defaults: new { controller = "AssignCourse", action = "Create", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "show-topics",
                url: "staff/show-topics",
                defaults: new { controller = "Topic", action = "Index" }
            );
            routes.MapRoute(
                name: "create-topic",
                url: "staff/create-topic",
                defaults: new { controller = "Topic", action = "Create" }
            );
            routes.MapRoute(
                name: "delete-topic",
                url: "staff/delete-topic",
                defaults: new { controller = "Topic", action = "Delete" }
            );
            routes.MapRoute(
                name: "details-topic",
                url: "staff/details-topic/{id}",
                defaults: new { controller = "Topic", action = "Details", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "add-trainers-topic",
                url: "staff/add-trainers/{id}",
                defaults: new { controller = "AssignTopic", action = "Create", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "update-topic",
                url: "staff/update-topic/{id}",
                defaults: new { controller = "Topic", action = "Edit", id = UrlParameter.Optional }
            );





            // trainer
            routes.MapRoute(
                name: "show-profile-trainer",
                url: "trainer/show-profile",
                defaults: new { controller = "Profile", action = "showProfileTrainer" }
            );
            routes.MapRoute(
                name: "edit-profile-trainer",
                url: "trainer/edit-profile",
                defaults: new { controller = "Profile", action = "UpdateProfileTrainer" }
            );
            routes.MapRoute(
                name: "show-Course-trainer",
                url: "trainer/show-course",
                defaults: new { controller = "AssignTopic", action = "CoursesByTrainerAndTopic" }
            );
            routes.MapRoute(
                name: "show-details-Course",
                url: "trainer/details-course/{id}",
                defaults: new { controller = "Trainer", action = "CourseDetail", id = UrlParameter.Optional }
            );

            // Trainee
            routes.MapRoute(
                name: "show-Course-trainee",
                url: "trainee/show-course",
                defaults: new { controller = "AssignCourse", action = "ShowCourseOfTrainee" }
            );
            routes.MapRoute(
                name: "show-profile-trainee",
                url: "trainee/show-profile",
                defaults: new { controller = "Profile", action = "showProfileTrainee" }
            );
            routes.MapRoute(
                name: "show-details-Course-trainee",
                url: "trainee/details-course/{id}",
                defaults: new { controller = "Trainee", action = "CourseDetail", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "edit-profile-trainee",
                url: "trainee/edit-profile",
                defaults: new { controller = "Profile", action = "UpdateProfileTrainee" }
            );







            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
