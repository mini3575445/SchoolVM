--�X�֬d��
--inner join �����X�֬d��
select s.�Ǹ�,s.�m�W, s.�ʧO,co.�ҵ{�s��,co.�W��,co.�Ǥ�,
e.�m�W,p.��t,c.�Ы�,c.�W�Үɶ�
from �Z�� as c 
inner join �ǥ� as s on c.�Ǹ�=s.�Ǹ� 
inner join �ҵ{ as co on c.�ҵ{�s��=co.�ҵ{�s��
inner join �б� as p on c.�б½s��=p.�б½s��
inner join ���u as e on e.�����Ҧr��=p.�����Ҧr��

select s.�Ǹ�,s.�m�W,count(*)
from �Z�� as c 
inner join �ǥ� as s on c.�Ǹ�=s.�Ǹ� 
group by s.�Ǹ�,s.�m�W

select e.�m�W,co.�ҵ{�s��,co.�W��,co.�Ǥ�,count(*)
from �Z�� as c 
inner join �ҵ{ as co on c.�ҵ{�s��=co.�ҵ{�s��
inner join �б� as p on c.�б½s��=p.�б½s��
inner join ���u as e on e.�����Ҧr��=p.�����Ҧr��
group by e.�m�W,co.�ҵ{�s��,co.�W��,co.�Ǥ�

-------------------------------------------------------
--inner join ���ĤG�ؼg�k

select s.�Ǹ�,s.�m�W, s.�ʧO,co.�ҵ{�s��,co.�W��,co.�Ǥ�,
e.�m�W,p.��t,c.�Ы�,c.�W�Үɶ�
from ���u as e 
inner join (�б� as p inner join 
(�ҵ{ as co inner join 
(�Z�� as c inner join �ǥ� as s on c.�Ǹ�=s.�Ǹ�) 
on c.�ҵ{�s��=co.�ҵ{�s��) 
on p.�б½s��=c.�б½s��) 
on e.�����Ҧr��=p.�����Ҧr��
---------------------------------------
--�ĤT�ؼg�k(�۵M(���t)�X�֪k)

select s.�Ǹ�,s.�m�W, s.�ʧO,co.�ҵ{�s��,co.�W��,co.�Ǥ�,
e.�m�W,p.��t,c.�Ы�,c.�W�Үɶ�
from �Z�� as c ,�ǥ� as s, �ҵ{ as  co,�б� as p,���u as e 
where  c.�Ǹ�=s.�Ǹ� and c.�ҵ{�s��=co.�ҵ{�s�� 
and c.�б½s��=p.�б½s�� and e.�����Ҧr��=p.�����Ҧr��




