--函數(function)
--純量值函數(函式)

create function fnGetSalary(@id char(10))
	returns money
as
begin
	declare @salary money
	
	select @salary=薪水 from 員工
	where 身份證字號=@id

	if @salary is null
		return 0

	return @salary

end
-------------------------------------------
go
--使用函數
declare @Salary money
set @Salary= dbo.fnGetSalary('A1234888')

if @Salary=0
	print '查無此人薪資'
else
	print @Salary



