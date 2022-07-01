--資料表值函數
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
--Table一定要透過from才能列印
select * from dbo.fnStudentCourseQuery()


--------------------------
--如果舊版沒有offset、fetch next就自己寫函數

