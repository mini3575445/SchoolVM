--outer join
select * from ���u

select * from �б�

select * from ���u as e left outer join �б� as p
on e.�����Ҧr��=p.�����Ҧr��

select * from ���u as e right outer join �б� as p
on e.�����Ҧr��=p.�����Ҧr��

select * from ���u as e left join �б� as p
on e.�����Ҧr��=p.�����Ҧr��


--�ЦC�X���O�бª����u
select e.* from ���u as e left outer join �б� as p
on e.�����Ҧr��=p.�����Ҧr��
where p.�б½s�� is null

----------------------------

select �Ǹ�,count(*) from �Z��
group by �Ǹ�

--�ЦC�X�Ҧ��|����Ҫ��ǥ͸��
select s.* 
from �ǥ� as s left join �Z�� as c 
on s.�Ǹ�=c.�Ǹ�
where c.�Ǹ� is null
-------------------------------------------------

--full join
select * 
from �ǥ� as s full join �Z�� as c 
on s.�Ǹ�=c.�Ǹ�


--��null�Ȫ��B�z�覡

select �����Ҧr��,�m�W,����,��D, ISNULL(�q��,'�|����g' ) as �q�� ,�~��,�O�I,���| from ���u




