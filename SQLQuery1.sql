create table Users(
Id int primary key IDENTITY(1,1),
FirstName nvarchar(25),
LastName nvarchar(25),
Email nvarchar(60),
Password int,
)

create table Customers(
Id int primary key identity(1,1),
UserId int foreign key references Users(Id),
CompanyName nvarchar(60),
)

create table Rentals(
Id int primary key identity(1,1),
CarId int foreign key references Cars(Id),
CustomerId int foreign key references Customers(Id),
RentDate datetime ,
ReturnDate datetime ,
)
create table Colors(
Id int primary key identity(1,1),
ColorName nvarchar(25),
)

Create table Brands(
Id int primary key identity(1,1),
BrandName nvarchar(25),
)



