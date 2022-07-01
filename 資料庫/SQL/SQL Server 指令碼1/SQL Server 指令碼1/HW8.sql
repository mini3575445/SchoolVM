--建立預存程序
create procedure Sum_for_Products_Salse_Pivot
	@yy int 
as
begin
select pvt.ProductName as 產品名稱 , ISNULL([1],0) as '1月', ISNULL([2],0) as '2月'
, ISNULL([3],0) as '3月', ISNULL([4],0) as '4月', ISNULL([5],0) as '5月', ISNULL([6],0) as '6月'
, ISNULL([7],0) as '7月', ISNULL([8],0) as '8月', ISNULL([9],0) as '9月', ISNULL([10],0) as '10月'
, ISNULL([11],0) as '11月', ISNULL([12],0) as '12月'
from
(select p.ProductID , p.ProductName , year(o.OrderDate)as[Year] , month(o.OrderDate)as[month] , round(sum(od.UnitPrice*od.Quantity*(1-od.Discount)),0)as Total from [Order Details] as od
inner join Orders as o on od.OrderID=o.OrderID
inner join Products as p on p.ProductID=od.ProductID
where year(o.OrderDate)=@yy
Group by p.ProductID , p.ProductName , year(o.OrderDate) , month(o.OrderDate)) as x
pivot
(
	 --pivot裡面放統計值
	 sum(x.Total)
	 for x.Month in
	 ([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12])
)as pvt
order by pvt.ProductID
end
go
--呼叫
exec Sum_for_Products_Salse_Pivot 1997