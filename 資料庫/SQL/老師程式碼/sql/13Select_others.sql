--offset
select * 
from 員工
order by 身份證字號

select * 
from 員工
order by 身份證字號
offset 3 rows

select * 
from 員工
order by 身份證字號
offset 3 rows
fetch next 2 rows only
---------------------------

select 學號,姓名,性別,電話,isnull(convert(varchar,生日,120 ),'尚未填') as 生日
from 學生

select 身份證字號,姓名,城市,ISNULL(電話,'尚未填') as 電話,薪水
from 員工

select cast(薪水 as varchar)
from 員工

select convert(varchar,薪水)
from 員工



