--�X�֬d��
--inner join �����X�֬d��
--��Z�Ÿ�ƪ��ǥ͸�ƪ�X��--PK�PFK���p

select s.�Ǹ�,s.�m�W,s.�ʧO,co.�ҵ{�s��,co.�W��,co.�Ǥ�,
e.�m�W,p.��t,c.�Ы�,c.�W�Үɶ�
from �Z�� as c 
inner join �ǥ� as s  on c.�Ǹ�=s.�Ǹ�
inner join �ҵ{ as co on c.�ҵ{�s��=co.�ҵ{�s��
inner join �б� as p on c.�б½s��=p.�б½s��
inner join ���u as e on e.�����Ҧr��=p.�����Ҧr��
--�Z�ų��OFK�A��ƪ�٬�����
--��L��ƪ�٬��D��

select s.�Ǹ�,s.�m�W,count(*)as ��Ҽ�
from �Z�� as c 
inner join �ǥ� as s on c.�Ǹ�=s.�Ǹ� 
group by s.�Ǹ�,s.�m�W

select e.�m�W,co.�ҵ{�s��,co.�W��,co.�Ǥ�,count(*)
from �Z�� as c 
inner join �ҵ{ as co on c.�ҵ{�s��=co.�ҵ{�s��
inner join �б� as p on c.�б½s��=p.�б½s��
inner join ���u as e on e.�����Ҧr��=p.�����Ҧr��
group by e.�m�W,co.�ҵ{�s��,co.�W��,co.�Ǥ�

--�d�б� �дX�ӽҵ{
select p.�б½s��,c.�ҵ{�s��,count(*) as �½Ҽƶq
from �б� as p
inner join �Z�� as c on p.�б½s��=c.�б½s��
group by p.�б½s��,c.�ҵ{�s��
------------------------------------------------------------
--inner join ���ĤG�ؼg�k
select s.�Ǹ�,s.�m�W,s.�ʧO,co.�ҵ{�s��,co.�W��,co.�Ǥ�,
e.�m�W,p.��t,c.�Ы�,c.�W�Үɶ�
from �ҵ{ as co 
ineer join (�Z�� as c 
inner join �ǥ� as s 
on c.�Ǹ�=s.�Ǹ�) 
on c.�ҵ{�s��=co.�ҵ{�s��
-------------------------------------------------------------
--�ĤT�ؼg�k(�۵M(���t)�X�֪k)
--�����p�g������(and�s��)