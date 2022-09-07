create function getOrderID()
	returns nvarchar(12)
as
begin
	declare @newID nvarchar(12), @lastID nvarchar(12)
	
	
	select top 1 @lastID=OrderID from Orders
	where CONVERT(varchar,OrderDate,112) =CONVERT(varchar,getdate(),112)
	order by OrderDate desc


	if @lastID is null
	begin
		set @newID = CONVERT(varchar,getdate(),112)+'0001' 
	end
	else
	begin
		--202209020005+1=>2022090206
		--抓最後一筆訂單編號,加上1成為新訂單編號
		set @newID =cast( cast(@lastID as bigint)+1 as nvarchar(12))

	end

	return @newID
end