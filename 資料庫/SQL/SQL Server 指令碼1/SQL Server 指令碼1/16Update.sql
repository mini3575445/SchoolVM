--update �ק�(��ĳwhere��PK�z��A���M�|���ۦP���󪺸��
update �ҵ{2
set �Ǥ�=2
where �ҵ{�s��='CS222'

--�Y��ҤH��>=3,�N�ҵ{�Ǥ��Ƨאּ30

--�l�d��
update �ҵ{2
set �Ǥ�=30
where �ҵ{�s�� in (select �ҵ{�s�� from �Z��
group by �ҵ{�s��
having count(*)>=3)

--�X�֬d��
update �ҵ{2
set �Ǥ�=100
select * from �ҵ{2 inner join �Z�� on �ҵ{2.�ҵ{�s��=�Z��.�ҵ{�s��
