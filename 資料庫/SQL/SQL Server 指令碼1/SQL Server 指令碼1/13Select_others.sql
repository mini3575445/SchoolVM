--offset 排除前幾個資料，是order by的子句
select * from 員工
order by 身份證字號
offset 3 rows

--fetch next取幾筆資料，(一定要有offset)
select * from 員工
order by 身份證字號
offset 3 rows
fetch next 2 rows only


-----------------------------------------------------
----cast改變資料型態
select cast(薪水 as varchar)  --varchar動態字元
from 員工

select ISNULL(cast(生日 as varchar),'尚未填寫') from 學生 
--把生日的資料型態轉為String

----convert改變資料型態+顯示格式
select convert(varchar,薪水,101)
from 員工

select ISNULL(convert(varchar,生日,111),'尚未填寫') from 學生 

