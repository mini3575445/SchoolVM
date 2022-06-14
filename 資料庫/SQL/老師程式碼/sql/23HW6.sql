--1
SELECT          Orders.OrderID, Categories.CategoryName, Products.ProductName, [Order Details].UnitPrice, [Order Details].Quantity, 
			  round([Order Details].Quantity*[Order Details].UnitPrice*(1-[Order Details].Discount),0)
                            Customers.CustomerID, Customers.CompanyName, Orders.ShipName,orders.OrderDate,Employees.FirstName+Employees.LastName,
							Shippers.CompanyName,Suppliers.CompanyName
FROM              [Order Details] INNER JOIN
                            Orders ON [Order Details].OrderID = Orders.OrderID INNER JOIN
                            Products ON [Order Details].ProductID = Products.ProductID INNER JOIN
                            Customers ON Orders.CustomerID = Customers.CustomerID INNER JOIN
                            Employees ON Orders.EmployeeID = Employees.EmployeeID INNER JOIN
                            Suppliers ON Products.SupplierID = Suppliers.SupplierID INNER JOIN
                            Categories ON Products.CategoryID = Categories.CategoryID INNER JOIN
                            Shippers ON Orders.ShipVia = Shippers.ShipperID
							where  Orders.OrderDate between '1996/7/1' and '1996/7/31' and Shippers.CompanyName= 'United Package'

--2

SELECT          Customers.CustomerID, Customers.ContactName, Products.ProductName,sum([Order Details].Quantity)
FROM              Customers INNER JOIN
                            Orders ON Customers.CustomerID = Orders.CustomerID INNER JOIN
                            [Order Details] ON Orders.OrderID = [Order Details].OrderID INNER JOIN
                            Products ON [Order Details].ProductID = Products.ProductID
							where Customers.CustomerID='ANTON'
							group by Customers.CustomerID, Customers.ContactName, Products.ProductName

--3
select *
from Customers as c
where not exists
(select * from orders as o where c.CustomerID=o.CustomerID)

--4
select e.EmployeeID,e.FirstName+e.LastName as Name,e.Title,e.Extension,e.Notes
from Employees as e
where e.EmployeeID in (select o.EmployeeID from Orders as o)

--5

SELECT distinct Products.*        
FROM              [Order Details] INNER JOIN
                            Orders ON [Order Details].OrderID = Orders.OrderID INNER JOIN
                            Products ON [Order Details].ProductID = Products.ProductID
							where orders.OrderDate between '1998/1/1' and '1998/12/31'
							order by Products.ProductID

select *
from Products as p
where exists
(select * from [Order Details] as od where
exists (select * from orders as o
where o.OrderID=od.OrderID and od.ProductID=p.ProductID
and o.OrderDate between '1998/1/1' and '1998/12/31'
))
order by p.ProductID





