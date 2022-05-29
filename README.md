# Manage training activities (ASP DOTNET):

It is a web-based application using ASP.NET technology and SLQ Server database that will allow users to manage their course and topic about training activity of the company with easy-to-use user interface and beautiful. This application can give administrators, staff, trainers, and trainees the rights to interact with data based on the role of each of them.

The system will manage training for the FPT system including creating, updating, and deleting staff, trainer, and trainee accounts. Create courses, topics, and categories. Schedule courses, assign a trainer to a topic, assign trainee to course.

There are 4 main modules, each with specific roles in the system that will tell us that it is a school management system. Following are the main modules that we will integrate into the system:
- Administration Module
- Trainer module
- Trainee Module
- Training – Staff Module

use asp Dotnet to create CMS project and use entity framework to create models and connect to the database (MySql), here are the features of each user in the project:
Our product for FPT.

* Admin:
  * login.

![1 - login](https://user-images.githubusercontent.com/84957563/151059533-1c8f4e02-db80-48bb-9937-4166cee01bc6.jpg)

  * Manage trainer and staff accounts (show account, create an account, update and delete account).

![1 - show accounts](https://user-images.githubusercontent.com/84957563/151059811-42dedf83-3c06-4643-b0bc-cf19a72ac883.jpg)
![2- create account](https://user-images.githubusercontent.com/84957563/151060791-b3f537c0-7a13-490c-9a82-3731d0056445.jpg)
![3 - update account](https://user-images.githubusercontent.com/84957563/151060802-4b1d56cf-74c4-41f7-a3b1-dfd9ba0d31f1.jpg)
![4 - delete account](https://user-images.githubusercontent.com/84957563/151060809-9acfdf87-7bf9-4cc9-9806-1bb2f825571b.jpg)

* Staff:
  * login.
  * trainee account manager (CRUD).

![1 - show trainees](https://user-images.githubusercontent.com/84957563/151061382-5f8345fb-e881-4eaf-bcc1-6e94fa3dbf96.jpg)
![2 - create trainee](https://user-images.githubusercontent.com/84957563/151061389-9f80a0cb-850f-4f80-8eda-d0b0f5a44697.jpg)
![3 - detail trainee](https://user-images.githubusercontent.com/84957563/151061394-d7581eb0-31aa-4b3c-958b-e7dc4ee20b6e.jpg)
 ![4 - update trainee](https://user-images.githubusercontent.com/84957563/151061400-fc37691d-4098-4137-83d4-068f5660e0d9.jpg)
![5 - delete trainee](https://user-images.githubusercontent.com/84957563/151061409-83cfaa97-c02e-45d9-ab65-95def033effa.jpg)

  * Trainer account management (show account, show detail, and update trainer account).

![1 - show trainers](https://user-images.githubusercontent.com/84957563/151061454-0b5f0e82-b4fa-4c11-b177-e607b7dd2410.jpg)
![2 - detail trainer](https://user-images.githubusercontent.com/84957563/151061463-cb2b4b99-3254-4d26-b154-05744b33c51d.jpg)
![3 - update trainer](https://user-images.githubusercontent.com/84957563/151061465-4a870ef7-6467-4884-a776-67de3b8adeed.jpg)

  * category management (CRUD, detail).

![1 - show categories](https://user-images.githubusercontent.com/84957563/151061495-76dd56fd-573c-426c-bcb8-4795885a7d8b.jpg)
![2 - create category](https://user-images.githubusercontent.com/84957563/151061501-0150e8ca-472c-421a-8073-d24969973bd8.jpg)
![3 - detail category](https://user-images.githubusercontent.com/84957563/151061504-5d709ae2-27a9-4ff6-8cf2-f63341492235.jpg)
![4 - update category](https://user-images.githubusercontent.com/84957563/151061508-0d028e0a-0294-41d1-bfd5-dbfb00d8d920.jpg)


  * course manager (CRUD, detail and add trainee to course).

![1 - show courses](https://user-images.githubusercontent.com/84957563/151061543-b7f99f76-703c-40a7-aa53-aaf62c2943e8.jpg)
![2 - create course](https://user-images.githubusercontent.com/84957563/151061546-5b44a631-09bd-4eea-a84d-509c60287de1.jpg)
![3 - detail course](https://user-images.githubusercontent.com/84957563/151061553-3c51980d-7c17-4004-bd2a-7874d6d54fcc.jpg)
![4 - update course](https://user-images.githubusercontent.com/84957563/151061558-3670b5b0-5611-4973-99a0-29b37aaa1b35.jpg)
![5 - delete course](https://user-images.githubusercontent.com/84957563/151061568-5b9da506-7139-4f36-9529-bd5c7b90e77b.jpg)
![6 - add trainees to course](https://user-images.githubusercontent.com/84957563/151061572-cf7f6c38-3147-45f9-bdb4-0ac383591047.jpg)

  * topic management (CRUD, detail and add the trainer to topic).
 
![1 - show topics](https://user-images.githubusercontent.com/84957563/151061638-91e4e9cd-6ac4-460c-8e60-f38811241a11.jpg)
![2 - create topic](https://user-images.githubusercontent.com/84957563/151061646-121f79b0-dc88-4355-8489-f92f5a8f0e6c.jpg)
![3 - detail topic](https://user-images.githubusercontent.com/84957563/151061649-a26d985d-2410-45aa-9aa6-2278beaea014.jpg)
![4 - update topic](https://user-images.githubusercontent.com/84957563/151061655-67119e35-5c85-463e-ae16-37854daeefe0.jpg)
![5 - delete topic](https://user-images.githubusercontent.com/84957563/151061662-cba525b8-351a-4109-9019-9fd68043fdb2.jpg)
![6 - add trainers](https://user-images.githubusercontent.com/84957563/151061667-6a3ac0ee-e52f-4147-ac78-8bd1822c57a5.jpg)


* Trainer - trainee:
  * login.
  * show course.
 
 ![1 - show courses](https://user-images.githubusercontent.com/84957563/151061738-7598b5de-f12b-41e5-83a5-302c1be2d41d.jpg)

  *detail course.
 
 ![2 - detail courses](https://user-images.githubusercontent.com/84957563/151061755-3e871150-be30-4f5b-8d5a-e822ca1edd92.jpg)
 
  *show and update profile.

![3 - show profile](https://user-images.githubusercontent.com/84957563/151061781-a810d76e-9200-44ce-9dfe-c0e3a9a6d294.jpg)
![4 - update profile](https://user-images.githubusercontent.com/84957563/151061785-6808a034-0d8d-4579-88c2-b070fd3457fd.jpg)

 
