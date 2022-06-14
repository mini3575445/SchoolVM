--T-SQL:在SQL server上的程式語言
--T-SQL中沒有分大小寫
print 'Hello World!'

select 'Hello World'
-----------------------
--變數
--1.純量變數 2.資料表變數
declare @myName varchar(50)='Jack'	--宣告
declare @number int 
set @myName='Jack Lin'--指定運算要set或select
select @number=100
print @myName
print @number
----------------------------------
declare @salary money = 50000
print '你的薪水為'+cast(@salary as varchar)	--一定要強制轉換型態

declare @birthday  datetime = '2022/6-14'
print convert(varchar,@birthday,112)

select @birthday=生日 from 學生
where 學號='S002'
print convert(varchar,@birthday,112)
----------------------------------------
--資料表變數
declare @StuBirthday table(
	name varchar(30),
	birthday datetime
)
--新增學生資料表的姓名、生日至@StuBirthday
insert into @StuBirthday
select 姓名,生日 from 學生

insert into @StuBirthday values('任我行','2022-6/14'),('任我行2','2022-6/15')
select * from @StuBirthday
