create table Animals (
Id int not null identity(1,1) primary key,
Name NVARCHAR(50) not null,
Сlass NVARCHAR(50) not null,
Family NVARCHAR(50) ,
Population NVARCHAR(50),
Place NVARCHAR(250)) 

 drop table Animals

insert into Animals (Name, Сlass,Family, Population, Place )
values (N'шимпанзе', N'Mammal', N'приматы', N'140 тыс.', 
N'тропические леса и влажные саванны Западной и Центральной Африки' )

select * from Animals