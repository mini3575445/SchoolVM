--�w�s�{��Stored Procedure
--�إ� �ǥͿ�ҩ��� �w�s�{��,�R�W��CourseDetails
create proc CourseDetails
as
begin
	SELECT          �ǥ�.�m�W, �ǥ�.�Ǹ�, �ҵ{.�W��, ���u.�m�W AS �б©m�W
	FROM              ���u INNER JOIN
                            �б� ON ���u.�����Ҧr�� = �б�.�����Ҧr�� INNER JOIN
                            �Z�� ON �б�.�б½s�� = �Z��.�б½s�� INNER JOIN
                            �ҵ{ ON �Z��.�ҵ{�s�� = �ҵ{.�ҵ{�s�� INNER JOIN
                            �ǥ� ON �Z��.�Ǹ� = �ǥ�.�Ǹ�

end
--------------------------------------------------------

--����w�s�{��
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

--���Ѽƪ��w�s�{��
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
exec drawStar2 10  --�g�k�@
exec drawStar2 @c=10  --�g�k�G
-----------------------------


create proc employeeDataRow
	@i int, @j int
as
begin
	select * 
	from ���u
	order by �����Ҧr��
	offset @i rows
	fetch next @j rows only
end


------------------------
exec employeeDataRow 2,3

exec employeeDataRow @j=2,@i=3
-----------------------



