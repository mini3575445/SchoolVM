Create proc addOrders
	@ShipName nvarchar(30),
	@ShipAddress nvarchar(100),
	@ShipID int,
	@PayTypeID int, 
	@MemberID int,
	@cart nvarchar(max)
as
begin

	declare @EmpID int
	declare @n int ,@m int

	select @n=count(*) from Employees
	set @m= floor(rand()*@n)

	select @EmpID=EmployeeID from Employees
	order by EmployeeID
	offset @m rows
	fetch next 1 rows only


	declare @OID varchar(12) = dbo.getOrderID()
	
	begin tran

	insert into Orders
	values(@OID, getdate(), @ShipName, @ShipAddress,null, @ShipID, @PayTypeID,@EmpID,@MemberID )

	if @@error=0
	begin
		insert into OrderDetails(OrderID, ProductID, UnitPrice, Quantity)
		select @OID, PID, Price, Amount from openjson(@cart)
		with( OID varchar(12), PID varchar(6), Price smallint, Amount smallint)
		
		if @@error=0
			commit
		else
			rollback
	end
	else
		rollback


end

