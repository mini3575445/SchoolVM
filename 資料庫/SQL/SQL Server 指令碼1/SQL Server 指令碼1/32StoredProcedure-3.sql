--Order Details營業額樞鈕分析表
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



select p.ProductID,p.ProductName,YEAR(o.OrderDate)as Year,MONTH(o.OrderDate)as Month from [Order Details] as od
inner join Orders as o on od.OrderID=o.OrderID
inner join Products as p on od.ProductID=p.ProductID








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

	




	declare @in_columns nvarchar(max)
	select @in_columns=isnull(@in_columns+',['+ cast(Month as varchar)+']','['+cast(Month as varchar)+']')
	from (select distinct month(OrderDate) as Month from Orders where year(OrderDate)=1997) as o
	order by Month
	print @in_columns

	declare @select_columns nvarchar(max)=''
	select @select_columns+=',isnull(['+cast(Month as varchar)+'],0) as ['+cast(Month as varchar)+']'
	from 
	(select distinct month(OrderDate) as Month from Orders where year(OrderDate)=1997) as o
	order by Month
	print @select_columns

	declare @sql nvarchar(max)
	set @sql='
	select pvt.ProductName as 產品名稱'+ @select_columns+'
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
		('+@in_columns+')

	)as pvt
	order by pvt.ProductID'
	exec(@sql)