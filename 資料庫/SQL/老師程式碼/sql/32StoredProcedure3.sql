--Order Details��~�B�϶s���R��
select *
from
(select od.ProductID,p.ProductName,year(o.OrderDate) as [Year],month(o.OrderDate) as [Month],
round(sum(od.UnitPrice*od.Quantity*(1-od.Discount)),0) as Total
from [Order Details] as od
inner join Orders as o on od.OrderID=o.OrderID
inner join Products as p on od.ProductID=p.ProductID
where year(o.OrderDate)=1997
group by od.ProductID,p.ProductName,year(o.OrderDate),month(o.OrderDate)) as x
pivot
(
	sum(x.Total)
	for x.Month in
	([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12])

)as pvt
order by pvt.ProductID
go

--�i��-�B�znull��
select pvt.ProductName as ���~�W��,isnull([1],0) as '1��',isnull([2],0) as '2��'
,isnull([3],0) as '3��',isnull([4],0) as '4��',isnull([5],0) as '5��',isnull([6],0) as '6��'
,isnull([7],0) as '7��',isnull([8],0) as '8��',isnull([9],0) as '9��',isnull([10],0) as '10��'
,isnull([11],0) as '11��',isnull([12],0) as '12��'
from
(select od.ProductID,p.ProductName,year(o.OrderDate) as [Year],month(o.OrderDate) as [Month],
round(sum(od.UnitPrice*od.Quantity*(1-od.Discount)),0) as Total
from [Order Details] as od
inner join Orders as o on od.OrderID=o.OrderID
inner join Products as p on od.ProductID=p.ProductID
where year(o.OrderDate)=1997
group by od.ProductID,p.ProductName,year(o.OrderDate),month(o.OrderDate)) as x
pivot
(
	sum(x.Total)
	for x.Month in
	([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12])

)as pvt
order by pvt.ProductID

go
--�A�i��-�g�����
alter proc Sum_for_Products_Salse_Pivot
	@yy int
as
begin
	declare @in_columns nvarchar(max)
	select @in_columns=isnull(@in_columns+',['+ cast(Month as varchar)+']','['+cast(Month as varchar)+']')
	from (select distinct month(OrderDate) as Month from Orders where year(OrderDate)=@yy) as o
	order by Month
	print @in_columns

	declare @select_columns nvarchar(max)=''
	select @select_columns+=',isnull(['+cast(Month as varchar)+'],0) as ['+cast(Month as varchar)+'��]'
	from 
	(select distinct month(OrderDate) as Month from Orders where year(OrderDate)=@yy) as o
	order by Month
	print @select_columns

	declare @sql nvarchar(max)
	set @sql='
	select pvt.ProductName as ���~�W��'+ @select_columns+'
	from
	(select od.ProductID,p.ProductName,year(o.OrderDate) as [Year],month(o.OrderDate) as [Month],
	round(sum(od.UnitPrice*od.Quantity*(1-od.Discount)),0) as Total
	from [Order Details] as od
	inner join Orders as o on od.OrderID=o.OrderID
	inner join Products as p on od.ProductID=p.ProductID
	where year(o.OrderDate)='+cast(@yy as varchar)+'
	group by od.ProductID,p.ProductName,year(o.OrderDate),month(o.OrderDate)) as x
	pivot
	(
		sum(x.Total)
		for x.Month in
		('+@in_columns+')

	)as pvt
	order by pvt.ProductID'

	exec(@sql)
end


--����
exec Sum_for_Products_Salse_Pivot 1997