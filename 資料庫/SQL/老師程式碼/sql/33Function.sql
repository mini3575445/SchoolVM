--���(function)
--�¶q�Ȩ��(�禡)

create function fnGetSalary(@id char(10))
	returns money
as
begin
	declare @salary money
	
	select @salary=�~�� from ���u
	where �����Ҧr��=@id

	if @salary is null
		return 0

	return @salary

end
-------------------------------------------
go
--�ϥΨ��
declare @Salary money
set @Salary= dbo.fnGetSalary('A1234888')

if @Salary=0
	print '�d�L���H�~��'
else
	print @Salary



