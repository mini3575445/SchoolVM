--where ����z��(SQL�r���'')
select *
from �ǥ�
where �ʧO='�k'

select *
from �ǥ�
where �Ǹ�='S002'

select *
from ���u
where �~��>=50000

select *
from �ǥ�
where �ͤ�>='1991/1/1'

--��X�ǥ͸�Ƥ�����g�ͤ骺�H
select *
from �ǥ�
where �ͤ� is null	--��null�n�S�O�ϥ�is null

--like �ҽk�d��(�@�w�n�t�X�ҽk�B��A�S�μҽk�B�⪺�ܬ۷��"=")
--%:�N��0~n�ӥ��N�r��
--_:�N��1�ӥ��N�r��
select *
from �ǥ�
where �m�W like '��%'

select *
from �б�
where ��t like 'c_s'

--[��]�t�A�������r]:��c or ��k...
select *
from �б�
where ��t like '%[cklj]%'	

--[��S���]�t�A�������r]:��c or ��k...
select *
from �б�
where ��t like '%[^cklj]%'	

--[��S���]�t�A�������r]:��c or ��k...
select *
from �б�
where ��t like '%[A-DW-Z0-5]%'	
--�W����U���@��
select *
from �б�
where ��t like '%[ABCDWXYZ012345]%'	
----------------------------------------------
--between...and...�B��
select * 
from ���u
where �~�� >= 25000 and �~��<=55000
--�W����U���@��
select * 
from ���u
where �~�� between 25000 and 55000

--in �B��
select *
from �ҵ{
where �ҵ{�s�� ='CS101' or �ҵ{�s�� ='CS213'or
�ҵ{�s�� ='CS349'or �ҵ{�s�� ='CS999'

select *
from �ҵ{
where �ҵ{�s�� in ('CS101','CS213','CS349','CS999')