--瑈祘北
--case

--虏虫case
select ﹎,

	case ┦
		when '╧' then 'ネ'
		when '' then '﹋'
		else 'N/A'
	end
from 厩ネ

go

--穓碝case

declare @gender nvarchar(1),@result nvarchar(6)
set @gender='0'

set @result=
case
	when @gender='1' then 'ネ'
	when @gender='0' then '﹋'
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
		then '布'
	when @height>=90
		then '布'
	else
	   '布'
end

print @result