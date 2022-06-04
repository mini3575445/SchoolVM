select o.OrderID, cate.CategoryName, p.ProductName , od.UnitPrice , od.Quantity , od.UnitPrice*od.Quantity*(1-od.Discount) as ¤p­p , 
from Orders as o 
inner join [Order Details] as od on o.OrderID=od.OrderID
inner join Products as p on p.ProductID=od.ProductID
inner join Categories as cate on cate.CategoryID=p.CategoryID
where OrderDate >= '1996/07/01' and OrderDate <= '1996/07/31' 