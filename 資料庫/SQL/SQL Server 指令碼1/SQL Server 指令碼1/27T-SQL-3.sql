--流程控制	(T-SQL中case比較常用)
--case

--簡單case
select 姓名,

	case 性別	
		when '男' then '先生'
		when '女' then '小姐'
		else 'N/A'
	end
from 學生


--搜尋case
declare @gender nvarchar(1),@result nvarchar(6)
set @gender='0'
set @result=
case
	when @gender='1' then '先生'
	when @gender='0' then '小姐'
	else 'N/A'
end
print @result
--------------------
go

declare @height int,@result nvarchar(6)
set @height=150

set @result=
case
	when @height>=120
		then '全票'
	when @height>=90
		then '半票'
	else
	   '免票'
end

print @result
