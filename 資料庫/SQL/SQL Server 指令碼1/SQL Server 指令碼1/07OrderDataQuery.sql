--�ЧQ��Northwind��Ʈw�i��d��
--1.�C�X�q����өҦ����,����ܥX���W�~�����
select od.*,ProductName
from [Order Details] as od 
inner join Products as p on od.ProductID=p.ProductID

--2.�ӤW�D,�[�W�p�p���
select od.*,ProductName,od.UnitPrice*od.Quantity*(1-od.Discount) as �p�p
from [Order Details] as od 
inner join Products as p on od.ProductID=p.ProductID

--2.1�έp�C�@�Ӱӫ~�Q�R�L�X��
select 
from 