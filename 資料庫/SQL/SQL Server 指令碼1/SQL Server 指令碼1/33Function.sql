--			function	VS	 StoredProcedure
--程式大小		小				大
--複雜度		簡單			複雜	
--回傳值		有				無

--function 
--純量值函數(命名習慣前面+fn，避免與系統函數搞混)
----建立函數
create function fnGetSalary(@id char(10))
	returns money	--回傳值的資料型態
as
begin
	declare @salary money
	select @salary=薪水 from 員工
	where 身份證字號 =@id

	if @salary is null
		return 0

	return @salary
end
----使用函數
print dbo.fnGetSalary('A123456789')