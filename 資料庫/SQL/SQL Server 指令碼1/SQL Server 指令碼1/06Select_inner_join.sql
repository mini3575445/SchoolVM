--合併查詢
--inner join 內部合併查詢
--把班級資料表跟學生資料表合併--PK與FK關聯

select s.學號,s.姓名,s.性別,co.課程編號,co.名稱,co.學分,
e.姓名,p.科系,c.教室,c.上課時間
from 班級 as c 
inner join 學生 as s  on c.學號=s.學號
inner join 課程 as co on c.課程編號=co.課程編號
inner join 教授 as p on c.教授編號=p.教授編號
inner join 員工 as e on e.身份證字號=p.身份證字號
--班級都是FK，資料表稱為明細
--其他資料表稱為主檔

select s.學號,s.姓名,count(*)as 選課數
from 班級 as c 
inner join 學生 as s on c.學號=s.學號 
group by s.學號,s.姓名

select e.姓名,co.課程編號,co.名稱,co.學分,count(*)
from 班級 as c 
inner join 課程 as co on c.課程編號=co.課程編號
inner join 教授 as p on c.教授編號=p.教授編號
inner join 員工 as e on e.身份證字號=p.身份證字號
group by e.姓名,co.課程編號,co.名稱,co.學分

--查教授 教幾個課程
select p.教授編號,c.課程編號,count(*) as 授課數量
from 教授 as p
inner join 班級 as c on p.教授編號=c.教授編號
group by p.教授編號,c.課程編號
------------------------------------------------------------
--inner join 的第二種寫法
select s.學號,s.姓名,s.性別,co.課程編號,co.名稱,co.學分,
e.姓名,p.科系,c.教室,c.上課時間
from 課程 as co 
ineer join (班級 as c 
inner join 學生 as s 
on c.學號=s.學號) 
on c.課程編號=co.課程編號
-------------------------------------------------------------
--第三種寫法(自然(隱含)合併法)
--把關聯寫成條件(and連接)