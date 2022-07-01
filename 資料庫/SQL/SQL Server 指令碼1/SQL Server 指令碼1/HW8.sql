--�إ߹w�s�{��
create procedure Sum_for_Products_Salse_Pivot
	@yy int 
as
begin
select pvt.ProductName as ���~�W�� , ISNULL([1],0) as '1��', ISNULL([2],0) as '2��'
, ISNULL([3],0) as '3��', ISNULL([4],0) as '4��', ISNULL([5],0) as '5��', ISNULL([6],0) as '6��'
, ISNULL([7],0) as '7��', ISNULL([8],0) as '8��', ISNULL([9],0) as '9��', ISNULL([10],0) as '10��'
, ISNULL([11],0) as '11��', ISNULL([12],0) as '12��'
from
(select p.ProductID , p.ProductName , year(o.OrderDate)as[Year] , month(o.OrderDate)as[month] , round(sum(od.UnitPrice*od.Quantity*(1-od.Discount)),0)as Total from [Order Details] as od
inner join Orders as o on od.OrderID=o.OrderID
inner join Products as p on p.ProductID=od.ProductID
where year(o.OrderDate)=@yy
Group by p.ProductID , p.ProductName , year(o.OrderDate) , month(o.OrderDate)) as x
pivot
(
	 --pivot�̭���έp��
	 sum(x.Total)
	 for x.Month in
	 ([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12])
)as pvt
order by pvt.ProductID
end
go
--�I�s
exec Sum_for_Products_Salse_Pivot 1997