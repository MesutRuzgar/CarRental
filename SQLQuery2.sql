CREATE TABLE Cars(
CarId int PRIMARY KEY IDENTITY(1,1), 
BrandId int,
ColorId int,
ModelYear nvarchar(25),
DailyPrice decimal,
Descriptions nvarchar(250),
)

create table Brands(
BrandId int primary key identity(1,1),
BrandName nvarchar(50),
)


insert into Brands(BrandName) values ('Ford'),
('Renault'),('Mercedens-Benz'),('Nissan') 

create table Colors(
ColorId int primary key identity(1,1),
ColorName nvarchar(50),
)

insert into Colors(ColorName) values ('Beyaz'),('Siyah'),('Kırmızı'),('Gri')


insert into Cars(BrandId,ColorId,ModelYear,DailyPrice,Descriptions)
values (1,1,2010,100,'Focus'),
(1,2,2013,125,'Fiesta'),
(1,2,2015,160,'Egea'),
(2,1,2017,150,'Clio'),
(3,3,2020,600,'C180'),
(2,1,2019,200,'Megane'),
(4,4,2021,500,'Navara')
