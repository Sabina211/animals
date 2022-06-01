create table Mammals (
Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT newid(),
Name NVARCHAR(50) not null,
Family NVARCHAR(50) ,
Population NVARCHAR(50),
Place NVARCHAR(250)) 

create table Amphibians (
Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT newid(),
Name NVARCHAR(50) not null,
Family NVARCHAR(50) ,
Population NVARCHAR(50),
Place NVARCHAR(250)) 

create table Birds (
Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT newid(),
Name NVARCHAR(50) not null,
Family NVARCHAR(50) ,
Population NVARCHAR(50),
Place NVARCHAR(250)) 

insert into "Mammals" (Name, Family, Population, Place )
values (N'карликовый лемур Лавасоа ',  N'приматы', N'около 50, на грани вымирания', 
N'Мадагаскар' )

insert into "Mammals" (Name, Family, Population, Place )
values (N'человек разумный',  N'приматы, гоминиды', N'более 7 млрд', 
N'практически вся Земля' )

insert into "Mammals" (Name, Family, Population, Place )
values (N'шимпанзе', N'приматы', N'140 тыс.', 
N'тропические леса и влажные саванны Западной и Центральной Африки' )

insert into Birds (Name, Family, Population, Place )
values (N'сизый голубь', N'голубеобразные', N'около 5 млн', 
N'центральные и южные районы Евразии от Атлантики до долины Енисея, горного Алтая, Тянь-Шаня, восточной Индии и Мьянмы, а также Африку севернее Сенегала, 
Дарфура и побережья Аденского залива' )

insert into Amphibians (Name, Family, Population, Place )
values (N'огненная саламандра', N'хвостатые земноводные', N'нет данных', 
N'леса и холмистые местности Европы, Ближнего Востока' )

select * from Amphibians union 
select * from Birds union 
select * from "Mammals"  




drop table "Mammals"

select * from Mammals

alter table Animals drop column Сlass

sp_rename "Mammal", "Mammals"