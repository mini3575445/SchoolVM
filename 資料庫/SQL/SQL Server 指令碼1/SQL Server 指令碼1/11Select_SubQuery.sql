--------------�l�d��(SubQuery)�A���I�O�l�d�ߦA�]�l�d�߮e�����į���D

--�D�ءG�d"�i�L��"����Ҹ��
--�쥻�n�Ψ�Ӹ�ƪ�A����X�i�L�Ҫ��Ǹ��A�A��Z�Ÿ�ƪ�j�M
select * from �ǥ�
where �m�W='�i�L��'
select *from �Z��
where �Ǹ�='S003'
--SubQuery
select * from �Z��
where �Ǹ�=(select �Ǹ� from �ǥ�
where �m�W='�i�L��')

--�D�ءG�Ьd�߭��ǭ��u���~���j��������u�������~��
select *from ���u
where �~�� > (select avg(�~��) from ���u )

------------------�X�֬d�ߡA�į�|��l�d���٭n�n
--�D�ءG�d"�i�L��"����Ҹ��
select c.�Ǹ�,s.�m�W, c.�ҵ{�s�� from �Z�� as c inner join �ǥ� as s
on c.�Ǹ� = s.�Ǹ�
where �m�W='�i�L��'

--�D�ءG�Ьd�߭��ǭ��u���~���j��������u�������~��
--��k:�Φ۵M�X�֪��g�k���ۨ��X��
select a.�����Ҧr��,a.�m�W,a.�~�� from ���u as a ,���u as b
group by a.�����Ҧr��,a.�m�W,a.�~��
having a.�~��>avg(b.�~��)

------------------------------------------------------------
--�D��:���X����u�O�б�
--�l�d�߼g�k
select * from ���u
where �����Ҧr�� in (select �����Ҧr�� from �б�)
--(select �����Ҧr�� from �б�)��X�h��¾�ҥH�����"="

--�X�֬d�߼g�k
select * from ���u as e inner join �б� as p 
on e.�����Ҧr��=p.�����Ҧr��

--exists�l�y�ߥΪ��B��l(�\�๳�L�o��)
--�S�I�O�����S�a�g���
select * from ���u
where exists (select * from �б� where ���u.�����Ҧr��=�б�.�����Ҧr��)
--�D�ءG���ǾǥͿ�CS222�ҵ{
select * from �Z��
where �ҵ{�s�� in (Select �ҵ{�s�� from �ҵ{ where �ҵ{�s�� in ('CS222','CS111'))

--�D�ءG���ǽҵ{�b221-S�ЫǤW��
--in
select *from �ҵ{
where �ҵ{�s�� in (select �ҵ{�s�� from �Z�� where �Ы�='221-S')
--exists
select * from �ҵ{
where exists (select �ҵ{�s�� from �Z�� 
where �Ы�='221-S' and �ҵ{.�ҵ{�s��=�Z��.�ҵ{�s��)



--�D�ءG�d�߾ǥͩP�N���ҿ�Ҫ��ҵ{���
--�l�d��
--in(�@�w�n�������)
select * from �ҵ{
where �ҵ{�s�� in(select �ҵ{�s�� from �Z�� where �Ǹ� = (select �Ǹ� from �ǥ� where �m�W='�P�N��'))

--exists

--�D�ءG�P�N���S������@�ǽҵ{���
--�l�d��







--------------------------------------------------------------
--all�B��l
--��X�j���b�x�_�Ҧ����u�~�ꪺ���u
select * from ���u
where �~��>=all(
select �~�� from ���u
where ����='�x�_')

--some��any(T-SQL)�B��l
--��X�j���b�x�_���@���u�~�ꪺ���u