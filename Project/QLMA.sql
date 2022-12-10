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
TypeName nvarchar(20),
Kcal int ,
Recipe nvarchar(max),
Ingredients nvarchar(1000),
Descript nvarchar(500),
MealTime int,
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
ExID varchar(10),

constraint pk_UserEx primary key(UserID , ExID)
)

--------Foreign Key----------

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

-------------Food---------------

insert into Food values 
('F101','Hủ tiếu bò kho','538','Sơ chế rau củ-Sơ chế thịt bò-Nấu nước dùng bò kho','Nạm bò, hủ tiếu, cà rốt, cây sả, giá sống, hành tây, ngò gai, húng quế, rau răm, gia vị bò kho, màu hạt điều, hành tím, tỏi băm','Món ăn nước phổ biến','\Assets\Food\F101.jpg'),
('F102','Hủ tiếu Nam vang','400','Sơ chế giò heo và tôm-Sơ chế các nguyên liệu khác-Làm sốt thịt-Nấu nước dùng','Giò heo, thịt bằm, tôm, trứng cút, hành lá, hành tím, bún khô, rau ăn kèm, dầu ăn, gia vị','Món ăn nước phổ biến ở Nam Bộ','\Assets\Food\F102.jpg'),
('F103','Mì quảng','541','Sơ chế nguyên liệu-Nấu nước dùng và ướp gia vị-Làm nhân','Sợi mì Quảng, nhân tùy chọn (thịt, tôm, gà,...), rau sống, đậu phộng, bánh tráng','Đặc sản nổi tiếng miền Trung','\Assets\Food\F103.jpg'),
('F104','Mì thịt heo','415','Sơ chế nguyên liệu-Bắc nồi nước-Cho xương và thịt lợn cùng cần tây, gừng vào nồi, nêm gia vị rồi hầm khoảng 30p-Chần mì rồi cho vào tô-Chan nước dùng, xếp thịt heo lên trên','Xương heo, thịt heo, cần tây, gừng, hành khô, hành lá, mì tươi, giá đỗ','Món ăn nước','\Assets\Food\F104.jpg'),
('F105','Mì vịt tiềm','776','Sơ chế thịt vịt-Nấu nước dùng-Hầm thịt vịt trong nước dùng-Sơ chế mì','Mì vắt, đùi vịt, rượu trắng, gừng, tỏi băm, xì dầu, nước tương, tiêu, hoa hồi, thanh quế, trần bì, hành tím, táo tàu, bạch quả, củ sen, nấm hương, dầu mè, hạt nêm, đường phèn, muối','Món ăn ngon nổi tiếng của người Hoa','\Assets\Food\F105.jpg'),
('F106','Miến gà','635','Sơ chế nguyên liệu-Ướp thịt gà-Nấu nước dùng','Gà, lòng gà, miến, hành tây, nấm mèo, hành lá, ngò rí, rau răm, hành tím, gia vị','Món ăn nước phổ biến','\Assets\Food\F106.jpg'),
('F107','Phở bò chín','456','Sơ chế nguyên liệu-Làm nước dùng','Phở, thịt bò, gầu bò, xương ống bò, củ cải trắng, hành tây, hành tím, gừng, trái thảo quả, thanh quế nhỏ, hoa hồi, hành lá, giá đỗ, rau thơm, gia vị','Món ăn nước phổ biến','\Assets\Food\F107.jpg'),
('F108','Phở bò tái','431','Sơ chế nguyên liệu-Làm nước dùng-Trụng phở và trần sơ thịt bò rồi vớt ra tô-Chan nước dùng','Phở, thịt bò, xương bò, hành tây, hành tím, gừng, hành hoa, rau mùi, gói gia vị nấu phở bò, gia vị khác','Món ăn nước phổ biến','\Assets\Food\F108.jpg'),
('F109','Phở bò viên','431','Sơ chế bò-Sơ chế nguyên liệu-Ninh nước dùng-Cắt thịt bò-Trụng phở','Phở, xương bò, thịt bò, gân bò, nạm bò, gầu bò, bò viên, hoa hồi, thảo quả, quế, gừng, hành tây, hành tím, rau ăn kèm, gia vị','Món ăn nước phổ biến','\Assets\Food\F109.jpg'),
('F110','Phở gà','483','Sơ chế nguyên liệu-Luộc gà và nấu nước dùng-Trụng phở','Phở, gà, giá đỗ, hành tây, sả, gừng, hành lá, ngò, ớt, chanh, gia vị','Món ăn nước phổ biến','\Assets\Food\F110.jpg');

