--group by ��ۦP���ȸs��
select �ʧO
from �ǥ�
group by �ʧO

select �ʧO
from �ǥ�
--�`�Pcount�@�_�ϥ�
select �ʧO
from �ǥ�
--�Ǹ������--count���E�X���
select �Ǹ�,count(*) as ��Ҧ���
from �Z�� 
group by �Ǹ�

select �б½s��,�ҵ{�s��,count(*) as �Ѯv�Q���
from �Z��
group by �б½s��,�ҵ{�s��	--�Ψ�E�X��Ƥγ�ȡA��ȥ�����bgroup by
-------------------------------------------------------------------------
--having(��where���\��@��)
--group by���l�y�A�����g�bgroup by�᭱
--having+�E�X���

select �Ǹ�,count(*) as ��Ҽ�
from �Z��
group by �Ǹ�
having count(*)<3

select �Ǹ�,count(*) as ��Ҽ�
from �Z��
group by �Ǹ�
having �Ǹ�='S005'

select �Ǹ�,count(*) as ��Ҽ�
from �Z��
where  �Ǹ�='S005'
group by �Ǹ�


select �Ǹ�,count(*) as ��Ҽ�
from �Z��
group by �Ǹ�
order by ��Ҽ� desc


--���g����
--select
--from
--where
--group by
--having
--order by

--���涶��
--from
--where
--group by
--having
--select
--order by




select ����,count(*)as ���u�H��
from ���u
group by ����

select *
from ���u
where ������