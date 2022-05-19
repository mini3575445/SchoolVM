select *
from Employees
where HireDate >='1993-01-01'

select *
from Orders
where ShipCity in ('Reims','Lander','Madrid')

select top 6 with ties UnitsInStock 
from Products
order by UnitsInStock desc

select OrderID,ProductID
from [Order Details]
where OrderID='10847'

select ProductID,COUNT(*)as �q��]�t���~��
from [Order Details]
group by ProductID
having COUNT(*)>=5

select CategoryID,avg(UnitPrice) as �������
from Products
group by CategoryID
having CategoryID=2

select *
from Products
where UnitsInStock + UnitsOnOrder < ReorderLevel 

select *
from Customers
where City in ('Montreal','Lisboa','Lyon','Stavern','Geneve','Bruxelles','Madrid')

select *
from [Order Details]
where Quantity >=20 and Quantity <=40

select *
from Orders
where ShippedDate is null

select *,UnitPrice*Quantity*(1-Discount) as �p�p 
from [Order Details]
where OrderID='10263'

select SupplierID,count(*) as ���ѴX�˲��~
from Products
group by SupplierID

select CustomerID,EmployeeID,count(*) as ���u�A�Ȧ���
from Orders
group by CustomerID,EmployeeID

select ProductID ,avg(UnitPrice) as ������� ,avg(Quantity) as �����P��ƶq
from [Order Details]
group by ProductID
having avg(Quantity) >10
order by ProductID