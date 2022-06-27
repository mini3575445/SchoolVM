select * from
(select 學號,課程編號,教室 from 班級) as x

max(教室)
for 課程編號 in	
([CS101],[CS213],[CS349],[CS222],[CS203],[CS111],[CS121],[CS205])
) as pvt


select * 
from
(select od.ProductID,p.ProductName , year(o.OrderDate) as [Year] , month(o.OrderDate) as [Month],
round(sum(od.UnitPrice*od.Quantity*(1-od.Discount)),0) as Total
from [Order Details] as od
inner join Orders as o on od.OrderID=o.OrderID
inner join Products as p on od.ProductID=p.ProductID
group by od.ProductID,p.ProductName , year(o.OrderDate) , month(o.OrderDate) ) as x
pivot
