--��ƪ�Ȩ��
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
--Table�@�w�n�z�Lfrom�~��C�L
select * from dbo.fnStudentCourseQuery()


--------------------------
--�p�G�ª��S��offset�Bfetch next�N�ۤv�g���

