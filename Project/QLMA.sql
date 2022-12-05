create database QLMA
go

use QLMA
go

create table FUser
(
UserID varchar(10) primary key,
UName nvarchar(100),
UWeight int,
UHeight int,
Age int,
Sex int,
UStatus int,
Passwrd varchar(20),
Username varchar(20) unique
)

create table Food
(
FoodID varchar(10) primary key,
FoodName nvarchar(100),
Kcal int ,
Recipe nvarchar(max),
Ingredients nvarchar(1000),
Last_eat smalldatetime,
Descript nvarchar(500),
Imgsrc varchar(100)
)

create table Exercise
(
ExID varchar(10) primary key,
ExName nvarchar(100),
ExTime int,
Times int ,
Kps int
)

create table UserFood
(
UserID varchar(10),
FoodID varchar(10),
Favorite int

constraint pk_UserFood primary key(UserID , FoodID)
)

create table UserExercise
(
UserID varchar(10),
ExID varchar(10)

constraint pk_UserEx primary key(UserID , ExID)
)

create table FoodType
(
TypeID varchar(10),
FoodID varchar(10),
MealTime int 

constraint pk_FoodType primary key(TypeID , FoodID)
)

--------Foreign Key----------
-------------FoodType--------------
alter table FoodType add constraint fk_FT_Food foreign key (FoodID) references Food(FoodID)
--------------UserFood----------------
alter table UserFood add constraint fk_UF_Food foreign key (FoodID) references Food(FoodID)
alter table UserFood add constraint fk_UF_User foreign key (UserID) references FUser(UserID)
-------------UserExercise---------------
alter table UserExercise add constraint fk_UE_User foreign key (UserID) references FUser(UserID)
alter table UserExercise add constraint fk_UE_Exe foreign key (ExID) references Exercise(ExID)

-------------------------------------------------
alter table FUser nocheck constraint all
alter table Food nocheck constraint all
alter table Exercise nocheck constraint all
alter table FoodType nocheck constraint all
alter table UserFood nocheck constraint all
alter table UserExercise nocheck constraint all

select * from FUser
select * from Food
select * from UserFood
select * from UserExercise
select * from FoodType
select * from Exercise

---------------------Insert--------------------
set dateformat dmy