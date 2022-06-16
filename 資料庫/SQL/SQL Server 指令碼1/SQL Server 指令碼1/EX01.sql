use EX01
create table 學生(
學號 char(4) primary key,
姓名 varchar(12) not null,
性別 char(2),
電話 varchar(15),
生日 datetime,
)
create table 班級(
教授編號 char(4),
學號 char(4) ,
課程編號 char(5),
primary key(教授編號,學號,課程編號),
foreign key(學號) references 學生(學號) on delete no action on update no action
)
--insert into 學生(學號,姓名,性別,電話,生日)
--values
--('A001','安安','男','07-8136447','1996-7-5'),
--('A002','爆米香','男','07-8136447','1996-4-12'),
--('A003','咪路','男','07-8136447','1996-9-9')

--insert into 班級(教授編號,學號,課程編號)
--values
--('P123','A002','SB001'),
--('P123','A003','QQ111'),
--('P321','A001','SB001')
--('P321','A001','QQ111')


--update 班級
--set 學號='A004'
--where 學號='A001'

alter table 學生
alter COLUMN 學號2 char(4) constraint CK_StudentNo check(學號2 like '[AB][0-9][0-9][0-9]')

alter table 學生
add 學號2 char(4) constraint CK_StudentNo check(學號2 like '[AB][0-9][0-9][0-9]')


insert into 學生
values('A004','咪路222','男','07-8136447','1996-9-9','A123')
