--先練習Excel樞紐分析表
--pivot	(select進階寫法)

--1.分好列欄值
--2.先寫子查詢(才能用pivot運算子)
--3.pivot裡面寫統計值


select * from --2.子查詢
--1.	列  ,  欄  ,  值
(select 學號,課程編號,教室 from 班級) as x


pivot --3.這個表沒有統計值
(
--教室屬於哪一個課程，所以用FOR
max(教室)
for 課程編號 in	--[]表示為物件，不是字串
([CS101],[CS213],[CS349],[CS222],[CS203],[CS111],[CS121],[CS205])	--這裡是欄的標題
) as pvt




--4.NULL改為---(要在select才能用isNull)
select 學號,isnull([CS101],'---')as[CS101],isnull([CS213],'---')as[CS213],isnull([CS349],'---')as[CS349]
,isnull([CS222],'---')as[CS222],isnull([CS203],'---')as[CS203],isnull([CS111],'---')as[CS111]
,isnull([CS121],'---')as[CS121],isnull([CS205],'---')as[CS205]from
(select 學號,課程編號,教室 from 班級) as x 
pivot
(
max(教室)
for 課程編號 in 
(
[CS101],[CS213],[CS349],[CS222],[CS203],[CS111],[CS121],[CS205])--下一步把這裡寫成活的 
)as pvt
go



--5.
declare @in_colunms nvarchar(max)
declare @sql nvarchar(max)

--***處理字串的逗點
--ISNULL(不為空的話顯示,空的話顯示)
select @in_colunms = ISNULL(@in_colunms+',['+課程編號+']','['+課程編號+']')
from (select 課程編號 from 課程) as a
print @in_colunms

set @sql=
'select *
from(select 學號,課程編號,教室 from 班級) as x 
pivot
(
max(教室)
for 課程編號 in 
('+@in_colunms+')
)as pvt'

exec(@sql)
--exec可以執行字串
--EX:exec ('select * from 學生')


--6.
Create proc getCoursePivot
as
begin
	declare @in_columns nvarchar(max)
	declare @sql nvarchar(max)
	select @in_columns=isnull(@in_columns+',['+課程編號+']','['+課程編號+']')
	from 
	(select 課程編號 from 課程) as a
	print @in_columns

	declare @select_columns nvarchar(max)=''
	select @select_columns+=',isnull(['+課程編號+'],''---'') as ['+課程編號+']'
	from 
	(select 課程編號 from 課程) as b
	order by 課程編號
	print @select_columns

	set @sql=
	'select 學號'+@select_columns+'
	from (select 學號,課程編號,教室 from 班級) as x
	pivot
	(
		max(教室)
		for 課程編號 in
		('+@in_columns+' )
	) as pvt'

	exec(@sql)
end