--T-SQL:�bSQL server�W���{���y��
--T-SQL���S�����j�p�g
print 'Hello World!'

select 'Hello World'
-----------------------
--�ܼ�
--1.�¶q�ܼ� 2.��ƪ��ܼ�
declare @myName varchar(50)='Jack'	--�ŧi
declare @number int 
set @myName='Jack Lin'--���w�B��nset��select
select @number=100
print @myName
print @number
----------------------------------
declare @salary money = 50000
print '�A���~����'+cast(@salary as varchar)	--�@�w�n�j���ഫ���A

declare @birthday  datetime = '2022/6-14'
print convert(varchar,@birthday,112)

select @birthday=�ͤ� from �ǥ�
where �Ǹ�='S002'
print convert(varchar,@birthday,112)
----------------------------------------
--��ƪ��ܼ�
declare @StuBirthday table(
	name varchar(30),
	birthday datetime
)
--�s�W�ǥ͸�ƪ��m�W�B�ͤ��@StuBirthday
insert into @StuBirthday
select �m�W,�ͤ� from �ǥ�

insert into @StuBirthday values('���ڦ�','2022-6/14'),('���ڦ�2','2022-6/15')
select * from @StuBirthday
