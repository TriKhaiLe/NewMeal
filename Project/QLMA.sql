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
Descript nvarchar(500),
Imgsrc varchar(100)
)

create table Exercise
(
ExID varchar(10) primary key,
ExName nvarchar(100),
ImgLink nvarchar(100),
Kps numeric(7,3)
)

create table UserFood
(
UserID varchar(10),
FoodID varchar(10),
Favorite int,
Last_eat smalldatetime,

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

-------------Exercise---------------
insert into Exercise values('0','Bơi','\Assets\Exercises\boi.jpg','0.07')
insert into Exercise values('1','Cầu lông','\Assets\Exercises\caulong.jpg','0.05')
insert into Exercise values('2','Chạy bộ','\Assets\Exercises\caulong.jpg','0.22')
insert into Exercise values('3','Chạy trên máy','\Assets\Exercises\chaybotrenmay.jpg','0.09')
insert into Exercise values('4','Đá bóng','\Assets\Exercises\dabong.jpg','0.14')
insert into Exercise values('5','Đạp xe','\Assets\Exercises\dapxe.jpg','0.14')
insert into Exercise values('6','Đi bộ','\Assets\Exercises\dibo.jpg','0.06')
insert into Exercise values('7','Gập bụng','\Assets\Exercises\gapbung.jpg','0.17')
insert into Exercise values('8','Hít đất','\Assets\Exercises\hitdat.jpg','0.12')
insert into Exercise values('9','Lắc vòng','\Assets\Exercises\lacvong.jpg','0.12')
insert into Exercise values('10','Nhảy aerobic','\Assets\Exercises\nhayaerobic.jpg','0.14')
insert into Exercise values('11','Nhảy dây','\Assets\Exercises\nhayday.jpg','0.16')
insert into Exercise values('12','Plank','\Assets\Exercises\plank.jpg','0.58')
insert into Exercise values('13','Squat','\Assets\Exercises\squat.jpg','0.1')
insert into Exercise values('14','Tennis','\Assets\Exercises\tennis.jpg','0.2')
--Food

insert into Food values 
('F301','Canh bắp cải','37','Nấu sôi nước\nCho rau đã cắt vào nồi\nChờ rau chín tắt bếp rồi nêm gia vị','Bắp cải','Một món canh đơn giản','\\Food\\F301'),
('F302','Canh bầu','30', 'Nấu sôi nước\nCho bầu đã cắt lát vào nồi\nChờ bầu chín tắt bếp rồi nêm gia vị','Bầu','Một món canh đơn giản','\\Food\\F302'),
('F303','Canh bí đao','29', 'Nấu sôi nước\nCho bí đao đã cắt lát vào nồi\nChờ bí đao chín tắt bếp rồi nêm gia vị','Bí đao','Một món canh đơn giản','\\Food\\F303'),
('F304','Canh bí đỏ','42', 'Nấu sôi nước\nCho bí đao đã cắt lát vào nồi\nChờ bí đỏ chín tắt bếp rồi nêm gia vị','Bí đỏ','Một món canh đơn giản','\\Food\\F304'),
('F305','Canh cải ngọt','30','Nấu sôi nước\nCho rau đã cắt vào nồi\nChờ rau chín tắt bếp rồi nêm gia vị','Cải ngọt','Một món canh đơn giản','\\Food\\F305'),
('F306','Canh chua','29', 'Nấu sôi nước\nCho nguyên liệu đã sơ chế vào nồi\nChờ nguyên liệu chín tắt bếp rồi nêm gia vị','Cà chua, dứa, giá','Món ăn đơn giản cho người thích vị chua','\\Food\\F306'),
('F307','Canh khoai mỡ','51','Cắt lát mỏng khoai mỡ\nPhi hành\nXào khoai mỡ\nCho nước vào nồi khoai\nChờ chín nêm gia vị và tắt bếp','Khoai mỡ, củ hành','Canh có vị béo của khoai, nước dùng ngọt, đẹp mắt, mùi thơm hấp dẫn','\\Food\\F307'),
('F308','Canh mướp','31', 'Nấu sôi nước\nCho rau đã cắt vào nồi\nChờ rau chín tắt bếp rồi nêm gia vị','Mướp','Một món canh đơn giản','\\Food\\F308'),
('F309','Canh rau dền','22','Nấu sôi nước\nCho rau đã cắt vào nồi\nChờ rau chín tắt bếp rồi nêm gia vị','Rau dền','Một món canh đơn giản','\\Food\\F309'),
('F310','Canh rau ngót','29', 'Nấu sôi nước\nCho rau đã cắt vào nồi\nChờ rau chín tắt bếp rồi nêm gia vị','Rau ngót','Một món canh đơn giản','\\Food\\F310');
