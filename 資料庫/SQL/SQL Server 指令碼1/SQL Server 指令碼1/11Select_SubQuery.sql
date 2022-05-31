--------------子查詢(SubQuery)，缺點是子查詢再包子查詢容易有效能問題

--題目：查"張無忌"的選課資料
--原本要用兩個資料表，先找出張無忌的學號，再於班級資料表搜尋
select * from 學生
where 姓名='張無忌'
select *from 班級
where 學號='S003'
--SubQuery
select * from 班級
where 學號=(select 學號 from 學生
where 姓名='張無忌')

--題目：請查詢哪些員工的薪水大於全部員工的平均薪資
select *from 員工
where 薪水 > (select avg(薪水) from 員工 )

------------------合併查詢，效能會比子查詢還要好
--題目：查"張無忌"的選課資料
select c.學號,s.姓名, c.課程編號 from 班級 as c inner join 學生 as s
on c.學號 = s.學號
where 姓名='張無忌'

--題目：請查詢哪些員工的薪水大於全部員工的平均薪資
--方法:用自然合併的寫法做自身合併
select a.身份證字號,a.姓名,a.薪水 from 員工 as a ,員工 as b
group by a.身份證字號,a.姓名,a.薪水
having a.薪水>avg(b.薪水)

------------------------------------------------------------
--題目:哪幾位員工是教授
--子查詢寫法
select * from 員工
where 身份證字號 in (select 身份證字號 from 教授)
--(select 身份證字號 from 教授)輸出多個職所以不能用"="

--合併查詢寫法
select * from 員工 as e inner join 教授 as p 
on e.身份證字號=p.身份證字號

--exists子句詢用的運算子(功能像過濾器)
--特點是不必特地寫欄位
select * from 員工
where exists (select * from 教授 where 員工.身份證字號=教授.身份證字號)
--題目：哪些學生選CS222課程
select * from 班級
where 課程編號 in (Select 課程編號 from 課程 where 課程編號 in ('CS222','CS111'))

--題目：哪些課程在221-S教室上課
--in
select *from 課程
where 課程編號 in (select 課程編號 from 班級 where 教室='221-S')
--exists
select * from 課程
where exists (select 課程編號 from 班級 
where 教室='221-S' and 課程.課程編號=班級.課程編號)



--題目：查詢學生周杰輪所選課的課程資料
--子查詢
--in(一定要欄位對欄位)
select * from 課程
where 課程編號 in(select 課程編號 from 班級 where 學號 = (select 學號 from 學生 where 姓名='周杰輪'))

--exists

--題目：周杰輪沒有選哪一些課程資料
--子查詢







--------------------------------------------------------------
--all運算子
--找出大於住在台北所有員工薪資的員工
select * from 員工
where 薪水>=all(
select 薪水 from 員工
where 城市='台北')

--some或any(T-SQL)運算子
--找出大於住在台北任一員工薪資的員工