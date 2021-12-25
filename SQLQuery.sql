

create table Admin (
	AdminId int identity(1,1) primary key,
	Admin_username varchar(50),
	Admin_password varchar(500),
	Admin_fullname varchar(50)
)

create table Training_staff(
	StaffId varchar(50) primary key,
	Staff_username varchar(50),
	Staff_password varchar(500),
	Staff_fullname varchar(50),
)

create table Trainer (
	TrainerId varchar(50) primary key,
	Trainer_username varchar(50),
	Trainer_password varchar(500),
	Trainer_fullname varchar(50),
	Trainer_type varchar(50),
	Trainer_email varchar(50),
	trainer_phone varchar(20),
)

create table Trainee (
	TraineeId varchar(50) primary key,
	Trainee_username varchar(50),
	Trainee_password varchar(500),
	Trainee_fullname varchar(50),
	Trainee_age int,
	Trainee_birthday date,
	Trainee_education varchar(50),
	Trainee_programming_language nvarchar(50),
	Trainee_TOEIC_score int,
	Trainee_exprience_details nvarchar(500),
	Trainee_department nvarchar(100),
	Trainee_location nvarchar(200)
)

create table CourseCategory (
	CategoryId int identity(1,1) primary key,
	Category_name nvarchar(100),
	Category_description nvarchar(200) 
)

create table Course (
	CourseId int identity(1,1) primary key,
	Course_name nvarchar(100),
	Course_description nvarchar(200),
	CategoryId int,
	DateToStart date,
	FOREIGN KEY (CategoryId) REFERENCES courseCategory(CategoryId)
)

create table Topic (
	TopicId int identity(1,1) primary key,
	Topic_name nvarchar(100),
	Topic_description nvarchar(200),
	CourseId int,
	FOREIGN KEY (CourseId) REFERENCES course(CourseId)
)

create table AssignCourse (
	AssCourseId int identity(1,1) primary key,
	CourseId int,
	TraineeId varchar(50),
	FOREIGN KEY (CourseId) REFERENCES course(CourseId),
	FOREIGN KEY (TraineeId) REFERENCES Trainee(TraineeId)
)

create table AssignTopic (
	AssTopicId int identity(1,1) primary key,
	TopicId int,
	TrainerId varchar(50),
	FOREIGN KEY (TopicId) REFERENCES Topic(TopicId),
	FOREIGN KEY (TrainerId) REFERENCES Trainer(TrainerId)
)
