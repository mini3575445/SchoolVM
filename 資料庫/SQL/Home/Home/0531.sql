--exists
--題目:查員工是教授
select * from 員工
where exists(select * from 教授 where 員工.身份證字號 = 教授.身份證字號)
--哪些學生選CS222課程
select * from 學生 where exists
(select * from 班級 where exists
(select * from 課程 where 學分 = 4 and 班級.課程編號=課程.課程編號 and 學生.學號=班級.學號) )

--哪些課程在221-S教室上課
--in
select * from 課程
where 課程編號 in (select 課程編號 from 班級 where 教室='221-S')
--exists
select * from 課程
where exists (select * from 班級 where 教室='221-S' and 課程.課程編號=班級.課程編號)

----周杰倫有選哪一些課程
--in
select * from 課程 where 課程編號 in
(select 課程編號 from 班級 where 學號 =
(select 學號 from 學生 where 姓名='周杰輪'))

--exists
select * from 課程 where exists(
select * from 班級 where exists(
select * from 學生 where 姓名='周杰輪' and 班級.學號=學生.學號 and 課程.課程編號=班級.課程編號))

--合併查詢
select 課程.* from 課程 inner join (學生 inner join 班級 on 學生.學號=班級.學號) on 課程.課程編號=班級.課程編號
where 姓名='周杰輪'


----周杰倫沒有選哪一些課程
--in
select * from 課程 where 課程編號 not in
(select 課程編號 from 班級 where 學號 =
(select 學號 from 學生 where 姓名='周杰輪'))
--exists
select * from 課程 where not exists(
select * from 班級 where exists(
select * from 學生 where 姓名='周杰輪' and 班級.學號=學生.學號 and 課程.課程編號=班級.課程編號))
--合併查
select 課程.* from 課程 inner join (學生 inner join 班級 on 學生.學號=班級.學號) on 課程.課程編號=班級.課程編號
where 姓名='周杰輪'

--------------------------------
--all
--找出大於住在台北所有員工薪資的員工
select * from 員工
where 薪水 >=all (select 薪水 from 員工 where 城市='台北')
--some
select * from 員工
where 薪水 >=some (select 薪水 from 員工 where 城市='台北')




