--group by 把相同的值群組
select 性別
from 學生
group by 性別

select 性別
from 學生
--常與count一起使用
select 性別
from 學生
--學號為單值--count為聚合函數
select 學號,count(*) as 選課次數
from 班級 
group by 學號

select 教授編號,課程編號,count(*) as 老師被選數
from 班級
group by 教授編號,課程編號	--用到聚合函數及單值，單值必須放在group by
-------------------------------------------------------------------------
--having(跟where的功能一樣)
--group by的子句，必須寫在group by後面
--having+聚合函數

select 學號,count(*) as 選課數
from 班級
group by 學號
having count(*)<3

select 學號,count(*) as 選課數
from 班級
group by 學號
having 學號='S005'

select 學號,count(*) as 選課數
from 班級
where  學號='S005'
group by 學號


select 學號,count(*) as 選課數
from 班級
group by 學號
order by 選課數 desc


--撰寫順序
--select
--from
--where
--group by
--having
--order by

--執行順序
--from
--where
--group by
--having
--select
--order by




select 城市,count(*)as 員工人數
from 員工
group by 城市

select *
from 員工
where 身分證