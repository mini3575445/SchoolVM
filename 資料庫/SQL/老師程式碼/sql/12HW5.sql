--1
select *
from Employees
where city='London'

--2
select *
from Employees
where HireDate>='1993-1/1'

--3
select *
from orders
where ShipCity in ('Reims','Lander','Madrid')
--where ShipCity='Reims' or shipcity='Lander' or  shipcity='Madrid'

--4
select top 6 with ties *
from Products
order by UnitsInStock desc

--5
select ProductID
from [Order Details]
where OrderID='10847'


--6
select OrderID
from [Order Details]
group by OrderID
having count(*)>=5

--7
select CategoryID,avg(UnitPrice)
from Products
--where CategoryID=2
group by CategoryID
having  CategoryID=2

--8
select *
from Products
where UnitsInStock<ReorderLevel and UnitsOnOrder=0


--9
select *
from Customers
where city in ('Montreal','Lisboa','Lyon','Stavern','Geneve','Bruxelles','Madrid')

--10
select *
from [Order Details]
where Quantity between 20 and 40


--11
select *
from Orders
where ShippedDate is null


--12
select *,UnitPrice*Quantity*(1-Discount)
from [Order Details]
where OrderID='10263'


--13
select SupplierID,count(*)
from Products
group by SupplierID


--14
select CustomerID,EmployeeID,count(*)
from orders
group by  CustomerID,EmployeeID


--15

select ProductID, avg(UnitPrice),avg(Quantity)
from [Order Details]
group by ProductID
having avg(Quantity)>10
order by ProductID
