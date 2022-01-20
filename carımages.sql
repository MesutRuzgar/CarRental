create table CarImages(
id int primary key identity(1,1),
CarId int foreign key references Cars(Id),
ImagePath nvarchar(100),
Date datetime,
)

