--�ЧQ��Northwind��Ʈw�i��d��
--1.�C�X�q���U�L�q�檺�Ȥ���
select c.*
from Customers as c left outer join Orders as o 
on c.CustomerID = o.CustomerID
where o.CustomerID is null

--2.�C�X�q���B�z�L�q�檺���u���
select e.*
from Employees as e left outer join Orders as o 
on e.EmployeeID = o.EmployeeID
where o.EmployeeID is null

--3.�C�X�q���Q�ʶR���ӫ~���
select p.*
from Products as p left join [Order Details] as od
on p.ProductID=od.ProductID
where od.ProductID is null

--��null�Ȫ��B�z�覡
--�έp�C��Region���X�ӫȤ�
select isnull(Region,'N/A'),count(*) from Customers
group by Region
