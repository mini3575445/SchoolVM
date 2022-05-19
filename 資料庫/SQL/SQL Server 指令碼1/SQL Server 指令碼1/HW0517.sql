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

select ProductID,COUNT(*)as 訂單包含產品數
from [Order Details]
group by ProductID
having COUNT(*)>=5

select CategoryID,avg(UnitPrice) as 平均單價
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

select *,UnitPrice*Quantity*(1-Discount) as 小計 
from [Order Details]
where OrderID='10263'

select SupplierID,count(*) as 提供幾樣產品
from Products
group by SupplierID

select CustomerID,EmployeeID,count(*) as 員工服務次數
from Orders
group by CustomerID,EmployeeID

select ProductID ,avg(UnitPrice) as 平均單價 ,avg(Quantity) as 平均銷售數量
from [Order Details]
group by ProductID
having avg(Quantity) >10
order by ProductID