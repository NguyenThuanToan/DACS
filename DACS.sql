Use DACS
go


Create table Category 
(
	IdCategory int primary key,
	NameCategory nvarchar(50)not null,
)
go
Create table Product 
(
	IdCategory int,
	IdProduct int primary key,
	NameProduct nvarchar(200)not null,
	DescriptionProduct nvarchar(MAX) null,
	QuantityOfProduct int null,
	Price float,
	StatusProduct bit not null,
	ImageProduct nvarchar(200)null,
	manufacturedate date null,
	expiry date null,
	ImageBrand nvarchar(200)null,
	FOREIGN KEY (IdCategory) REFERENCES Category(IdCategory),
)
go
create table Orders(
	OrderNo	int primary key,
	CustomerId	nvarchar(128),
	OrderDate	date,
	DeliveryDate	date,
	isComplete		bit,--nvarchar(50)
	isPaid			bit,--nvarchar(50)
	id	nvarchar(128),
	FOREIGN KEY (id) REFERENCES AspNetUsers(id),
)
go
create table OrderDetail(
	OrderNo int,
	IdProduct int,
	Price float,
	Quantity int,
	manufacturedate date null,
	expiry date null,
	NameProduct nvarchar(200)not null,
	Primary key(OrderNo,IdProduct),
	FOREIGN KEY (OrderNo) REFERENCES Orders(OrderNo),
	FOREIGN KEY (IdProduct) REFERENCES Product(IdProduct),
)
go
create table Position(
	IdPos	int primary key,
	Position	nvarchar(100)not null,
	wage	float,
)
create table Employee(
	IdPos	int,
	idNv int primary key,
	EmployeeName	nvarchar(256)not null,
	NumberPhone		char(13)not null,
	Sex		bit,
	imageEmployee	nvarchar(200)null,
	FOREIGN KEY (IdPos) REFERENCES Position(IdPos),
)
create table task(
	IdPos	int,
	idNv int,
	process bit,
	dateofduty datetime,
	TaskDetails	nvarchar(MAX),
	EmployeeName	nvarchar(256)not null,
	FOREIGN KEY (IdPos) REFERENCES Position(IdPos),
	FOREIGN KEY (idNv) REFERENCES Employee(idNv),
)
insert into Position values('1',N'Nhân viên thu ngân',5000000)
insert into Position values('2',N'Nhân viên lao công',5000000)
insert into Position values('3',N'Nhân viên bảo vệ',5000000)
insert into Position values('4',N'Nhân viên tiếp thị tổng',6000000)
insert into Position values('5',N'Quản lý',10000000)
insert into Position values('6',N'Nhân viên vận chuyển',5000000)
insert into Position values('7',N'Nhân viên tiếp thị thực phẩm chuyên dùng',6000000)
insert into Position values('8',N'Nhân viên tiếp thị thực phẩm đóng hộp và khô',6000000)
insert into Position values('9',N'Nhân viên tiếp thị bộ quà tặng',6000000)
insert into Position values('10',N'Nhân viên tiếp thị đồ uống',6000000)
insert into Position values('11',N'Nhân viên tiếp thị gia vị và chế biến',6000000)
insert into Position values('12',N'Nhân viên tiếp thị đồ ăn vặt',6000000)
insert into Position values('13',N'Nhân viên tiếp thị các loại dụng cụ chuyên dùng',6000000)
insert into Position values('14',N'Nhân viên tiếp thị trái cây',6000000)
insert into Position values('15',N'Nhân viên tiếp thị rau củ',6000000)

select * from task

insert into task values('3','007',1,'20230306',N'Trực ở cổng A',N'NiNi')
insert into task values('6','012',1,'20230306',N'Giao hàng cho chị A',N'Minh')
insert into task values('11','003',1,'20230306',N'Trực ở quầy tiếp thị gia vị và chế biến',N'Kim')




insert into Employee values('1','001',N'Hằng','092342523',0,N'nv.jpg')
insert into Employee values('1','002',N'Như','092332523',0,N'nv.jpg')
insert into Employee values('2','004',N'Kim Ánh','052342523',0,N'nv.jpg')
insert into Employee values('2','006',N'Tài','152342523',1,N'nv.jpg')
insert into Employee values('3','010',N'NiNi','052334523',0,N'nv.jpg')
insert into Employee values('4','009',N'Đức','032342523',1,N'nv.jpg')
insert into Employee values('5','011',N'Toàn','052332523',1,N'nv.jpg')
insert into Employee values('6','012',N'Minh','052312523',1,N'nv.jpg')
insert into Employee values('7','013',N'Tâm','012332523',0,N'nv.jpg')
insert into Employee values('8','017',N'Tấm','012332523',0,N'nv.jpg')
insert into Employee values('9','016',N'Tân','012332523',0,N'nv.jpg')
insert into Employee values('10','014',N'Vy','092332523',0,N'nv.jpg')
insert into Employee values('11','003',N'Kim','052342523',0,N'nv.jpg')
insert into Employee values('12','005',N'Nhật Ánh','052342523',0,N'nv.jpg')
insert into Employee values('12','007',N'Mimi','052332523',0,N'nv.jpg')
insert into Employee values('13','015',N'Thực','052334523',1,N'nv.jpg')
insert into Employee values('14','008',N'Đức Anh','032342523',1,N'nv.jpg')




