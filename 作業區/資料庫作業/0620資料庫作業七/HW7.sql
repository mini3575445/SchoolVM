--Q1
create database HW7
go

--Q2
use HW7
create table �ǥ�(
�ǥ� char(10) primary key,
�m�W nvarchar(20) not null,
�q�� varchar(20) not null,
�a�} nvarchar(100) not null,
�ͤ� datetime
)

create table �ҵ{(
�ҵ{�N�X char(6) primary key,
�ҵ{�W�� nvarchar(30) not null,
�Ǥ��� int default 3
)


--Q3
use HW7
create table �q��(
�q��N�� char(10) primary key,
�q���� datetime not null
)
create table ���~(
���~�s�� char(6) primary key,
���~�W�� nvarchar(50) not null
)

create table �q�����(
�q��N�� char(10),
���~�s�� char(6),
�ʶR�ƶq int not null
primary key(�q��N��,���~�s��),
foreign key(�q��N��) references �q��(�q��N��) on delete no action on update no action,
foreign key(���~�s��) references ���~(���~�s��) on delete no action on update no action
)
