--�y�{����
--if/else 
declare @test varchar(5) = 'Hello'
if @test='hello' --�S���j�p�g
begin 
	print '����'
end
else
	print '������'

declare @height int
set @height=150

if @height>=120
	print '����'
else if @height>=90
	print '�b��'
else
	print '�K��'