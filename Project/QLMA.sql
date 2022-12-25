﻿create database QLMA
go

use QLMA
go

create table FUser
(
UserID int identity(1,1) primary key,
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
FoodID int identity(1,1) primary key,
FoodName nvarchar(100),
Type nvarchar(20),
Kcal int ,
Recipe nvarchar(max),
Ingredients nvarchar(1000),
Descript nvarchar(500),
MealTime int,
Imgsrc varchar(100)
)

create table Exercise
(
ExID int identity(1,1) primary key,
ExName nvarchar(100),
ImgLink nvarchar(100),
Kps numeric(7,3)
)

create table UserFood
(
UserID int,
FoodID int,
Favorite int,
Last_eat smalldatetime,

constraint pk_UserFood primary key(UserID , FoodID)
)

create table UserExercise
(
UserID int,
ExID int,
Favourite int
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
alter table UserFood nocheck constraint all
alter table UserExercise nocheck constraint all

select * from FUser
select * from Food
select * from UserFood
select * from UserExercise
select * from Exercise

---------------------Insert--------------------
set dateformat dmy

-------------Exercise---------------
insert into Exercise values(N'Bơi','\Assets\Exercises\boi.jpg','0.07')
insert into Exercise values(N'Cầu lông','\Assets\Exercises\caulong.jpg','0.05')
insert into Exercise values(N'Chạy bộ','\Assets\Exercises\caulong.jpg','0.22')
insert into Exercise values(N'Chạy trên máy','\Assets\Exercises\chaybotrenmay.jpg','0.09')
insert into Exercise values(N'Đá bóng','\Assets\Exercises\dabong.jpg','0.14')
insert into Exercise values(N'Đạp xe','\Assets\Exercises\dapxe.jpg','0.14')
insert into Exercise values(N'Đi bộ','\Assets\Exercises\dibo.jpg','0.06')
insert into Exercise values(N'Gập bụng','\Assets\Exercises\gapbung.jpg','0.17')
insert into Exercise values(N'Hít đất','\Assets\Exercises\hitdat.jpg','0.12')
insert into Exercise values(N'Lắc vòng','\Assets\Exercises\lacvong.jpg','0.12')
insert into Exercise values(N'Nhảy aerobic','\Assets\Exercises\nhayaerobic.jpg','0.14')
insert into Exercise values(N'Nhảy dây','\Assets\Exercises\nhayday.jpg','0.16')
insert into Exercise values('Plank','\Assets\Exercises\plank.jpg','0.58')
insert into Exercise values('Squat','\Assets\Exercises\squat.jpg','0.1')
insert into Exercise values('Tennis','\Assets\Exercises\tennis.jpg','0.2')

-------------Food---------------
----Mon nuoc---
insert into Food values 
(N'Hủ tiếu bò kho',N'Món nước','538',N'B1 : Sơ chế rau củ
B2 : Sơ chế thịt bò
B3 : Nấu nước dùng bò kho',N'Nạm bò, hủ tiếu, cà rốt, cây sả, giá sống, hành tây, ngò gai, húng quế, rau răm, gia vị bò kho, màu hạt điều, hành tím, tỏi băm',N'Món ăn nước phổ biến','9','\Assets\Food\F101.jpg'),
(N'Hủ tiếu Nam vang',N'Món nước','400',N'B1 : Sơ chế giò heo và tôm
B2 : Sơ chế các nguyên liệu khác
B3 : Làm sốt thịt
B4 : Nấu nước dùng',N'Giò heo, thịt bằm, tôm, trứng cút, hành lá, hành tím, bún khô, rau ăn kèm, dầu ăn, gia vị',N'Món ăn nước phổ biến ở Nam Bộ','9','\Assets\Food\F102.jpg'),
(N'Mì quảng',N'Món nước','541',N'B1 : Sơ chế nguyên liệu
B2 : Nấu nước dùng và ướp gia vị
B3 : Làm nhân',N'Sợi mì Quảng, nhân tùy chọn (thịt, tôm, gà,...), rau sống, đậu phộng, bánh tráng',N'Đặc sản nổi tiếng miền Trung','9','\Assets\Food\F103.jpg'),
(N'Mì thịt heo',N'Món nước','415',N'B1 : Sơ chế nguyên liệu
B2 : Bắc nồi nước
B3 : Cho xương và thịt lợn cùng cần tây, gừng vào nồi, nêm gia vị rồi hầm khoảng 30p
B4 : Chần mì rồi cho vào tô
B5 : Chan nước dùng, xếp thịt heo lên trên',N'Xương heo, thịt heo, cần tây, gừng, hành khô, hành lá, mì tươi, giá đỗ',N'Món ăn nước phổ biến','9','\Assets\Food\F104.jpg'),
(N'Mì vịt tiềm',N'Món nước','776',N'B1 : Sơ chế thịt vịt
B2 : Nấu nước dùng
B3 : Hầm thịt vịt trong nước dùng
B4 : Sơ chế mì',N'Mì vắt, đùi vịt, rượu trắng, gừng, tỏi băm, xì dầu, nước tương, tiêu, hoa hồi, thanh quế, trần bì, hành tím, táo tàu, bạch quả, củ sen, nấm hương, dầu mè, hạt nêm, đường phèn, muối',N'Món ăn ngon nổi tiếng của người Hoa','9','\Assets\Food\F105.jpg'),
(N'Miến gà',N'Món nước','635',N'B1 : Sơ chế nguyên liệu
B2 : Ướp thịt gà
B3 : Nấu nước dùng',N'Gà, lòng gà, miến, hành tây, nấm mèo, hành lá, ngò rí, rau răm, hành tím, gia vị',N'Món ăn nước phổ biến','9','\Assets\Food\F106.jpg'),
(N'Phở bò chín',N'Món nước','456',N'B1 : Sơ chế nguyên liệu
B2 : Làm nước dùng',N'Phở, thịt bò, gầu bò, xương ống bò, củ cải trắng, hành tây, hành tím, gừng, trái thảo quả, thanh quế nhỏ, hoa hồi, hành lá, giá đỗ, rau thơm, gia vị',N'Món ăn nước phổ biến','9','\Assets\Food\F107.jpg'),
(N'Phở bò tái',N'Món nước','431',N'B1 : Sơ chế nguyên liệu
B2 : Làm nước dùng
B3 : Trụng phở và trần sơ thịt bò rồi vớt ra tô
B4 : Chan nước dùng',N'Phở, thịt bò, xương bò, hành tây, hành tím, gừng, hành hoa, rau mùi, gói gia vị nấu phở bò, gia vị khác',N'Món ăn nước phổ biến','9','\Assets\Food\F108.jpg'),
(N'Phở bò viên',N'Món nước','431',N'B1 : Sơ chế bò
B2 : Sơ chế nguyên liệu
B3 : Ninh nước dùng
B4 : Cắt thịt bò
B5 : Trụng phở',N'Phở, xương bò, thịt bò, gân bò, nạm bò, gầu bò, bò viên, hoa hồi, thảo quả, quế, gừng, hành tây, hành tím, rau ăn kèm, gia vị',N'Món ăn nước phổ biến','9','\Assets\Food\F109.jpg'),
(N'Phở gà',N'Món nước','483',N'B1 : Sơ chế nguyên liệu
B2 : Luộc gà và nấu nước dùng
B3 : Trụng phở',N'Phở, gà, giá đỗ, hành tây, sả, gừng, hành lá, ngò, ớt, chanh, gia vị',N'Món ăn nước phổ biến','9','\Assets\Food\F110.jpg');
----Canh----
insert into Food values 
(N'Canh bắp cải','Canh','37',N'B1 : Nấu sôi nước
B2 : Cho rau đã cắt vào nồi
B3 : Chờ rau chín tắt bếp rồi nêm gia vị',N'Bắp cải',N'Một món canh đơn giản','8','\Assets\Food\F301.jpg'),
(N'Canh bầu','Canh','30', N'B1 : Nấu sôi nước
B2 : Cho bầu đã cắt lát vào nồi
B3 : Chờ bầu chín tắt bếp rồi nêm gia vị',N'Bầu',N'Một món canh đơn giản','8','\Assets\Food\F302.jpg'),
(N'Canh bí đao','Canh','29',N'B1 : Nấu sôi nước
B2 : Cho bí đao đã cắt lát vào nồi
B3 : Chờ bí đao chín tắt bếp rồi nêm gia vị',N'Bí đao',N'Một món canh đơn giản','8','\Assets\Food\F303.jpg'),
(N'Canh bí đỏ','Canh','42', N'B1 : Nấu sôi nước
B2 : Cho bí đao đã cắt lát vào nồi
B3 : Chờ bí đỏ chín tắt bếp rồi nêm gia vị',N'Bí đỏ',N'Một món canh đơn giản','8','\Assets\Food\F304.jpg'),
(N'Canh cải ngọt','Canh','30',N'B1 : Nấu sôi nước
B2 : Cho rau đã cắt vào nồi
B3 : Chờ rau chín tắt bếp rồi nêm gia vị',N'Cải ngọt',N'Một món canh đơn giản','8','\Assets\Food\F305.jpg'),
(N'Canh chua','Canh','29', N'B1 : Nấu sôi nước
B2 : Cho nguyên liệu đã sơ chế vào nồi
B3 : Chờ nguyên liệu chín tắt bếp rồi nêm gia vị',N'Cà chua, dứa, giá',N'Món ăn đơn giản cho người thích vị chua','8','\Assets\Food\F306.jpg'),
(N'Canh khoai mỡ','Canh','51',N'B1 : Cắt lát mỏng khoai mỡ
B2 : Phi hành-Xào khoai mỡ
B3 : Cho nước vào nồi khoai
B4 : Chờ chín nêm gia vị và tắt bếp',N'Khoai mỡ, củ hành',N'Canh có vị béo của khoai, nước dùng ngọt, đẹp mắt, mùi thơm hấp dẫn','8','\Assets\Food\F307.jpg'),
(N'Canh mướp','Canh','31', N'B1 : Nấu sôi nước
B2 : Cho rau đã cắt vào nồi
B3 : Chờ rau chín tắt bếp rồi nêm gia vị',N'Mướp',N'Một món canh đơn giản','8','\Assets\Food\F308.jpg'),
(N'Canh rau dền','Canh','22',N'B1 : Nấu sôi nước
B2 : Cho rau đã cắt vào nồi
B3 : Chờ rau chín tắt bếp rồi nêm gia vị',N'Rau dền',N'Một món canh đơn giản','8','\Assets\Food\F309.jpg'),
(N'Canh rau ngót','Canh','29', N'B1 : Nấu sôi nước
B2 : Cho rau đã cắt vào nồi
B3 : Chờ rau chín tắt bếp rồi nêm gia vị',N'Rau ngót',N'Một món canh đơn giản','8','\Assets\Food\F310.jpg');
---Thuc uong----
insert into Food values 
(N'Bia',N'Thức uống','141','','',N'Thức uống có cồn','8','\Assets\Food\F401.jpg'),
(N'Cà phê sữa gói',N'Thức uống','85','','',N'Đồ uống pha sẵn','3','\Assets\Food\F402.jpg'),	
(N'Cocktail trái cây',N'Thức uống','158','','',N'Đồ uống có cồn','8','\Assets\Food\F403.jpg'),
(N'Nước cam vắt',N'Thức uống','226','','Cam',N'Nước trái cây','9','\Assets\Food\F404.jpg'),
(N'Nước chanh',N'Thức uống','149','','Chanh',N'Nước trái cây','9','\Assets\Food\F405.jpg'),
(N'Nước ép trái cây đóng hộp',N'Thức uống','74','','',N'Đồ uống sẵn','9','\Assets\Food\F406.jpg'),
(N'Nước mía',N'Thức uống','106','','',N'Nước giải khát','8','\Assets\Food\F407.jpg'),
(N'Nước ngọt có gas',N'Thức uống','146','','',N'Nước giải khát','8','\Assets\Food\F408.jpg'),
(N'Nước sâm',N'Thức uống','74','','',N'Nước giải khát','8','\Assets\Food\F409.jpg'),
(N'Sinh tố',N'Thức uống','277','','',N'Trái cây xay','9','\Assets\Food\F410.jpg');		
---Com----
insert into Food values
(N'Cơm rang thập cẩm',N'Cơm','800',N'B1 : Sơ chế rau củ, lạp xưởng
B2 : Đánh trứng
B3 : Xào nguyên liệu
B4 : Chiên cơm với lửa vừa',N'Cơm, lạp xưởng, trứng gà, đậu que, cà rốt, tỏi, gia vị',N'Cơm rang thập cẩm là món vô cùng dễ ăn và thu hút mọi người','12','\Assets\Food\F001.jpg'),
(N'Cơm nắm rau củ',N'Cơm','150',N'B1 : Sơ chế rau củ, nấm hương
B2 : Xào nguyên liệu, nêm nếm vừa ăn
B3 : Vo cơm nắm',N'Gạo dẻo thơm, nấm hương, cà rốt, nước dùng gà, mè rang, tỏi băm, gừng, dầu mè',N'Cơm nắm là món ăn quen thuộc với nhiều người vì nó ngon và đầy đủ dưỡng chất.','12','\Assets\Food\F002.jpg'),
(N'Dưa chuột cuộn cơm',N'Cơm','145',N'B1 : Dưa chuột, rau củ làm sạch, cá ngừ xé nhỏ
B2 : Cho gia vị vào cơm, trộn đều
B3 : Cuộn cơm',N'Dưa chuột, ớt chuông, hành tây, cá ngừ ngâm dầu, cơm, gia vị',N'Món dưa chuột cuộn cơm vừa ngon giòn, thanh mát lại lạ miệng','12','\Assets\Food\F003.jpg'),
(N'Kiratanpo-Cơm nướng Nhật Bản',N'Cơm','140',N'B1 : Nấu sốt miso
B2 : Nghiền khoai tây trộn với cơm và bột bắp
B3 : Bọc cơm xung quanh đũa tre và nướng bằng chảo
B4 : Tưới sốt miso lên',N'Cơm trắng, bột bắp, thịt heo xay, tương miso, rượu, gia vị',N'Món ăn của xứ sở Hoa anh đào lạ miệng, lạ mắt','12','\Assets\Food\F004.jpg'),
(N'Cơm nắm chua ngọt',N'Cơm','150',N'B1 : Thái nhỏ rau củ, xào với hạt nêm
B2 : Cho cơm và sốt cà chua vào trộn đều
B3 : Nắm cơm lại thành từng nắm',N'Cơm, hành tây, cà rốt, bí ngòi, sốt cà chua',N'Cơm nắm chua ngọt với cách chế biến đơn giản cùng vị chua ngọt lạ miệng thích hợp cho một bữa ăn bận rộn của bạn','12','\Assets\Food\F005.jpg'),
(N'Trứng cuộn cơm',N'Cơm','400',N'B1 : Sơ chế nguyên liệu
B2 : Xào ức gà với rau củ
B3 : Thêm cơm và sốt cà chua
B4 : Trứng và sữa đánh đều, tráng mỏng
B5 : Cuộn với cơm',N'Hành tây, ức gà, rau củ các loại, cơm gạo dẻo, sốt cà chua, trứng, sữa, gia vị',N'Trứng cuộn cơm là món ngon dễ làm, đầy đủ dinh dưỡng, giúp đổi mới khẩu vị cho bữa cơm gia đình','12','\Assets\Food\F006.jpg'),
(N'Cơm chiên kim chi',N'Cơm','300',N'B1 : Thái hạt lựu tất cả nguyên liệu
B2 : Trứng chiên mỏng
B3 : Phi hành thơm và đổ cơm trắng vào chảo
B4 : Nêm nếm đều gia vị
B5 : Thêm xúc xích lát mỏng, hành lá, xì dầu',N'Cơm trắng, xúc xích, hành tây, hành lá, kim chi, trứng gà, gia vị',N'Cơm chiên kimchi là món ăn không chỉ tận dụng được cơm còn dư mà còn mang hương bị ẩm thực của Hàn, vị chua cay đặc biệt','12','\Assets\Food\F007.jpg'),
(N'Bánh rán từ cơm nguội',N'Cơm','341',N'B1 : Nhào bột thành hỗn hợp dẻo mịn
B2 : Chiên cơm với dầu ăn, sốt bò bằm
B3 : Chia bột, cán bột mỏng, cho cơm đã chiên vào giữa làm nhân
B4 : Ấn dẹt miếng bánh rồi chiên vàng hai mặt',N'Cơm nguội, bột mì đa dụng, nước ấm, gia vị',N'Món bánh rán từ cơm nguội ngon hấp dẫn mà cách thực hiện lại vô cùng đơn giản','12','\Assets\Food\F008.jpg'),
(N'Cơm nắm cá ngừ đậu phụ chiên',N'Cơm','400',N'B1 : Sơ chế rau củ
B2 : Tán nhuyễn đậu phụ và cá ngừ
B3 : Trộn đều với cơm và gia vị
B4 : Nắm cơm lại vừa ăn',N'Cá ngừ đóng hộp, đậu phụ, cà rốt, hành lá, cơm, bột ngô, bột cà mì, vừng, gia vị',N'Món cơm nắm cá ngừ đậu phụ chiên này cực kỳ phù hợp cho ai bận rộn vì nó vừa đầy đủ dinh dưỡng vừa thơm ngon.','12','\Assets\Food\F009.jpg'),
(N'Pizza cơm nguội',N'Cơm','370',N'B1 : Trộn trứng gà với cơm
B2 : Dàn mỏng cơm và chiên vàng hai mặt
B3 : Cho rau củ, phô mai lên trên cùng',N'Cơm nguội, trứng gà, bắp hạt, phô mai, ớt chuông, hành tây, giăm bông, nấm, sốt cà chua',N'Sự kết hợp giữa pizza phương Tây và cơm trắng của phương Đông sẽ là một món ăn thú vị đem lại cho bạn sự thích thú.','12','\Assets\Food\F010.jpg');
------Do bien-----
insert into Food values
(N'Cá hồi sốt bơ tỏi chanh', N'Đồ biển', '208', N'B1 : Làm sạch cá, ướp đều gia vị
B2 : Áp chảo với bơ
B3 : Làm nước chấm với nước cốt chanh, cà phê,bột bắp, đường',N'Cá hồi phi lê, chanh, gừng thái sợi, tỏi băm, bơ thực vật, đường, tiêu, muối, bột bắp, nước tương',N'Cá hồi sốt bơ tỏi chanh thơm ngon, vị chua ngọt hấp dẫn, béo ngậy của bơ, thơm của gừng tỏi, thịt cá mềm không bở','9','\Assets\Food\F201.png'),
(N'Cocktail tôm', N'Đồ biển', '252', N'B1 : Làm nước dùng với hành, tỏi băm, lá nguyệt quế, chanh, rượu trắng
B2 : Làm nước sốt với sốt cà chua, chanh, tương ớt
B3 : Luộc tôm bằng nước dùng đã chuẩn bị
B4 : Trình bày lên dĩa',N'Tôm, rượu trắng, hành tây, lá nguyệt quế, chanh, cà chua, tương ớt',N'Tôm là loại hải sản rất quen thuộc nhưng đem lại nhiều lợi ích cho sức khỏe. Đây là món hải sản tốt cho sức khỏe phổ biến ở Anh, Mỹ.','9','\Assets\Food\F202.jpg'),
(N'Súp nghêu rau củ', N'Đồ biển', '126', N'B1 : Chiên thịt xông khói
B2 : Cho cà rốt, hành tây, cần tây, ớt chuông xanh xào đều
B3 : Thêm sốt cà chua và một ít nước luộc nghêu
B4 : Thêm khoai tây và nghêu vào',N'Cà rốt, hành tây, cần tây, ớt chuông xanh, sốt cà chua, nghêu, khoai tây',N'Không chỉ là món khai vị nổi tiếng với sự bổ dưỡng, thơm ngon, và màu sắc hấp dẫn, súp nghêu còn là món ngon hằng ngày trong các bữa cơm gia đình, đặc biệt là với trẻ nhỏ.','12','\Assets\Food\F203.jpg'),
(N'Salad cá cơm',N'Đồ biển','131',N'B1 : Rửa sạch rau củ, thái nhỏ
B2 : Rửa sạch cá cơm, chiên giòn với bột
B3 : Trộn đều rau và cá với các loại nước sốt',N'Cá cơm, bột chiên giòn, xà lách xanh, cà chua, củ hành tây, dưa leo, mayonnaise, sữa chua, súp sữa đặc',N'Salad cá cơm còn là món ăn khá lạ với cách kết hợp độc đáo giữa cá cơm chiên giòn và món rau xà lách ngon mắt','12','\Assets\Food\F204.jpg'),
(N'Bánh mì kẹp cá ngừ',N'Đồ biển','302',N'B1 : Sơ chế rau củ, luộc khoai tây, hấp trứng gà
B2 : Trộn cá ngừ với sốt và rau củ đã chuẩn bị
B3 : Kẹp vào bánh mì',N'Cá ngừ hộp, bánh mì, trứng, xa lách, cà chua bi, khoai tây, cà rốt, sốt mayonnaise, dầu ô liu, muối, giấm',N'Bánh mì kẹp cá ngừ cho bữa sáng nhanh gọn lẹ','3','\Assets\Food\F205.jpg'),
(N'Hàu nướng mỡ hành',N'Đồ biển','198',N'B1 : Sơ chế nguyên liệu: Ngâm hàu và tách vỏ, rửa sạch và thái nhỏ rau thơm
B2 : Nướng hàu, quét mỡ hành liên tục đến khi hàu chín có mùi thơm',N'Hàu tươi sống, bơ lạt, đậu phọng rang, rau thơm, hành phi, gia vị',N'Hàu là món ăn được nhiều người yêu thích bơi thịt hàu thơm béo, chứa nhiều chất dinh dưỡng','9','\Assets\Food\F206.png'),
(N'Cá trê nướng',N'Đồ biển','534',N'B1 : Sơ chế sạch cá
B2 : Ướp cá với gia vị vừa phải, thoa phần muối ớt lên da cá để thấm đều
B3 : Nướng cá bằng que hoặc vỉ nướng',N'Cá trê, muối, bột ngọt, ớt hiểm, muối hột',N'Loài cá da trơn này luôn là một món hải sản có lợi cho sức khỏe. Vì chiên rán sẽ thêm nhiều calo và chất béo vào món ăn. Vì vậy nướng chúng để trở thành món ăn lành mạnh','9','\Assets\Food\F207.jpg'),
(N'Cá mòi',N'Đồ biển','250',N'B1 : Làm sạch nguyên liệu, để ráo nước
B2 : Dùng nồi kho,xếp muối vào đáy nồi, cho cá lên trên, tiếp đến là cà chua và sả, đổ nước xấp mặt cá
B3 : Cho nồi cá lên bếp và kho đến khi chín mềm',N'Cá mòi tươi, dưa muối, cà chua, sả, dầu ăn, gia vị',N'Với thành phần dinh dưỡng đa dạng với nhiều chất khoáng và vitamin, cá mòi kho là ứng cử viên sáng giá trong thực đơn của con người','9','\Assets\Food\F208.jpg'),
(N'Gỏi hải sản tôm mực',N'Đồ biển','70',N'B1 : Bóc vỏ tôm, rửa sạch mực, thái nhỏ
B2 : Rửa sạch, sơ chế rau củ
B3 : Đem rau củ trộn đều với giấm đường
B4 : Làm nước trộn gỏi với nước mắm, đường, tương ớt, chanh
B5 : Trộn đều gỏi',N'Tôm, mực, hành tây, cà rốt, dưa chuột, gia vị',N'Vào mùa ngày nắng nóng, đĩa gỏi hài sản chắc chắn sẽ làm dịu đi cái nóng nhờ vào sự tươi mát ủa món ăn','9','\Assets\Food\F209.png'),
(N'Cá trích kho dứa',N'Đồ biển','233',N'B1 : Sơ chế, làm sạch cá trích, dứa, rau củ
B2 : Chiên cá trích chín đều
B3 : Tiến hành kho cá trích với dứa, nêm nếm gia vị vừa ăn',N'Cá trích, dứa, tỏi, ớt hiểm, gia vị',N'Món cá trích kho tuy đơn giản nhưng mang lại cho bữa cơm gia định bạn nhiều hương vị đậm đà','9','\Assets\Food\F210.png');
------An vat-----
insert into Food values
(N'Đậu phộng da cá',N'Ăn vặt','161',N'B1 : Ngâm đậu phộng, trộn đều với gia vị và bột
B2 : Chiên đậu phộng đến khi vàng',N'Đậu phộng, bột mì, nước cốt dừa, gia vị',N'Đậu phộng da cá thơm lừng, giòn rụm, dễ làm','12','\Assets\Food\F501.jpg'),
(N'Bánh mì ngào đường',N'Ăn vặt','300',N'B1 : Cắt bánh mì thành miếng nhỏ
B2 : Cho bánh mì vào chảo chiên vàng
B3 : Trộn với đường đã đun tan với nước',N'Bánh mì sandwich, đường, muối, dầu ăn',N'Chỉ với 20 phút bạn đã có một món ăn vặt cực kì dễ làm','12','\Assets\Food\F502.jpg'),
(N'Snack chuối',N'Ăn vặt','425',N'B1 : Bóc vỏ, cắt chuối thành từng lát
B2 : Đun nóng dầu rồi cho vào chiên giòn',N'Chuối chín, muối, dầu ăn',N'Snack là món ăn ưa thích của trẻ em, nếu gia đình bạn có trẻ nhỏ thì hãy thử nhé','12','\Assets\Food\F503.jpg'),
(N'Snack khoai tây',N'Ăn vặt','160',N'B1 : Khoai tây gọt vỏ, cắt lát
B2 : Trộn với một muỗng dầu ăn và chiên với nồi chiên không dầu',N'Khoai tây, muối, cà phê',N'Những món ăn vặt dễ làm tại nhà không thể thiếu snack khoai tây, dễ dàng bảo quản','12','\Assets\Food\F504.jpg'),
(N'Bánh oreo cuộn kem sữa',N'Ăn vặt','453',N'B1 : Tách kem và vỏ bánh
B2 : Xay vỏ bánh với sữa tươi
B3 : Một phần kem vo tròn để vào tủ lạnh, một phần trộn bơ, sữa rồi đánh nhuyễn
B4 : Cho hỗn hợp bánh oreo vào màng bọc cán mỏng và cuộn lại
B5 : Bào mỏng kem oreo rắc lên mặt',N'Bánh oreo, socola, sữa tươi, bơ, đường bột',N'Vị đắng nhẹ kết hợp nhân béo mịn sẽ khiến bạn thích mê.','12','\Assets\Food\F505.jpg'),
(N'Khoai tây chiên nước mắm',N'Ăn vặt','163',N'B1 : Khoai tây rửa sạch, gọt vỏ, cắt thanh nhỏ, ngâm với muối
B2 : Đun nóng dầu và chiên vàng
B3 : Trộn dầu ăn, nước mắm, đường và đun sôi
B4 : Lắc đều với khoai',N'Khoai, nước mắm, đường cát trắng, dầu ăn',N'Nếu bạn thích khoai tây thì có thể đổi món hằng ngày bằng khoai tây chiên nước mắm rất hấp dẫn.','12','\Assets\Food\F506.jpg'),
(N'Bắp xào phô mai',N'Ăn vặt','436',N'B1 : Sơ chế nguyên liệu
B2 : Xào bắp, ớt chuông với bơ trộn với mayonnaise
B3 : Tiếp tục cho phô mai vào đun chảy',N'Bắp Mỹ, ớt chuông, mayonnaise, bơ lạt, phô mai',N'Bắp xào phô mai béo ngậy, thơm ngon mà bất kỳ ai cũng không cưỡng lại được.','12','\Assets\Food\F507.jpg'),
(N'Thạch rau câu bắp',N'Ăn vặt','163',N'B1 : Chuẩn bị bột rau câu, xay bắp lọc lấy nước
B2 : Nấu sữa bắp để nguội
B3 : Đun sôi nước cốt dừa với sữa đặc
B4 : Đổ rau câu theo từng lớp cốt dừa và sữa bắp, để nguội',N'Đường, bột rau câu giòn, bắp Mỹ, nước cốt dừa, sữa đặc',N'Đây là một món ngon dễ làm bạn nên thử để trổ tài chiêu đãi cả nhà đấy','12','\Assets\Food\F508.jpg'),
(N'Gan gà chiên xù',N'Ăn vặt','235',N'B1 : Sơ chế gan gà với muối và rượu
B2 : Ướp gia vị vừa ăn
B3 : Nhúng gan gà qua trứng và bột chiên xù rồi chiên giòn',N'Gan gà, bột mì, trứng gà, bột chiên xù, rượu trắng, gia vị',N'Miếng gà vàng ươm, giòn rụm sẽ kích thích vị giác của bạn đấy','12','\Assets\Food\F509.jpg'),
(N'Trúng cút lộn sốt me',N'Ăn vặt','285',N'B1 : Mỡ heo rửa sạch, chiên lấy tóp mỡ
B2 : Luộc trứng cút, bóc vỏ
B3 : Lọc lấy nước me nêm nếm vừa ăn
B4 : Phi thơm tỏi rồi dun sôi sốt me và cho trứng cút vào',N'Trứng cút, me chín, mỡ heo, dưa leo, ớt sừng, tỏi, gia vị',N'Có thể ăn kèm rau răm, dưa leo, trứng cút sốt me sẽ làm bạn nghiện đấy nhé.','12','\Assets\Food\F510.jpg');

GO
create trigger tgr_User_insert
on FUser
for insert
as
begin
	insert into UserFood(UserID,FoodID) select top 60 UserID, FoodID from Food , inserted order by FoodID asc
	insert into UserExercise(UserID , ExID) select top 15 UserID , ExID from Exercise , inserted order by ExID asc
	update UserFood 
	set Favorite = 0
	update UserExercise
	set Favourite = 0
end


select*from FUser
select*from Food
insert into FUser values('Admin' , 60,160,19,1,0,'admin','admin')
insert into FUser values('User' , 60,160,19,1,0,'user' , 'user')
delete from Exercise where ExName = 'Agaga'
delete from FUser
delete from UserExercise
delete from UserFood
select*from UserExercise
select * from UserFood
select * from Exercise