--聚合函數
--count()
select count(*)
from 學生

select count(學號)
from 學生

select count(姓名)
from 學生

select count(生日)
from 學生
-----------------------
--sum()
select sum(薪水) as 人事費用總額
from 員工
--avg()
select avg(薪水) as 平均薪資
from 員工
--max()
select max(薪水) as 最高薪資
from 員工
--min()
select min(薪水) as 最低薪資
from 員工

select sum(薪水) as 人事費用總額,avg(薪水) as 平均薪資,
max(薪水) as 最高薪資,min(薪水) as 最低薪資,
count(*) as 員工人數
from 員工

