--SQL
--DML,DDL
--DDL-Create,Alter,Drop

create database School
go

use School
go

--計算欄位
create table Students(
	StuId char(4) primary key,
	StuName nvarchar(20) not null,
	StuGender bit not null,
	Tel varchar(20),
	Birthday datetime,
	Age as datediff(year,Birthday,getdate())--計算欄位
)

create table Course(
	CourseID char(5) primary key,
	CourseName nvarchar(30) not null,
	Credit tinyint not null
)
--default值
create table Employee(
	ID char(10) primary key,
	EmpName nvarchar(20) not null,
	City nvarchar(5) not null,
	Street nvarchar(30) not null,
	Tel varchar(20),
	Salary money  default 26500, --預設值欄位
	Insurance money not null,
	tax as Salary*0.05,  --計算欄位
	pay as Salary-Insurance-Salary*0.05  --計算欄位
)

--identity唯一識別值(相當於Access的自動編號)
create table Professors(
	--SN bigint identity,  --跑流水號,從1開始,每次加1,直到bigint最大值
	SN bigint identity(100,10),--從100開始,每次加10
	ProfessorID char(4) primary key,
	JobTitle nvarchar(10) not null,
	Department nvarchar(10) not null,
	ID char(10) not null
)