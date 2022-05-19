--請利用Northwind資料庫進行查詢
--1.列出訂單明細所有資料,並顯示出產名品稱欄位
select od.*,ProductName
from [Order Details] as od 
inner join Products as p on od.ProductID=p.ProductID

--2.承上題,加上小計欄位
select od.*,ProductName,od.UnitPrice*od.Quantity*(1-od.Discount) as 小計
from [Order Details] as od 
inner join Products as p on od.ProductID=p.ProductID

--2.1統計每一個商品被買過幾次
select 
from 