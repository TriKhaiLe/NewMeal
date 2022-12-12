create database QLMA
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
(N'Hủ tiếu bò kho',N'Món nước','538',N'B1 : Sơ chế rau củ
B2 : Sơ chế thịt bò
B3 : Nấu nước dùng bò kho',N'Nạm bò, hủ tiếu, cà rốt, cây sả, giá sống, hành tây, ngò gai, húng quế, rau răm, gia vị bò kho, màu hạt điều, hành tím, tỏi băm',N'Món ăn nước phổ biến','9','\Assets\Food\F101.jpg'),
('Hủ tiếu Nam vang','Món nước','400','Sơ chế giò heo và tôm-Sơ chế các nguyên liệu khác-Làm sốt thịt-Nấu nước dùng','Giò heo, thịt bằm, tôm, trứng cút, hành lá, hành tím, bún khô, rau ăn kèm, dầu ăn, gia vị','Món ăn nước phổ biến ở Nam Bộ','9','\Assets\Food\F102.jpg'),
('Mì quảng','Món nước','541','Sơ chế nguyên liệu-Nấu nước dùng và ướp gia vị-Làm nhân','Sợi mì Quảng, nhân tùy chọn (thịt, tôm, gà,...), rau sống, đậu phộng, bánh tráng','Đặc sản nổi tiếng miền Trung','9','\Assets\Food\F103.jpg'),
('Mì thịt heo','Món nước','415','Sơ chế nguyên liệu-Bắc nồi nước-Cho xương và thịt lợn cùng cần tây, gừng vào nồi, nêm gia vị rồi hầm khoảng 30p-Chần mì rồi cho vào tô-Chan nước dùng, xếp thịt heo lên trên','Xương heo, thịt heo, cần tây, gừng, hành khô, hành lá, mì tươi, giá đỗ','Món ăn nước phổ biến','9','\Assets\Food\F104.jpg'),
('Mì vịt tiềm','Món nước','776','Sơ chế thịt vịt-Nấu nước dùng-Hầm thịt vịt trong nước dùng-Sơ chế mì','Mì vắt, đùi vịt, rượu trắng, gừng, tỏi băm, xì dầu, nước tương, tiêu, hoa hồi, thanh quế, trần bì, hành tím, táo tàu, bạch quả, củ sen, nấm hương, dầu mè, hạt nêm, đường phèn, muối','Món ăn ngon nổi tiếng của người Hoa','9','\Assets\Food\F105.jpg'),
('Miến gà','Món nước','635','Sơ chế nguyên liệu-Ướp thịt gà-Nấu nước dùng','Gà, lòng gà, miến, hành tây, nấm mèo, hành lá, ngò rí, rau răm, hành tím, gia vị','Món ăn nước phổ biến','9','\Assets\Food\F106.jpg'),
('Phở bò chín','Món nước','456','Sơ chế nguyên liệu-Làm nước dùng','Phở, thịt bò, gầu bò, xương ống bò, củ cải trắng, hành tây, hành tím, gừng, trái thảo quả, thanh quế nhỏ, hoa hồi, hành lá, giá đỗ, rau thơm, gia vị','Món ăn nước phổ biến','9','\Assets\Food\F107.jpg'),
('Phở bò tái','Món nước','431','Sơ chế nguyên liệu-Làm nước dùng-Trụng phở và trần sơ thịt bò rồi vớt ra tô-Chan nước dùng','Phở, thịt bò, xương bò, hành tây, hành tím, gừng, hành hoa, rau mùi, gói gia vị nấu phở bò, gia vị khác','Món ăn nước phổ biến','9','\Assets\Food\F108.jpg'),
('Phở bò viên','Món nước','431','Sơ chế bò-Sơ chế nguyên liệu-Ninh nước dùng-Cắt thịt bò-Trụng phở','Phở, xương bò, thịt bò, gân bò, nạm bò, gầu bò, bò viên, hoa hồi, thảo quả, quế, gừng, hành tây, hành tím, rau ăn kèm, gia vị','Món ăn nước phổ biến','9','\Assets\Food\F109.jpg'),
('Phở gà','Món nước','483','Sơ chế nguyên liệu-Luộc gà và nấu nước dùng-Trụng phở','Phở, gà, giá đỗ, hành tây, sả, gừng, hành lá, ngò, ớt, chanh, gia vị','Món ăn nước phổ biến','9','\Assets\Food\F110.jpg');

insert into Food values 
('F301','Canh bắp cải','Canh','37','Nấu sôi nước-Cho rau đã cắt vào nồi-Chờ rau chín tắt bếp rồi nêm gia vị','Bắp cải','Một món canh đơn giản','8','\Assets\Food\F301.jpg'),
('F302','Canh bầu','Canh','30', 'Nấu sôi nước-Cho bầu đã cắt lát vào nồi-Chờ bầu chín tắt bếp rồi nêm gia vị','Bầu','Một món canh đơn giản','8','\Assets\Food\F302.jpg'),
('F303','Canh bí đao','Canh','29', 'Nấu sôi nước-Cho bí đao đã cắt lát vào nồi-Chờ bí đao chín tắt bếp rồi nêm gia vị','Bí đao','Một món canh đơn giản','8','\Food\F303.jpg'),
('F304','Canh bí đỏ','Canh','42', 'Nấu sôi nước-Cho bí đao đã cắt lát vào nồi-Chờ bí đỏ chín tắt bếp rồi nêm gia vị','Bí đỏ','Một món canh đơn giản','8','\Assets\Food\F304.jpg'),
('F305','Canh cải ngọt','Canh','30','Nấu sôi nước-Cho rau đã cắt vào nồi-Chờ rau chín tắt bếp rồi nêm gia vị','Cải ngọt','Một món canh đơn giản','8','\Assets\Food\F305.jpg'),
('F306','Canh chua','Canh','29', 'Nấu sôi nước-Cho nguyên liệu đã sơ chế vào nồi-Chờ nguyên liệu chín tắt bếp rồi nêm gia vị','Cà chua, dứa, giá','Món ăn đơn giản cho người thích vị chua','8','\Assets\Food\F306.jpg'),
('F307','Canh khoai mỡ','Canh','51','Cắt lát mỏng khoai mỡ-Phi hành-Xào khoai mỡ-Cho nước vào nồi khoai-Chờ chín nêm gia vị và tắt bếp','Khoai mỡ, củ hành','Canh có vị béo của khoai, nước dùng ngọt, đẹp mắt, mùi thơm hấp dẫn','8','\Assets\Food\F307.jpg'),
('F308','Canh mướp','Canh','31', 'Nấu sôi nước-Cho rau đã cắt vào nồi-Chờ rau chín tắt bếp rồi nêm gia vị','Mướp','Một món canh đơn giản','8','\Assets\Food\F308.jpg'),
('F309','Canh rau dền','Canh','22','Nấu sôi nước-Cho rau đã cắt vào nồi-Chờ rau chín tắt bếp rồi nêm gia vị','Rau dền','Một món canh đơn giản','8','\Assets\Food\F309\.jpg'),
('F310','Canh rau ngót','Canh','29', 'Nấu sôi nước-Cho rau đã cắt vào nồi-Chờ rau chín tắt bếp rồi nêm gia vị','Rau ngót','Một món canh đơn giản','8','\Assets\Food\F310.jpg');

insert into Food values 
('F401','Bia','Thức uống','141','','','Thức uống có cồn','8','\Assets\Food\F401.jpg'),
('F402','Cà phê sữa gói','Thức uống','85','','','Đồ uống pha sẵn','3','\Assets\Food\F402.jpg'),	
('F403','Cocktail trái cây','Thức uống','158','','','Đồ uống có cồn','8','\Assets\Food\F403.jpg'),
('F404','Nước cam vắt','Thức uống','226','','Cam','Nước trái cây','9','\Assets\Food\F404.jpg'),
('F405','Nước chanh','Thức uống','149','','Chanh','Nước trái cây','9','\Assets\Food\F405.jpg'),
('F406','Nước ép trái cây đóng hộp','Thức uống','74','','','Đồ uống sẵn','9','\Assets\Food\F406.jpg'),
('F407','Nước mía','Thức uống','106','','','Nước giải khát','8','\Assets\Food\F407.jpg'),
('F408','Nước ngọt có gas','Thức uống','146','','','Nước giải khát','8','\Assets\Food\F408.jpg'),
('F409','Nước sâm','Thức uống','74','','','Nước giải khát','8','\Assets\Food\F409.jpg'),
('F410','Sinh tố','Thức uống','277','','','Trái cây xay','9','\Assets\Food\F410.jpg');		

insert into Food values
('F001','Cơm rang thập cẩm','Cơm','800','Sơ chế rau củ, lạp xưởng-Đánh trứng-Xào nguyên liệu-Chiên cơm với lửa vừa','Cơm, lạp xưởng, trứng gà, đậu que, cà rốt, tỏi, gia vị','Cơm rang thập cẩm là món vô cùng dễ ăn và thu hút mọi người','12','\Assets\Food\F001.jpg'),
('F002','Cơm nắm rau củ','Cơm','150','Sơ chế rau củ, nấm hương-Xào nguyên liệu, nêm nếm vừa ăn-Vo cơm nắm','Gạo dẻo thơm, nấm hương, cà rốt, nước dùng gà, mè rang, tỏi băm, gừng, dầu mè','Cơm nắm là món ăn quen thuộc với nhiều người vì nó ngon và đầy đủ dưỡng chất.','12','\Assets\Food\F002.jpg'),
('F003','Dưa chuột cuộn cơm','Cơm','145','Dưa chuột, rau củ làm sạch, cá ngừ xé nhỏ-Cho gia vị vào cơm, trộn đều-Cuộn cơm','Dưa chuột, ớt chuông, hành tây, cá ngừ ngâm dầu, cơm, gia vị','Món dưa chuột cuộn cơm vừa ngon giòn, thanh mát lại lạ miệng','12','\Assets\Food\F003.jpg'),
('F004','Kiratanpo-Com nướng Nhật Bản','Cơm','140','Nấu sốt miso-Nghiền khoai tây trộn với cơm và bột bắp-Bọc cơm xung quanh đũa tre và nướng bằng chảo-Tưới sốt miso lên','Cơm trắng, bột bắp, thịt heo xay, tương miso, rượu, gia vị','Món ăn của xứ sở Hoa anh đào lạ miệng, lạ mắt','12','\Assets\Food\F004.jpg'),
('F005','Cơm nắm chua ngọt','Cơm','150','Thái nhỏ rau củ, xào với hạt nêm-Cho cơm và sốt cà chua vào trộn đều-Nắm cơm lại thành từng nắm','Cơm, hành tây, cà rốt, bí ngòi, sốt cà chua','Cơm nắm chua ngọt với cách chế biến đơn giản cùng vị chua ngọt lạ miệng thích hợp cho một bữa ăn bận rộn của bạn','12','\Assets\Food\F005.jpg'),
('F006','Trứng cuộn cơm','Cơm','400','Sơ chế nguyên liệu-Xào ức gà với rau củ-Thêm cơm và sốt cà chua-Trứng và sữa đánh đều, tráng mỏng-Cuộn với cơm','Hành tây, ức gà, rau củ các loại, cơm gạo dẻo, sốt cà chua, trứng, sữa, gia vị','Trứng cuộn cơm là món ngon dễ làm, đầy đủ dinh dưỡng, giúp đổi mới khẩu vị cho bữa cơm gia đình','12','\Assets\Food\F006.jpg'),
('F007','Cơm chiên kim chi','Cơm','300','Thái hạt lựu tất cả nguyên liệu-Trứng chiên mỏng-Phi hành thơm và đổ cơm trắng vào chảo-Nêm nếm đều gia vị-Thêm xúc xích lát mỏng, hành lá, xì dầu','Cơm trắng, xúc xích, hành tây, hành lá, kim chi, trứng gà, gia vị','Cơm chiên kimchi là món ăn không chỉ tận dụng được cơm còn dư mà còn mang hương bị ẩm thực của Hàn, vị chua cay đặc biệt','12','\Assets\Food\F007.jpg'),
('F008','Bánh rán từ cơm nguội','Cơm','341','Nhào bột thành hỗn hợp dẻo mịn-Chiên cơm với dầu ăn, sốt bò bằm-Chia bột, cán bột mỏng, cho cơm đã chiên vào giữa làm nhân-Ấn dẹt miếng bánh rồi chiên vàng hai mặt','Cơm nguội, bột mì đa dụng, nước ấm, gia vị','Món bánh rán từ cơm nguội ngon hấp dẫn mà cách thực hiện lại vô cùng đơn giản','12','\Assets\Food\F008.jpg'),
('F009','Cơm nắm cá ngừ đậu phụ chiên','Cơm','400','Sơ chế rau củ-Tán nhuyễn đậu phụ và cá ngừ-Trộn đều với cơm và gia vị-Nắm cơm lại vừa ăn','Cá ngừ đóng hộp, đậu phụ, cà rốt, hành lá, cơm, bột ngô, bột cà mì, vừng, gia vị','Món cơm nắm cá ngừ đậu phụ chiên này cực kỳ phù hợp cho ai bận rộn vì nó vừa đầy đủ dinh dưỡng vừa thơm ngon.','12','\Assets\Food\F009.jpg'),
('F010','Pizza cơm nguội','Cơm','370','Trộn trứng gà với cơm-Dàn mỏng cơm và chiên vàng hai mặt-Cho rau củ, phô mai lên trên cùng','Cơm nguội, trứng gà, bắp hạt, phô mai, ớt chuông, hành tây, giăm bông, nấm, sốt cà chua','Sự kết hợp giữa pizza phương Tây và cơm trắng của phương Đông sẽ là một món ăn thú vị đem lại cho bạn sự thích thú.','12','\Assets\Food\F010.jpg');

insert into Food values
('F201','Cá hồi sốt bơ tỏi chanh', 'Đồ biển', '208', 'Làm sạch cá, ướp đều gia vị-Áp chảo với bơ-Làm nước chấm với nước cốt chanh, cà phê,bột bấp, đường','Cá hồi phi lê, chanh, gừng thái sợi, tỏi băm, bơ thực vật, đường, tiêu, muối, bột bắp, nước tương','Cá hồi sốt bơ tỏi chanh thơm ngon, vị chua ngọt hấp dẫn, béo ngậy của bơ, thơm của gừng tỏi, thịt cá mềm không bở','9','\Assets\Food\F201.png'),
('F202','Cocktail tôm', 'Đồ biển', '252', 'Làm nước dùng với hành, tỏi băm, lá nguyệt quế, chanh, rượu trắng-Làm nước sốt với sốt cà chua, chanh, tương ớt-Luộc tôm bằng nước dùng đã chuẩn bị-Trình bày lên dĩa','Tôm, rượu trắng, hành tây, lá nguyệt quế, chanh, cà chua, tương ớt','Tôm là loại hải sản rất quen thuộc nhưng đem lại nhiều lợi ích cho sức khỏe. Đây là món hải sản tốt cho sức khỏe phổ biến ở Anh, Mỹ.','9','\Assets\Food\F202.jpg'),
('F203','Súp nghêu rau củ', 'Đồ biển', '126', 'Chiên thịt xông khói-Cho cà rốt, hành tây, cần tây, ớt chuông xanh xào đều-Thêm sốt cà chua và một ít nước luộc nghêu-Thêm khoai tây và nghêu vào','Cà rốt, hành tây, cần tây, ớt chuông xanh, sốt cà chua, nghêu, khoai tây','Không chỉ là món khai vị nổi tiếng với sự bổ dưỡng, thơm ngon, và màu sắc hấp dẫn, súp nghêu còn là món ngon hằng ngày trong các bữa cơm gia đình, đặc biệt là với trẻ nhỏ.','12','\Assets\Food\F203.jpg'),
('F204','Salad cá cơm','Đồ biển','131','Rửa sạch rau củ, thái nhỏ-Rửa sạch cá cơm, chiên giòn với bột-Trộn đều rau và cá với các loại nước sốt','Cá cơm, bột chiên giòn, xà lách xanh, cà chua, củ hành tây, dưa leo, mayonnaise, sữa chua, súp sữa đặc','Salad cá cơm còn là món ăn khá lạ với cách kết hợp độc đáo giữa cá cơm chiên giòn và món rau xà lách ngon mắt','12','\Assets\Food\F204.jpg'),
('F205','Bánh mì kẹp cá ngừ','Đồ biển','302','Sơ chế rau củ, luộc khoai tây, hấp trứng gà-Trộn cá ngừ với sốt và rau củ đã chuẩn bị-Kẹp vào bánh mì','Cá ngừ hộp, bánh mì, trứng, xa lách, cà chua bi, khoai tây, cà rốt, sốt mayonnaise, dầu ô liu, muối, giấm','Bánh mì kẹp cá ngừ cho bữa sáng nhanh gọn lẹ','3','\Assets\Food\F205.jpg'),
('F206','Hàu nướng mỡ hành','Đồ biển','198','Sơ chế nguyên liệu: Ngâm hàu và tách vỏ, rửa sạch và thái nhỏ rau thơm-Nướng hàu, quét mỡ hành liên tục đến khi hàu chín có mùi thơm','Hàu tươi sống, bơ lạt, đậu phọng rang, rau thơm, hành phi, gia vị','Hàu là món ăn được nhiều người yêu thích bơi thịt hàu thơm béo, chứa nhiều chất dinh dưỡng','9','\Assets\Food\F206.png'),
('F207','Cá trê nướng','Đồ biển','534','Sơ chế sạch cá-Ướp cá với gia vị vừa phải, thoa phần muối ớt lên da cá để thấm đều-Nướng cá bằng que hoặc vỉ nướng','Cá trê, muối, bột ngọt, ớt hiểm, muối hột','Loài cá da trơn này luôn là một món hải sản có lợi cho sức khỏe. Vì chiên rán sẽ thêm nhiều calo và chất béo vào món ăn. Vì vậy nướng chúng để trở thành món ăn lành mạnh','9','\Assets\Food\F207.jpg'),
('F208','Cá mòi','Đồ biển','250','Làm sạch nguyên liệu, để ráo nước-Dùng nồi kho,xếp muối vào đáy nồi, cho cá lên trên, tiếp đến là cà chua và sả, đổ nước xấp mặt cá-Cho nồi cá lên bếp và kho đến khi chín mềm','Cá mòi tươi, dưa muối, cà chua, sả, dầu ăn, gia vị','Với thành phần dinh dưỡng đa dạng với nhiều chất khoáng và vitamin, cá mòi kho là ứng cử viên sáng giá trong thực đơn của con người','9','\Assets\Food\F208.jpg'),
('F209','Gỏi hải sản tôm mực','Đồ biển','70','Bóc vỏ tôm, rửa sạch mực, thái nhỏ-Rửa sạch, sơ chế rau củ-Đem rau củ trộn đều với giấm đường-Làm nước trộn gỏi với nước mắm, đường, tương ớt, chanh-Trộn đều gỏi','Tôm, mực, hành tây, cà rốt, dưa chuột, gia vị','Vào mùa ngày nắng nóng, đĩa gỏi hài sản chắc chắn sẽ làm dịu đi cái nóng nhờ vào sự tươi mát ủa món ăn','9','\Assets\Food\F209.png'),
('F210','Cá trích kho dứa','Đồ biển','233','Sơ chế, làm sạch cá trích, dứa, rau củ-Chiên cá trích chín đều-Tiến hành kho cá trích với dứa, nêm nếm gia vị vừa ăn','Cá trích, dứa, tỏi, ớt hiểm, gia vị','Món cá trích kho tuy đơn giản nhưng mang lại cho bữa cơm gia định bạn nhiều hương vị đậm đà','9','\Assets\Food\F210.png');

insert into Food values
('F501','Đậu phộng da cá','Ăn vặt','161','Ngâm đậu phộng, trộn đều với gia vị và bột-Chiên đậu phộng đến khi vàng','Đậu phộng, bột mì, nước cốt dừa, gia vị','Đậu phộng da cá thơm lừng, giòn rụm, dễ làm','12','\Assets\Food\F501.jpg'),
('F502','Bánh mì ngào đường','Ăn vặt','300','Cắt bánh mì thành miếng nhỏ-Cho bánh mì vào chảo chiên vàng-Trộn với đường đã đun tan với nước','Bánh mì sandwich, đường, muối, dầu ăn','Chỉ với 20 phút bạn đã có một món ăn vặt cực kì dễ làm','12','\Assets\Food\F502.jpg'),
('F503','Snack chuối','Ăn vặt','425','Bóc vỏ, cắt chuối thành từng lát-Đun nóng dầu rồi cho vào chiên giòn','Chuối chín, muối, dầu ăn','Snack là món ăn ưa thích của trẻ em, nếu gia đình bạn có trẻ nhỏ thì hãy thử nhé','12','\Assets\Food\F503.jpg'),
('F504','Snack khoai tây','Ăn vặt','160','Khoai tây gọt vỏ, cắt lát-Trộn với một muỗng dầu ăn và chiên với nồi chiên không dầu','Khoai tây, muối, cà phê','Những món ăn vặt dễ làm tại nhà không thể thiếu snack khoai tây, dễ dàng bảo quản','12','\Assets\Food\F504.jpg'),
('F505','Bánh oreo cuộn kem sữa','Ăn vặt','453','Tách kem và vỏ bánh-Xay vỏ bánh với sữa tươi-Một phần kem vo tròn để vào tủ lạnh, một phần trộn bơ, sữa rồi đánh nhuyễn-Cho hỗn hợp bánh oreo vào màng bọc cán mỏng và cuộn lại-Bào mỏng kem oreo rắc lên mặt','Bánh oreo, socola, sữa tươi, bơ, đường bột','Vị đắng nhẹ kết hợp nhân béo mịn sẽ khiến bạn thích mê.','12','\Assets\Food\F505.jpg'),
('F506','Khoai tây chiên nước mắm','Ăn vặt','163','Khoai tây rửa sạch, gọt vỏ, cắt thanh nhỏ, ngâm với muối-Đun nóng dầu và chiên vàng-Trộn dầu ăn, nước mắm, đường và đun sôi-Lắc đều với khoai','Khoai, nước mắm, đường cát trắng, dầu ăn','Nếu bạn thích khoai tây thì có thể đổi món hằng ngày bằng khoai tây chiên nước mắm rất hấp dẫn.','12','\Assets\Food\F506.jpg'),
('F507','Bắp xào phô mai','Ăn vặt','436','Sơ chế nguyên liệu-Xào bắp, ớt chuông với bơ trộn với mayonnaise-Tiếp tục cho phô mai vào đun chảy','Bắp Mỹ, ớt chuông, mayonnaise, bơ lạt, phô mai','Bắp xào phô mai béo ngậy, thơm ngon mà bất kỳ ai cũng không cưỡng lại được.','12','\Assets\Food\F507.jpg'),
('F508','Thạch rau câu bắp','Ăn vặt','163','Chuẩn bị bột rau câu, xay bắp lọc lấy nước-Nấu sữa bắp để nguội-Đun sôi nước cốt dừa với sữa đặc-Đổ rau câu theo từng lớp cốt dừa và sữa bắp, để nguội','Đường, bột rau câu giòn, bắp Mỹ, nước cốt dừa, sữa đặc','Đây là một món ngon dễ làm bạn nên thử để trổ tài chiêu đãi cả nhà đấy','12','\Assets\Food\F508.jpg'),
('F509','Gan gà chiên xù','Ăn vặt','235','Sơ chế gan gà với muối và rượu-Ướp gia vị vừa ăn-Nhúng gan gà qua trứng và bột chiên xù rồi chiên giòn','Gan gà, bột mì, trứng gà, bột chiên xù, rượu trắng, gia vị','Miếng gà vàng ươm, giòn rụm sẽ kích thích vị giác của bạn đấy','12','\Assets\Food\F509.jpg'),
('F510','Trúng cút lộn sốt me','Ăn vặt','285','Mỡ heo rửa sạch, chiên lấy tóp mỡ-Luộc trứng cút, bóc vỏ-Lọc lấy nước me nêm nếm vừa ăn-Phi thơm tỏi rồi dun sôi sốt me và cho trứng cút vào','Trứng cút, me chín, mỡ heo, dưa leo, ớt sừng, tỏi, gia vị','Có thể ăn kèm rau răm, dưa leo, trứng cút sốt me sẽ làm bạn nghiện đấy nhé.','12','\Assets\Food\F510.jpg');