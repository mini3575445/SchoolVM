--資料表值函數--
create function fnStudentCourseQuery()
	returns table
return 
	(select s.學號,s.姓名 as 學生姓名, s.性別,co.課程編號,co.名稱,co.學分,
	e.姓名 as 教授姓名,p.科系,c.教室,c.上課時間
	from 班級 as c 
	inner join 學生 as s on c.學號=s.學號 
	inner join 課程 as co on c.課程編號=co.課程編號
	inner join 教授 as p on c.教授編號=p.教授編號
	inner join 員工 as e on e.身份證字號=p.身份證字號)


select *
from dbo.fnStudentCourseQuery()

------------------------------------------
create function fnStudentCourseQuery2(@StuID char(4))
	returns table
return 
	(select s.學號,s.姓名 as 學生姓名, s.性別,co.課程編號,co.名稱,co.學分,
	e.姓名 as 教授姓名,p.科系,c.教室,c.上課時間
	from 班級 as c 
	inner join 學生 as s on c.學號=s.學號 
	inner join 課程 as co on c.課程編號=co.課程編號
	inner join 教授 as p on c.教授編號=p.教授編號
	inner join 員工 as e on e.身份證字號=p.身份證字號
	where s.學號=@StuID
	)


select *
from dbo.fnStudentCourseQuery2('S005')
-----------------------------------------------


select * 
from 員工
order by 身份證字號
offset 3 rows
fetch next 2 rows only
--------------------------

create function fnOffsetFetchNext(@m int, @n int)
	returns @result table(
		sn int identity,
		id char(10),
		[name] varchar(12),
		salary money
	)
begin

	insert into @result 
	select e.身份證字號,e.姓名,e.薪水
	from 員工 as e

	delete from  @result where sn<@m or sn>@n

	return

end



select * from dbo.fnOffsetFetchNext(4,6)



