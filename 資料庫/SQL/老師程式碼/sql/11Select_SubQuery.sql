--�l�d��(SubQuery)
--�d"�i�L��"����Ҹ��
select * from �Z��
where �Ǹ�=(select �Ǹ� from �ǥ�
where �m�W='�i�L��')

--�X�֬d��
select c.* from �Z�� as c inner join �ǥ� as s on c.�Ǹ�=s.�Ǹ�
where s.�m�W='�i�L��'

--�Ьd�߭��ǭ��u���~���j��������u�������~��
select * from ���u
where �~��>(select avg(�~��) from ���u)

--�X�֬d��
select e.�����Ҧr��,e.�m�W,e.�~�� from ���u as e , ���u as s
group by e.�����Ҧr��,e.�m�W,e.�~�� 
having e.�~��>avg(s.�~��)


--�d�߭��X����u�O�б�
--�Q�Τl�d�߼g�k
select * from ���u
where �����Ҧr�� in (select �����Ҧr�� from �б�)


--�Q�ΦX�֬d�߼g�k
select e.* from ���u as e inner join �б� as p
on e.�����Ҧr��=p.�����Ҧr��

--�l�y�ߥΪ��B��l
--exists
select * from ���u
where exists (select * from �б� where ���u.�����Ҧr��=�б�.�����Ҧr��)

--���ǾǥͿ�CS222�ҵ{
select * from �Z��
where �ҵ{�s��='CS222'

--exists
select * from �ǥ�
where exists (select * from �Z��
where �ҵ{�s��='CS222' and �ǥ�.�Ǹ�=�Z��.�Ǹ�)

--in
select * from �ǥ�
where �Ǹ� in (select �Ǹ� from �Z��
where �ҵ{�s��='CS222')


--���ǽҵ{�b221-S�ЫǤW��
--in
select * from �ҵ{
where �ҵ{�s�� in (select �ҵ{�s�� from �Z�� where �Ы�='221-S')

--exists
select * from �ҵ{
where exists (select �ҵ{�s�� from �Z�� where �Ы�='221-S' and �ҵ{.�ҵ{�s��=�Z��.�ҵ{�s��)


--�d�߾ǥͩP�N���ҿ�Ҫ��ҵ{���
--�l�d��
--in
select * from �ҵ{
where �ҵ{�s�� in (
select �ҵ{�s�� from �Z��
where �Ǹ�=(select �Ǹ� from �ǥ� where �m�W='�P�N��'))

--exists
select * from �ҵ{ as co
where exists
(select * from �Z�� as c
where exists(
select * from �ǥ� as s where �m�W='�P�N��' and c.�Ǹ�=s.�Ǹ� and co.�ҵ{�s��=c.�ҵ{�s��))


select co.* from �ҵ{ as co
inner join �Z�� as c on co.�ҵ{�s��=c.�ҵ{�s��
inner join �ǥ� as s on c.�Ǹ�=s.�Ǹ�
where s.�m�W='�P�N��'

--�d�߾ǥͩP�N���S���諸�ҵ{���
--�l�d��

-in
select * from �ҵ{
where �ҵ{�s�� not in (
select �ҵ{�s�� from �Z��
where �Ǹ�=(select �Ǹ� from �ǥ� where �m�W='�P�N��'))

--exists
select * from �ҵ{ as co
where not exists
(select * from �Z�� as c
where exists(
select * from �ǥ� as s where �m�W='�P�N��' and c.�Ǹ�=s.�Ǹ� and co.�ҵ{�s��=c.�ҵ{�s��))

--�X�֬d��
select * from �ҵ{
except
select co.* from �ҵ{ as co
inner join �Z�� as c on co.�ҵ{�s��=c.�ҵ{�s��
inner join �ǥ� as s on c.�Ǹ�=s.�Ǹ�
where s.�m�W='�P�N��'
---------------------------------------
--all
--��X�j���b�x�_�Ҧ����u�~�ꪺ���u

select * from ���u
where �~��>=all(
select �~�� from ���u
where ����='�x�_')


--some��any(T-SQL)
--��X�j���b�x�_���@���u�~�ꪺ���u

select * from ���u
where �~��>=some(
select �~�� from ���u
where ����='�x�_')

select * from ���u
where �~��>=any(
select �~�� from ���u
where ����='�x�_')


