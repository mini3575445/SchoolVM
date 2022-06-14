--檢視表(View)
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
FROM              dbo.員工 INNER JOIN
                            dbo.教授 ON dbo.員工.身份證字號 = dbo.教授.身份證字號 INNER JOIN
                            dbo.班級 ON dbo.教授.教授編號 = dbo.班級.教授編號 INNER JOIN
                            dbo.課程 ON dbo.班級.課程編號 = dbo.課程.課程編號 INNER JOIN
                            dbo.學生 ON dbo.班級.學號 = dbo.學生.學號
select * from 

select 學號,Expr5,count(*) from view_1
group by 學號,Expr5


create view view有姓名的教授
as
select e.姓名,p.* from 教授 as p inner join 員工 as e
on p.身份證字號=e.身份證字號

select * from view有姓名的教授







