use EX01
create table �ǥ�(
�Ǹ� char(4) primary key,
�m�W varchar(12) not null,
�ʧO char(2),
�q�� varchar(15),
�ͤ� datetime,
)
create table �Z��(
�б½s�� char(4),
�Ǹ� char(4) ,
�ҵ{�s�� char(5),
primary key(�б½s��,�Ǹ�,�ҵ{�s��),
foreign key(�Ǹ�) references �ǥ�(�Ǹ�) on delete no action on update no action
)
--insert into �ǥ�(�Ǹ�,�m�W,�ʧO,�q��,�ͤ�)
--values
--('A001','�w�w','�k','07-8136447','1996-7-5'),
--('A002','�z�̭�','�k','07-8136447','1996-4-12'),
--('A003','�}��','�k','07-8136447','1996-9-9')

--insert into �Z��(�б½s��,�Ǹ�,�ҵ{�s��)
--values
--('P123','A002','SB001'),
--('P123','A003','QQ111'),
--('P321','A001','SB001')
--('P321','A001','QQ111')


--update �Z��
--set �Ǹ�='A004'
--where �Ǹ�='A001'

alter table �ǥ�
alter COLUMN �Ǹ�2 char(4) constraint CK_StudentNo check(�Ǹ�2 like '[AB][0-9][0-9][0-9]')

alter table �ǥ�
add �Ǹ�2 char(4) constraint CK_StudentNo check(�Ǹ�2 like '[AB][0-9][0-9][0-9]')


insert into �ǥ�
values('A004','�}��222','�k','07-8136447','1996-9-9','A123')
