--1.請試寫一合併查詢，查詢出訂購日期落在1996年7月並指定送貨公司為「United Package」的有訂單之訂貨明細資料，並列出訂單號碼、產品類別名稱、產品名稱、產品訂購單價、產品訂購數量、產品價錢小計、客戶編號、客戶名稱、收貨人名字、訂購日期、處理訂單員工的姓名、送貨方式、供應商名稱等資料項目，其中產品價錢小計請以四捨五入計算至整數位。
select o.OrderID, cate.CategoryName, p.ProductName , od.UnitPrice , od.Quantity , round(od.UnitPrice*od.Quantity*(1-od.Discount),0) as 產品價錢小計  ,
cust.CustomerID , cust.CompanyName , cust.ContactName , o.OrderDate , e.LastName , e.FirstName , Ship.CompanyName as 送貨方式 , sup.CompanyName as 供應商名稱
from Orders as o 
inner join [Order Details] as od on o.OrderID=od.OrderID
inner join Products as p on p.ProductID=od.ProductID
inner join Categories as cate on cate.CategoryID=p.CategoryID
inner join Customers as cust on cust.CustomerID=o.CustomerID
inner join Employees as e on e.EmployeeID=o.EmployeeID
inner join Shippers as Ship on Ship.ShipperID = o.ShipVia
inner join Suppliers as sup on sup.SupplierID=p.SupplierID
where OrderDate >= '1996/07/01' and OrderDate <= '1996/07/31' and Ship.CompanyName='United Package'


--2.請試寫一合併查詢，查詢客戶ANTON歷年來所訂購的所有產品，並統計出各種產品的訂購數量，輸出如下結果。
select c.CustomerID , c.ContactName , p.ProductName , od.Quantity from Products as p
inner join [Order Details] as od on od.ProductID=p.ProductID
inner join Orders as o on o.OrderID=od.OrderID
inner join Customers as c on c.CustomerID=o.CustomerID
where c.CustomerID='ANTON'

--3. 請利用exists運算子配合子查詢式，找出哪些客戶從未下過訂單，並列出客戶的所有欄位。(不可用到in運算，亦不可用合併查詢式) 
select * from Customers
where not exists (select * from Orders where Customers.CustomerID = Orders.CustomerID ) 

--4. 請利用in運算子配合子查詢式，查詢哪些員工有處理過訂單，並列出員工的員工編號、姓名、職稱、內部分機號碼
--、附註欄位。(不可用到exists運算，亦不可用合併查詢式) 
select EmployeeID,LastName,FirstName,Title,Extension,Notes from Employees
where EmployeeID in (select EmployeeID from Orders )

--5. 請合併查詢與子查詢兩種寫法，列出1998年度所有被訂購過的產品資料，並列出產品的所有欄位，且依產品編號由小
--到大排序。(寫合併查詢時不得用任何子查詢式，寫子查詢時不得用任何合併查詢式)
--合併查詢
select distinct p.* from Products as p
inner join [Order Details] as od on p.ProductID=od.ProductID
inner join Orders as o on od.OrderID = o.OrderID
where o.OrderDate >='1998/1/1' and o.OrderDate<='1998/12/31'
--子查詢
select * from Products 
where ProductID in(select ProductID from [Order Details] 
where OrderID in (select OrderID from Orders where OrderDate>='1998/1/1'and OrderDate<='1998/12/31'))
order by ProductID

