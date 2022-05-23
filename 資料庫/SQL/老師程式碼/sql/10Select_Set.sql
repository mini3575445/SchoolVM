--集合運算
--聯集
select 姓名 from 員工
union
select 姓名 from 學生


--交集
select 姓名 from 員工
intersect
select 姓名 from 學生

--差集
select 姓名 from 員工
except
select 姓名 from 學生


select 姓名 from 學生
except
select 姓名 from 員工
