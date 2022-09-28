--inner join 
select c.學號,s.姓名 from 班級 as c
inner join 學生 as s on c.學號=s.學號

--group by
select * ,Count(*) from 班級
group by 教授編號,班級,學號