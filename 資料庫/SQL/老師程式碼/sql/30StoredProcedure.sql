--預存程序Stored Procedure
--建立 學生選課明細 預存程序,命名為CourseDetails
create proc CourseDetails
as
begin
	SELECT          學生.姓名, 學生.學號, 課程.名稱, 員工.姓名 AS 教授姓名
	FROM              員工 INNER JOIN
                            教授 ON 員工.身份證字號 = 教授.身份證字號 INNER JOIN
                            班級 ON 教授.教授編號 = 班級.教授編號 INNER JOIN
                            課程 ON 班級.課程編號 = 課程.課程編號 INNER JOIN
                            學生 ON 班級.學號 = 學生.學號

end
--------------------------------------------------------

--執行預存程序
exec CourseDetails


---------------------------------------
create proc drawStar
as
begin
	declare @i int=1, @star varchar(max)=''

	while @i<=50
	begin
		set @star+='*'
		print @star
		set @i+=1
	end

end

-----------------------------
exec drawStar
-----------------------------

--有參數的預存程序
create proc drawStar2
	@c int
as
begin
	declare @i int=1, @star varchar(max)=''

	while @i<=@c
	begin
		set @star+='*'
		print @star
		set @i+=1
	end
end
-----------------------------
exec drawStar2 10  --寫法一
exec drawStar2 @c=10  --寫法二
-----------------------------


create proc employeeDataRow
	@i int, @j int
as
begin
	select * 
	from 員工
	order by 身份證字號
	offset @i rows
	fetch next @j rows only
end


------------------------
exec employeeDataRow 2,3

exec employeeDataRow @j=2,@i=3
-----------------------



