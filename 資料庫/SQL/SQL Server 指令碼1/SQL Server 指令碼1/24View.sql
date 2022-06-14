--View 檢視表
--把事先寫好的select存成一個表

select * from [Sales by Category]
------------------
create view viewSalesbyCategory
as
SELECT          dbo.Categories.CategoryID, dbo.Categories.CategoryName, dbo.Products.ProductName, 
                            SUM(dbo.[Order Details Extended].ExtendedPrice) AS ProductSales
FROM              dbo.Categories INNER JOIN
                            dbo.Products INNER JOIN
                            dbo.Orders INNER JOIN
                            dbo.[Order Details Extended] ON dbo.Orders.OrderID = dbo.[Order Details Extended].OrderID ON 
                            dbo.Products.ProductID = dbo.[Order Details Extended].ProductID ON 
                            dbo.Categories.CategoryID = dbo.Products.CategoryID
GROUP BY   dbo.Categories.CategoryID, dbo.Categories.CategoryName, dbo.Products.ProductName
----------------------------

