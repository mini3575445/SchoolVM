--group by
select distinct 學分
from 課程

select 學分
from 課程
group by 學分
-----------------
select  性別
from 學生
group by 性別

select 性別,count(*) as 學生人數
from 學生
group by 性別
--------------------------------

select 學號,count(*) as 選課數
from 班級
group by 學號

select 課程編號,count(*) as 課程被選數
from 班級
group by 課程編號

select 教授編號,count(*) as 老師被選數
from 班級
group by 教授編號


select 教授編號,課程編號,count(*) as 老師被選數
from 班級
group by 教授編號,課程編號

---------------------------------
--having(跟where的功能一樣)

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
----------------------------------
--撰寫順序
--select
--from
--where
--group by
--having
--order by

--執行順序
--1. from
--2. where
--3. group by
--4. having
--5. select
--6. order by






