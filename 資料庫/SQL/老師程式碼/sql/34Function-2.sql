--��ƪ�Ȩ��--
create function fnStudentCourseQuery()
	returns table
return 
	(select s.�Ǹ�,s.�m�W as �ǥͩm�W, s.�ʧO,co.�ҵ{�s��,co.�W��,co.�Ǥ�,
	e.�m�W as �б©m�W,p.��t,c.�Ы�,c.�W�Үɶ�
	from �Z�� as c 
	inner join �ǥ� as s on c.�Ǹ�=s.�Ǹ� 
	inner join �ҵ{ as co on c.�ҵ{�s��=co.�ҵ{�s��
	inner join �б� as p on c.�б½s��=p.�б½s��
	inner join ���u as e on e.�����Ҧr��=p.�����Ҧr��)


select *
from dbo.fnStudentCourseQuery()

------------------------------------------
create function fnStudentCourseQuery2(@StuID char(4))
	returns table
return 
	(select s.�Ǹ�,s.�m�W as �ǥͩm�W, s.�ʧO,co.�ҵ{�s��,co.�W��,co.�Ǥ�,
	e.�m�W as �б©m�W,p.��t,c.�Ы�,c.�W�Үɶ�
	from �Z�� as c 
	inner join �ǥ� as s on c.�Ǹ�=s.�Ǹ� 
	inner join �ҵ{ as co on c.�ҵ{�s��=co.�ҵ{�s��
	inner join �б� as p on c.�б½s��=p.�б½s��
	inner join ���u as e on e.�����Ҧr��=p.�����Ҧr��
	where s.�Ǹ�=@StuID
	)


select *
from dbo.fnStudentCourseQuery2('S005')
-----------------------------------------------


select * 
from ���u
order by �����Ҧr��
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
	select e.�����Ҧr��,e.�m�W,e.�~��
	from ���u as e

	delete from  @result where sn<@m or sn>@n

	return

end



select * from dbo.fnOffsetFetchNext(4,6)



