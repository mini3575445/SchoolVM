--請利用Northwind資料庫進行查詢
--1.列出訂單明細所有資料,並顯示出產名品稱欄位
select od.*,p.ProductName
from [Order Details] as od 
inner join Products as p on od.ProductID=p.ProductID


--2.承上題,加上小計欄位
select od.*,p.ProductName,od.UnitPrice*od.Quantity*(1-od.Discount) as 小計
from [Order Details] as od 
inner join Products as p on od.ProductID=p.ProductID
where od.OrderID='10248'

--2.1統計每一個商品被買過幾次
select top 10 with ties  od.ProductID,p.ProductName,count(*) as 買過次數
from [Order Details] as od inner join Products as p on od.ProductID=p.ProductID
group by od.ProductID,p.ProductName
order by 買過次數 desc

--3.列出所有訂單資料,並加上顧客名稱欄位
select o.*,c.CompanyName
from Orders as o inner join Customers as c
on o.CustomerID=c.CustomerID


--4.統計各個顧客下過幾次訂單
select o.CustomerID,c.CompanyName,c.ContactName,c.ContactTitle,count(*) as 下單次數
from Orders as o inner join Customers as c
on o.CustomerID=c.CustomerID
group by o.CustomerID,c.CompanyName,c.ContactName,c.ContactTitle
order by 下單次數 desc

--5.統計每位員工處理過幾筆訂單
select o.EmployeeID,e.LastName,e.FirstName,e.Title ,count(*) as 員工處理訂單筆數
from orders as o inner join Employees as e 
on o.EmployeeID=e.EmployeeID
group by o.EmployeeID,e.LastName,e.FirstName,e.Title
order by 員工處理訂單筆數 desc


--6.統計每張訂單的總額,並由大到小排序
select od.OrderID,sum(od.UnitPrice*od.Quantity*(1-od.Discount)) as 訂單總額
from [Order Details] as od
group by od.OrderID


--6.1.統計每張訂單的總額,並由大到小排序
select o.CustomerID, ROUND( sum(od.UnitPrice*od.Quantity*(1-od.Discount)),2 )as 客戶總業績
from [Order Details] as od inner join orders as o
on od.OrderID=o.OrderID
group by o.CustomerID
 

---------------------------
select o.CustomerID,c.CompanyName,c.ContactName,c.ContactTitle,
count(*) as 下單次數,ROUND( sum(od.UnitPrice*od.Quantity*(1-od.Discount)),2 )as 客戶總業績
from Orders as o inner join Customers as c
on o.CustomerID=c.CustomerID
inner join [Order Details] as od on o.OrderID=od.OrderID
--where c.CustomerID='RATTC HUNGO'
group by o.CustomerID,c.CompanyName,c.ContactName,c.ContactTitle
order by 客戶總業績 desc,下單次數 desc

--7.承上題,加上客戶名稱、員工姓名與運送方式等欄位

select od.OrderID,c.CompanyName,e.FirstName,e.LastName,s.CompanyName as shipper,sum(od.UnitPrice*od.Quantity*(1-od.Discount)) as 訂單總額
from [Order Details] as od
inner join orders as o on od.OrderID=o.OrderID
inner join Customers as c on o.CustomerID=c.CustomerID
inner join Employees as e on o.EmployeeID=e.EmployeeID
inner join Shippers as s on o.ShipVia=s.ShipperID
group by od.OrderID,c.CompanyName,e.FirstName,e.LastName,s.CompanyName