--exists
--�D��:�d���u�O�б�
select * from ���u
where exists(select * from �б� where ���u.�����Ҧr�� = �б�.�����Ҧr��)
--���ǾǥͿ�CS222�ҵ{
select * from �ǥ� where exists
(select * from �Z�� where exists
(select * from �ҵ{ where �Ǥ� = 4 and �Z��.�ҵ{�s��=�ҵ{.�ҵ{�s�� and �ǥ�.�Ǹ�=�Z��.�Ǹ�) )

--���ǽҵ{�b221-S�ЫǤW��
--in
select * from �ҵ{
where �ҵ{�s�� in (select �ҵ{�s�� from �Z�� where �Ы�='221-S')
--exists
select * from �ҵ{
where exists (select * from �Z�� where �Ы�='221-S' and �ҵ{.�ҵ{�s��=�Z��.�ҵ{�s��)

----�P�N�ۦ�����@�ǽҵ{
--in
select * from �ҵ{ where �ҵ{�s�� in
(select �ҵ{�s�� from �Z�� where �Ǹ� =
(select �Ǹ� from �ǥ� where �m�W='�P�N��'))

--exists
select * from �ҵ{ where exists(
select * from �Z�� where exists(
select * from �ǥ� where �m�W='�P�N��' and �Z��.�Ǹ�=�ǥ�.�Ǹ� and �ҵ{.�ҵ{�s��=�Z��.�ҵ{�s��))

--�X�֬d��
select �ҵ{.* from �ҵ{ inner join (�ǥ� inner join �Z�� on �ǥ�.�Ǹ�=�Z��.�Ǹ�) on �ҵ{.�ҵ{�s��=�Z��.�ҵ{�s��
where �m�W='�P�N��'


----�P�N�ۨS������@�ǽҵ{
--in
select * from �ҵ{ where �ҵ{�s�� not in
(select �ҵ{�s�� from �Z�� where �Ǹ� =
(select �Ǹ� from �ǥ� where �m�W='�P�N��'))
--exists
select * from �ҵ{ where not exists(
select * from �Z�� where exists(
select * from �ǥ� where �m�W='�P�N��' and �Z��.�Ǹ�=�ǥ�.�Ǹ� and �ҵ{.�ҵ{�s��=�Z��.�ҵ{�s��))
--�X�֬d
select �ҵ{.* from �ҵ{ inner join (�ǥ� inner join �Z�� on �ǥ�.�Ǹ�=�Z��.�Ǹ�) on �ҵ{.�ҵ{�s��=�Z��.�ҵ{�s��
where �m�W='�P�N��'

--------------------------------
--all
--��X�j���b�x�_�Ҧ����u�~�ꪺ���u
select * from ���u
where �~�� >=all (select �~�� from ���u where ����='�x�_')
--some
select * from ���u
where �~�� >=some (select �~�� from ���u where ����='�x�_')




