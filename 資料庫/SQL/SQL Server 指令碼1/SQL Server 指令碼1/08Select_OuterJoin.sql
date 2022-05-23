-------------outer join 外部合併
--以某一方的資料表為主
select * from 員工
select * from 教授

select * from 員工 as e left outer join 教授 as p
on e.身份證字號=p.身份證字號

--也可以寫成
select * from 員工 as e left join 教授 as p
on e.身份證字號=p.身份證字號

--常用於
--請列出不是教授的員工
select * 
from 教授 as p right outer join 員工 as e 
on p.身份證字號 = e.身份證字號
where p.身份證字號 is null

--請列出所有尚未選課的學生資料
select *
from 學生 as s left outer join 班級 as c
on s.學號 = c.學號
where c.學號 is null

---------------full join 
select * 
from 學生 as s full join 班級 as c 
on s.學號=c.學號

-------------對null值的處理方式
select 姓名,Isnull(電話,'尚未填寫') as 電話 from 員工