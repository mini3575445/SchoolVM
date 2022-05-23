--�ЧQ��Northwind��Ʈw�i��d��
--1.�C�X�q����өҦ����,����ܥX���W�~�����
select od.*,p.ProductName
from [Order Details] as od 
inner join Products as p on od.ProductID=p.ProductID


--2.�ӤW�D,�[�W�p�p���
select od.*,p.ProductName,od.UnitPrice*od.Quantity*(1-od.Discount) as �p�p
from [Order Details] as od 
inner join Products as p on od.ProductID=p.ProductID
where od.OrderID='10248'

--2.1�έp�C�@�Ӱӫ~�Q�R�L�X��
select top 10 with ties  od.ProductID,p.ProductName,count(*) as �R�L����
from [Order Details] as od inner join Products as p on od.ProductID=p.ProductID
group by od.ProductID,p.ProductName
order by �R�L���� desc

--3.�C�X�Ҧ��q����,�å[�W�U�ȦW�����
select o.*,c.CompanyName
from Orders as o inner join Customers as c
on o.CustomerID=c.CustomerID


--4.�έp�U���U�ȤU�L�X���q��
select o.CustomerID,c.CompanyName,c.ContactName,c.ContactTitle,count(*) as �U�榸��
from Orders as o inner join Customers as c
on o.CustomerID=c.CustomerID
group by o.CustomerID,c.CompanyName,c.ContactName,c.ContactTitle
order by �U�榸�� desc

--5.�έp�C����u�B�z�L�X���q��
select o.EmployeeID,e.LastName,e.FirstName,e.Title ,count(*) as ���u�B�z�q�浧��
from orders as o inner join Employees as e 
on o.EmployeeID=e.EmployeeID
group by o.EmployeeID,e.LastName,e.FirstName,e.Title
order by ���u�B�z�q�浧�� desc


--6.�έp�C�i�q�檺�`�B,�åѤj��p�Ƨ�
select od.OrderID,sum(od.UnitPrice*od.Quantity*(1-od.Discount)) as �q���`�B
from [Order Details] as od
group by od.OrderID


--6.1.�έp�C�i�q�檺�`�B,�åѤj��p�Ƨ�
select o.CustomerID, ROUND( sum(od.UnitPrice*od.Quantity*(1-od.Discount)),2 )as �Ȥ��`�~�Z
from [Order Details] as od inner join orders as o
on od.OrderID=o.OrderID
group by o.CustomerID
 

---------------------------
select o.CustomerID,c.CompanyName,c.ContactName,c.ContactTitle,
count(*) as �U�榸��,ROUND( sum(od.UnitPrice*od.Quantity*(1-od.Discount)),2 )as �Ȥ��`�~�Z
from Orders as o inner join Customers as c
on o.CustomerID=c.CustomerID
inner join [Order Details] as od on o.OrderID=od.OrderID
--where c.CustomerID='RATTC HUNGO'
group by o.CustomerID,c.CompanyName,c.ContactName,c.ContactTitle
order by �Ȥ��`�~�Z desc,�U�榸�� desc

--7.�ӤW�D,�[�W�Ȥ�W�١B���u�m�W�P�B�e�覡�����

select od.OrderID,c.CompanyName,e.FirstName,e.LastName,s.CompanyName as shipper,sum(od.UnitPrice*od.Quantity*(1-od.Discount)) as �q���`�B
from [Order Details] as od
inner join orders as o on od.OrderID=o.OrderID
inner join Customers as c on o.CustomerID=c.CustomerID
inner join Employees as e on o.EmployeeID=e.EmployeeID
inner join Shippers as s on o.ShipVia=s.ShipperID
group by od.OrderID,c.CompanyName,e.FirstName,e.LastName,s.CompanyName