--�˵���(View)
select * from viewSalesByCategory



create view viewSalesByCategory
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

----------------------------------------------------------

create view viewStudentCourseDetail
as
SELECT   *       
FROM              dbo.���u INNER JOIN
                            dbo.�б� ON dbo.���u.�����Ҧr�� = dbo.�б�.�����Ҧr�� INNER JOIN
                            dbo.�Z�� ON dbo.�б�.�б½s�� = dbo.�Z��.�б½s�� INNER JOIN
                            dbo.�ҵ{ ON dbo.�Z��.�ҵ{�s�� = dbo.�ҵ{.�ҵ{�s�� INNER JOIN
                            dbo.�ǥ� ON dbo.�Z��.�Ǹ� = dbo.�ǥ�.�Ǹ�
select * from 

select �Ǹ�,Expr5,count(*) from view_1
group by �Ǹ�,Expr5


create view view���m�W���б�
as
select e.�m�W,p.* from �б� as p inner join ���u as e
on p.�����Ҧr��=e.�����Ҧr��

select * from view���m�W���б�







