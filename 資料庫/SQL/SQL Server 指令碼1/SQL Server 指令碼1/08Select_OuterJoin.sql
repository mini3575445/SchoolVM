-------------outer join �~���X��
--�H�Y�@�誺��ƪ��D
select * from ���u
select * from �б�

select * from ���u as e left outer join �б� as p
on e.�����Ҧr��=p.�����Ҧr��

--�]�i�H�g��
select * from ���u as e left join �б� as p
on e.�����Ҧr��=p.�����Ҧr��

--�`�Ω�
--�ЦC�X���O�бª����u
select * 
from �б� as p right outer join ���u as e 
on p.�����Ҧr�� = e.�����Ҧr��
where p.�����Ҧr�� is null

--�ЦC�X�Ҧ��|����Ҫ��ǥ͸��
select *
from �ǥ� as s left outer join �Z�� as c
on s.�Ǹ� = c.�Ǹ�
where c.�Ǹ� is null

---------------full join 
select * 
from �ǥ� as s full join �Z�� as c 
on s.�Ǹ�=c.�Ǹ�

-------------��null�Ȫ��B�z�覡
select �m�W,Isnull(�q��,'�|����g') as �q�� from ���u