--T-SQL

print 'Hello World!'

select 'Hello World!'
--------------------------
--變數
--1.純量變數  2.資料表變數
--純量變數  
declare @myName varchar(50) ='Jack'
declare @number int 
set @number=100
select @myName='Jack Lin'
print @myName
print @NUMBER
-------------------------
declare @salary money =50000
print '你的薪水為'+ cast(@salary as varchar) 

declare @birthday datetime ='2022/6-14'
print convert(varchar ,@birthday,112)

select @birthday=生日 from 學生
where 學號='S002'

print convert(varchar ,@birthday,112)
----------------------------------------
--資料表變數
declare @StuBirthday table(
	name nvarchar(30),
	birthday datetime
)

insert into @StuBirthday
select 姓名,生日 from 學生

insert into @StuBirthday values('任我行','2022-6/14'),
('任我行2','2022-6/14'),
('任我行3','2022-6/14'),
('任我行4','2022-6/14')


select * from @StuBirthday
