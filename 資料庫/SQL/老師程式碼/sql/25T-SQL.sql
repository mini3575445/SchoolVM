--T-SQL

print 'Hello World!'

select 'Hello World!'
--------------------------
--�ܼ�
--1.�¶q�ܼ�  2.��ƪ��ܼ�
--�¶q�ܼ�  
declare @myName varchar(50) ='Jack'
declare @number int 
set @number=100
select @myName='Jack Lin'
print @myName
print @NUMBER
-------------------------
declare @salary money =50000
print '�A���~����'+ cast(@salary as varchar) 

declare @birthday datetime ='2022/6-14'
print convert(varchar ,@birthday,112)

select @birthday=�ͤ� from �ǥ�
where �Ǹ�='S002'

print convert(varchar ,@birthday,112)
----------------------------------------
--��ƪ��ܼ�
declare @StuBirthday table(
	name nvarchar(30),
	birthday datetime
)

insert into @StuBirthday
select �m�W,�ͤ� from �ǥ�

insert into @StuBirthday values('���ڦ�','2022-6/14'),
('���ڦ�2','2022-6/14'),
('���ڦ�3','2022-6/14'),
('���ڦ�4','2022-6/14')


select * from @StuBirthday
