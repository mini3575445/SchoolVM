--合併查詢
--inner join 內部合併查詢
select s.學號,s.姓名, s.性別,co.課程編號,co.名稱,co.學分,
e.姓名,p.科系,c.教室,c.上課時間
from 班級 as c 
inner join 學生 as s on c.學號=s.學號 
inner join 課程 as co on c.課程編號=co.課程編號
inner join 教授 as p on c.教授編號=p.教授編號
inner join 員工 as e on e.身份證字號=p.身份證字號

select s.學號,s.姓名,count(*)
from 班級 as c 
inner join 學生 as s on c.學號=s.學號 
group by s.學號,s.姓名

select e.姓名,co.課程編號,co.名稱,co.學分,count(*)
from 班級 as c 
inner join 課程 as co on c.課程編號=co.課程編號
inner join 教授 as p on c.教授編號=p.教授編號
inner join 員工 as e on e.身份證字號=p.身份證字號
group by e.姓名,co.課程編號,co.名稱,co.學分

-------------------------------------------------------
--inner join 的第二種寫法

select s.學號,s.姓名, s.性別,co.課程編號,co.名稱,co.學分,
e.姓名,p.科系,c.教室,c.上課時間
from 員工 as e 
inner join (教授 as p inner join 
(課程 as co inner join 
(班級 as c inner join 學生 as s on c.學號=s.學號) 
on c.課程編號=co.課程編號) 
on p.教授編號=c.教授編號) 
on e.身份證字號=p.身份證字號
---------------------------------------
--第三種寫法(自然(隱含)合併法)

select s.學號,s.姓名, s.性別,co.課程編號,co.名稱,co.學分,
e.姓名,p.科系,c.教室,c.上課時間
from 班級 as c ,學生 as s, 課程 as  co,教授 as p,員工 as e 
where  c.學號=s.學號 and c.課程編號=co.課程編號 
and c.教授編號=p.教授編號 and e.身份證字號=p.身份證字號




