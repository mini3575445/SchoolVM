create function getOrderID()
	returns nvarchar(12)
as
begin
	declare @newID nvarchar(12), @lastID nvarchar(12)
	
	
	select top 1 @lastID=OrderID from Orders
	where CONVERT(varchar,OrderDate,112) =CONVERT(varchar,getdate(),112)
	order by OrderDate desc


	if @lastID is null	--��Ѥ�����Ĥ@�����
	begin
		set @newID = CONVERT(varchar,getdate(),112)+'0001' 
	end

	else --��̫�@�����+1
	begin
		set @newID =cast( cast(@lastID as bigint)+1 as nvarchar(12))
	end
	return @newID
end