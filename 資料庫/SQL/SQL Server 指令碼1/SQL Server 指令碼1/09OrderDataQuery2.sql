--請利用Northwind資料庫進行查詢
--1.列出從未下過訂單的客戶資料
select c.*
from Customers as c left outer join Orders as o 
on c.CustomerID = o.CustomerID
where o.CustomerID is null

--2.列出從未處理過訂單的員工資料
select e.*
from Employees as e left outer join Orders as o 
on e.EmployeeID = o.EmployeeID
where o.EmployeeID is null

--3.列出從未被購買的商品資料
select p.*
from Products as p left join [Order Details] as od
on p.ProductID=od.ProductID
where od.ProductID is null

--對null值的處理方式
--統計每個Region有幾個客戶
select isnull(Region,'N/A'),count(*) from Customers
group by Region
