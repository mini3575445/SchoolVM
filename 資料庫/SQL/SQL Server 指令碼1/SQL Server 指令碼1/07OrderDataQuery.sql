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
select top 10 with ties  od.ProductID,p.ProductName,count(*) as �R�L����
from [Order Details] as od inner join Products as p on od.ProductID=p.ProductID
group by od.ProductID,p.ProductName
order by �R�L���� desc

--3.�C�X�q����өҦ����,�å[�W�U�ȦW�����
select o.*,c. CompanyName
from Orders as o inner join Customers as c 
on o.CustomerID = c.CustomerID

--4.�έp�U���U�ȤU�L�X���q��
select o.customerID,s.CompanyName , count(*) as �U�榸��
from Orders as o inner join Customers as s
on o.CustomerID = s.CustomerID
group by o.customerID,s.CompanyName
order by count(*) desc
--5.�έp�C����u�B�z�L�X���q��

--**6.�έp�C�i�q�檺�`�B,�åѤp��j�Ƨ�
select OrderID,sum(UnitPrice*Quantity*(1-Discount)) as �q���`�B
from [Order Details] as od 
group by OrderID
order by sum(UnitPrice*Quantity*(1-Discount))
--group by��@�E�X��ƪ�����I

--6.1�έp�C�ӫȤ᪺�q���`�B�A�åѤj��p�Ƨ�
select c.ContactName,sum(UnitPrice*Quantity*(1-Discount)) as �Ȥ��`�~�Z
from [Order Details] as od 
inner join orders as o on od.OrderID = o.OrderID
inner join Customers as c on c.CustomerID = o.CustomerID
group by c.ContactName
order by sum(UnitPrice*Quantity*(1-Discount)) desc


--7.�ӤW�D�A�[�W�Ȥ�W�١B���u�m�W�P�B�e�覡�����
select od.OrderID,c.CompanyName,e.FirstName,e.LastName,s.CompanyName as shipper,sum(od.UnitPrice*od.Quantity*(1-od.Discount)) as �q���`�B
from [Order Details] as od
inner join orders as o on od.OrderID=o.OrderID
inner join Customers as c on o.CustomerID=c.CustomerID
inner join Employees as e on o.EmployeeID=e.EmployeeID
inner join Shippers as s on o.ShipVia=s.ShipperID
group by od.OrderID,c.CompanyName,e.FirstName,e.LastName,s.CompanyName


