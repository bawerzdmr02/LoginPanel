create database UserData;
GO
use UserData
create table Users(

id int primary key identity(1,1),
TCKimlik char(11) not null,
Sifre nvarchar(64) not null

)