select * from Employee

insert into Product values('5','1',N'Tỏi','10000đ/1kg Ăn vào hôi nách',1000,10000,1,N'toi.png',null,null,null)
insert into Product values('5','2',N'Hành lá','2000đ/1kg',1000,2000,1,N'Hanhla.jpg',null,null,null)
insert into Product values('5','3',N'Cà rốt','15000đ/1kg',1000,15000,1,N'carot.jpg',null,null,null)
insert into Product values('5','4',N'Hành tím','2000đ/1kg',1000,2000,1,N'hanhtim.jpg',null,null,null)
insert into Product values('5','5',N'Cà chua','17000đ/1kg',1000,17000,1,N'cachua.jpg',null,null,null)
insert into Product values('5','6',N'Ớt xanh','5000đ/1kg',1000,5000,1,N'otxanh.jpg',null,null,null)
insert into Product values('5','7',N'Rau muốn','10000đ/1kg',1000,10000,1,N'RAUMUONG.jpg',null,null,null)
insert into Product values('5','8',N'Ớt đỏ','5000đ/1kg',1000,5000,1,N'ot.jpg',null,null,null)
insert into Product values('5','9',N'Củ cải trắng','25000đ/1kg',1000,25000,1,N'Cucaitrang.jpg',null,null,null)
insert into Product values('5','10',N'Dưa leo','5000đ/1kg',1000,5000,1,N'dualeo.jpg',null,null,null)
insert into Product values('5','11',N'Nấm kim châm','25000đ/1kg',1000,25000,1,N'kimcham.jpg',null,null,null)
insert into Product values('5','12',N'Nấm mèo','25000đ/1kg',1000,25000,1,N'nammeo.jpg',null,null,null)
insert into Product values('5','13',N'Nấm rơm','25000đ/1kg',1000,25000,1,N'nammeo.jpg',null,null,null)
insert into Product values('5','14',N'Xà lách','30000đ/1kg',1000,30000,1,N'salad.jpg',null,null,null)
insert into Product values('5','15',N'Cà tím','15000đ/1kg',1000,15000,1,N'catim.jpg',null,null,null)
insert into Product values('1','16',N'Thịt heo','55000đ/1kg',1000,55000,1,N'thitheo.jpg','20230506','20230606','brandmeat.png')
insert into Product values('1','17',N'Giò heo','135000đ/1kg',1000,135000,1,N'Gioheo.jpg','20230506','20230606','brandmeat.png')
insert into Product values('1','18',N'Thịt ba rọi heo','200000đ/1kg',1000,200000,1,N'baroiheo.jpg','20230506','20230606','brandmeat.png')
insert into Product values('1','19',N'Thịt đùi heo','155000đ/1kg',1000,155000,1,N'thitduiheo.jpg','20230506','20230606','brandmeat.png')
insert into Product values('1','20',N'Ức gà','80000đ/1kg',1000,80000,1,N'ucga.jpg',null,null,'brandmeat2.png')
insert into Product values('1','21',N'Cánh gà','55000đ/1kg',1000,55000,1,N'ucga.jpg',null,null,'brandmeat2.png')
insert into Product values('1','22',N'Đùi gà','100000đ/1kg',1000,100000,1,N'duiga.jpg',null,null,'brandmeat2.png')
insert into Product values('1','23',N'Gà nguyên con','300000đ/1kg',1000,300000,1,N'ga.jpg',null,null,'brandmeat2.png')
insert into Product values('1','24',N'Trứng gà','25000đ/1kg',1000,25000,1,N'trungga.jpg',null,null,'brandmeat2.png')
insert into Product values('1','25',N'Trứng vịt','28000đ/1kg',1000,28000,1,N'trungvit.jpg',null,null,'brandmeat3.png')
insert into Product values('4','26',N'Rượu Soju Việt quất','59000đ/1kg',1000,59000,1,N'sojuvietquat.jpg','20230306','20240506',null)
insert into Product values('4','27',N'Rượu Soju Kiwi','59000đ/1kg',1000,59000,1,N'sojukiwi.jpg','20230306','20240506',null)
insert into Product values('4','28',N'Rượu Soju Cherry','59000đ/1kg',1000,59000,1,N'sojucherry.jpg','20230306','20240506',null)
insert into Product values('4','29',N'Rượu Soju Đào','59000đ/1kg',1000,59000,1,N'sojudao.jpg','20230306','20240506',null)
insert into Product values('4','30',N'Rượu Soju Truyền Thống','59000đ/1kg',1000,59000,1,N'sojutruyenthong.jpg','20230306','20240506',null)
insert into Product values('2','31',N'Pate heo','49000đ/1kg',1000,49000,1,N'pateheo.jpg','20230306','20250306',null)
insert into Product values('2','32',N'Pate Bò','59000đ/1kg',1000,59000,1,N'patebo.jpg','20230306','20250306',null)
insert into Product values('2','33',N'Pate gan gà tây','29000đ/1kg',1000,29000,1,N'pategatay.jpg','20230306','20250306',null)
insert into Product values('2','34',N'Lạp xưởng','175000đ/1kg',1000,175000,1,N'lapxuong.jpg','20230306','20250306',null)
insert into Product values('2','35',N'Lạp xưởng cá thác lác','110000đ/1kg',1000,110000,1,N'lapxuongca.jpg','20230306','20250306',null)
insert into Product values('6','36',N'Bánh Mochi','70000đ/1kg',1000,70000,1,N'banhmochi.jpg','20230306','20230806',null)
insert into Product values('6','37',N'Bánh phô mai gery','35000đ/1kg',1000,35000,1,N'banhphomai.jpg','20230306','20230806',null)
insert into Product values('6','38',N'Bánh quy sữa Merry','40000đ/1kg',1000,40000,1,N'banhmerry.jpg','20230306','20230806',null)
insert into Product values('6','39',N'Bánh pía đài loan','80000đ/1kg',1000,80000,1,N'banhpiadailoan.jpg','20230306','20230806',null)
insert into Product values('6','40',N'Chà bông gà','80000đ/1kg',1000,80000,1,N'chabongga.jpg','20230206','20230806',null)
insert into Product values('7','41',N'Dĩa nhựa','29000đ/1kg',1000,29000,1,N'dianhua.jpg',null,null,null)
insert into Product values('7','42',N'Dĩa sứ','40000đ/1kg',1000,40000,1,N'diasu.jpg',null,null,null)
insert into Product values('7','43',N'Ống đựng đũa','80000đ/1kg',1000,80000,1,N'ongdua.jpg',null,null,null)
insert into Product values('7','44',N'Vá canh nhựa','42000đ/1kg',1000,42000,1,N'vacanh.jpg',null,null,null)
insert into Product values('7','45',N'kệ 4 tầng','179000đ/1kg',1000,179000,1,N'ke4tang.jpg',null,null,null)
insert into Product values('3','46',N'Hộp quà tặng sức khỏe Yến sào','1.200000đ/1kg',1000,179000,1,N'hqsk.jpg','20230206','20231006',null)
insert into Product values('3','47',N'Trà nõn tôm - hộp quà tặng 500g','600000đ/1kg',1000,600000,1,N'hqtranom.jpg','20230206','20231006',null)
insert into Product values('3','48',N'Mứt tết lục giác 200g','85000đ/1kg',1000,85000,1,N'hqmut2g.jpg','20230206','20231006',null)
insert into Product values('3','49',N'Mứt tết lục giác 300g','150000đ/1kg',1000,120000,1,N'hqmut3g.jpg','20230206','20231006',null)
insert into Product values('8','50',N'Trái cam','15000đ/1kg',1000,15000,1,N'cam.jpg',null,null,null)
insert into Product values('8','51',N'Trái nho','16000đ/1kg',1000,16000,1,N'nho.jpg',null,null,null)
insert into Product values('8','52',N'Trái dâu','16000đ/1kg',1000,16000,1,N'dau.jpg',null,null,null)
insert into Product values('8','52',N'Trái thơm','18000đ/1kg',1000,16000,1,N'thom.jpg',null,null,null)

select * from Product


select * from Category



insert into Category values('1',N'Thực phẩm chuyên dùng')
insert into Category values('2',N'Thực phẩm đóng hộp và khô')
insert into Category values('3',N'Bộ quà tặng')
insert into Category values('4',N'Đồ uống')
insert into Category values('5',N'Gia vị và chế biến')
insert into Category values('6',N'Đồ ăn vặt')
insert into Category values('7',N'Các loại dụng cụ chuyên dùng')
insert into Category values('8',N'Trái cây')
insert into Category values('9',N'Rau củ')

select *
from Product p,Category c
where p.IdCategory = c.IdCategory and p.IdCategory='1'

select *
from Product p,Category c
where p.IdCategory = c.IdCategory and p.IdCategory='5'

select *
from Product

select IdCategory, count(IdProduct) as dem from Product group by IdCategory