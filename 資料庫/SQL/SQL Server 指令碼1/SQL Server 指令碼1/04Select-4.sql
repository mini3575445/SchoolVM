--聚合函數
--count(欄位)、sum、avg、min、max
select count(*)
from 學生
--sum(欄位)
select sum(薪水) as 人事費用總額,avg(薪水) as 平均薪資,min(薪水) as 最低薪資
,max(薪水) as 最高薪資 , count(*) as 員工人數
from 員工

