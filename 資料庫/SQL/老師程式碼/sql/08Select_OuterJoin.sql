--outer join
select * from 員工

select * from 教授

select * from 員工 as e left outer join 教授 as p
on e.身份證字號=p.身份證字號

select * from 員工 as e right outer join 教授 as p
on e.身份證字號=p.身份證字號

select * from 員工 as e left join 教授 as p
on e.身份證字號=p.身份證字號


--請列出不是教授的員工
select e.* from 員工 as e left outer join 教授 as p
on e.身份證字號=p.身份證字號
where p.教授編號 is null

----------------------------

select 學號,count(*) from 班級
group by 學號

--請列出所有尚未選課的學生資料
select s.* 
from 學生 as s left join 班級 as c 
on s.學號=c.學號
where c.學號 is null
-------------------------------------------------

--full join
select * 
from 學生 as s full join 班級 as c 
on s.學號=c.學號


--對null值的處理方式

select 身份證字號,姓名,城市,街道, ISNULL(電話,'尚未填寫' ) as 電話 ,薪水,保險,扣稅 from 員工




