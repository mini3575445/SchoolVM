--�y�{����
--case

--²��case
select �m�W,

	case �ʧO
		when '�k' then '����'
		when '�k' then '�p�j'
		else 'N/A'
	end
from �ǥ�

go

--�j�Mcase

declare @gender nvarchar(1),@result nvarchar(6)
set @gender='0'

set @result=
case
	when @gender='1' then '����'
	when @gender='0' then '�p�j'
	else 'N/A'
end

print @result
-------------------------------------
go

declare @height int,@result nvarchar(6)
set @height=150

set @result=
case
	when @height>=120
		then '����'
	when @height>=90
		then '�b��'
	else
	   '�K��'
end

print @result