insert into Food values 
('F301','Canh bắp cải','37','Nấu sôi nước-Cho rau đã cắt vào nồi-Chờ rau chín tắt bếp rồi nêm gia vị','Bắp cải','Một món canh đơn giản','\Assets\Food\F301.jpg'),
('F302','Canh bầu','30', 'Nấu sôi nước-Cho bầu đã cắt lát vào nồi-Chờ bầu chín tắt bếp rồi nêm gia vị','Bầu','Một món canh đơn giản','\Assets\Food\F302.jpg'),
('F303','Canh bí đao','29', 'Nấu sôi nước-Cho bí đao đã cắt lát vào nồi-Chờ bí đao chín tắt bếp rồi nêm gia vị','Bí đao','Một món canh đơn giản','\Food\F303.jpg'),
('F304','Canh bí đỏ','42', 'Nấu sôi nước-Cho bí đao đã cắt lát vào nồi-Chờ bí đỏ chín tắt bếp rồi nêm gia vị','Bí đỏ','Một món canh đơn giản','\Assets\Food\F304.jpg'),
('F305','Canh cải ngọt','30','Nấu sôi nước-Cho rau đã cắt vào nồi-Chờ rau chín tắt bếp rồi nêm gia vị','Cải ngọt','Một món canh đơn giản','\Assets\Food\F305.jpg'),
('F306','Canh chua','29', 'Nấu sôi nước-Cho nguyên liệu đã sơ chế vào nồi-Chờ nguyên liệu chín tắt bếp rồi nêm gia vị','Cà chua, dứa, giá','Món ăn đơn giản cho người thích vị chua','\Assets\Food\F306.jpg'),
('F307','Canh khoai mỡ','51','Cắt lát mỏng khoai mỡ-Phi hành-Xào khoai mỡ-Cho nước vào nồi khoai-Chờ chín nêm gia vị và tắt bếp','Khoai mỡ, củ hành','Canh có vị béo của khoai, nước dùng ngọt, đẹp mắt, mùi thơm hấp dẫn','\Assets\Food\F307.jpg'),
('F308','Canh mướp','31', 'Nấu sôi nước-Cho rau đã cắt vào nồi-Chờ rau chín tắt bếp rồi nêm gia vị','Mướp','Một món canh đơn giản','\Assets\Food\F308.jpg'),
('F309','Canh rau dền','22','Nấu sôi nước-Cho rau đã cắt vào nồi-Chờ rau chín tắt bếp rồi nêm gia vị','Rau dền','Một món canh đơn giản','\Assets\Food\F309\.jpg'),
('F310','Canh rau ngót','29', 'Nấu sôi nước-Cho rau đã cắt vào nồi-Chờ rau chín tắt bếp rồi nêm gia vị','Rau ngót','Một món canh đơn giản','\Assets\Food\F310.jpg');

insert into Food values 
('F401','Bia','141','','','Thức uống có cồn','\Assets\Food\F401.jpg'),
('F402','Cà phê sữa gói','85','','','Đồ uống pha sẵn','\Assets\Food\F402.jpg'),	
('F403','Cocktail trái cây','158','','','Đồ uống có cồn','\Assets\Food\F403.jpg'),
('F404','Nước cam vắt','226','','Cam','Nước trái cây','\Assets\Food\F404.jpg'),
('F405','Nước chanh','149','','Chanh','Nước trái cây','\Assets\Food\F405.jpg'),
('F406','Nước ép trái cây đóng hộp','74','','','Đồ uống sẵn','\Assets\Food\F406.jpg'),
('F407','Nước mía','106','','','Nước giải khát','\Assets\Food\F407.jpg'),
('F408','Nước ngọt có gas','146','','','Nước giải khát','\Assets\Food\F408.jpg'),
('F409','Nước sâm','74','','','Nước giải khát','\Assets\Food\F409.jpg'),
('F410','Sinh tố','277','','','Trái cây xay','\Assets\Food\F410.jpg');		
