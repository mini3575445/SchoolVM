--			function	VS	 StoredProcedure
--�{���j�p		�p				�j
--������		²��			����	
--�^�ǭ�		��				�L

--function 
--�¶q�Ȩ��(�R�W�ߺD�e��+fn�A�קK�P�t�Ψ�Ʒd�V)
----�إߨ��
create function fnGetSalary(@id char(10))
	returns money	--�^�ǭȪ���ƫ��A
as
begin
	declare @salary money
	select @salary=�~�� from ���u
	where �����Ҧr�� =@id

	if @salary is null
		return 0

	return @salary
end
----�ϥΨ��
print dbo.fnGetSalary('A123456789')