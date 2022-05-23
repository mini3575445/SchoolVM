-------------集合運算(可用於兩個毫無關聯的資料表)
--聯集
--找員工和學生共有哪些人
select 姓名 from 員工
union
select 姓名 from 學生

--交集
--找員工同時也是學生
select 姓名 from 員工
intersect
select 姓名 from 學生

--差集
--員工資料表扣掉是學生的人，剩下只有員工身分的人
select 姓名 from 員工
except
select 姓名 from 學生

--學生資料表扣掉是員工的人，剩下只有學生身分的人
select 姓名 from 學生
except
select 姓名 from 員工
