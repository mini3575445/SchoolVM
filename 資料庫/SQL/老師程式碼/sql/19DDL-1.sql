--SQL
--DML,DDL
--DDL-Create,Alter,Drop

create database School
go

use School
go

--�p�����
create table Students(
	StuId char(4) primary key,
	StuName nvarchar(20) not null,
	StuGender bit not null,
	Tel varchar(20),
	Birthday datetime,
	Age as datediff(year,Birthday,getdate())--�p�����
)

create table Course(
	CourseID char(5) primary key,
	CourseName nvarchar(30) not null,
	Credit tinyint not null
)
--default��
create table Employee(
	ID char(10) primary key,
	EmpName nvarchar(20) not null,
	City nvarchar(5) not null,
	Street nvarchar(30) not null,
	Tel varchar(20),
	Salary money  default 26500, --�w�]�����
	Insurance money not null,
	tax as Salary*0.05,  --�p�����
	pay as Salary-Insurance-Salary*0.05  --�p�����
)

--identity�ߤ@�ѧO��(�۷��Access���۰ʽs��)
create table Professors(
	--SN bigint identity,  --�]�y����,�q1�}�l,�C���[1,����bigint�̤j��
	SN bigint identity(100,10),--�q100�}�l,�C���[10
	ProfessorID char(4) primary key,
	JobTitle nvarchar(10) not null,
	Department nvarchar(10) not null,
	ID char(10) not null
)