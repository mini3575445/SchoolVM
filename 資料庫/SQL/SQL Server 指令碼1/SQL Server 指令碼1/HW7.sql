--Q1
create database HW7
go

--Q2
use HW7
create table 學生(
學生 char(10) primary key,
姓名 nvarchar(20) not null,
電話 varchar(20) not null,
地址 nvarchar(100) not null,
生日 datetime
)

create table 課程(
課程代碼 char(6) primary key,
課程名稱 nvarchar(30) not null,
學分數 int default 3
)


--Q3
use HW7
create table 訂單(
訂單代號 char(10) primary key,
訂單日期 datetime not null
)
create table 產品(
產品編號 char(6) primary key,
產品名稱 nvarchar(50) not null
)

create table 訂單明細(
訂單代號 char(10),
產品編號 char(6),
購買數量 int not null
primary key(訂單代號,產品編號),
foreign key(訂單代號) references 訂單(訂單代號) on delete no action on update no action,
foreign key(產品編號) references 產品(產品編號) on delete no action on update no action
)
