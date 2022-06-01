--CTE(common table expression)

--教務系統-主管資料表，ER圖上為一元關係

select 員工字號 from 主管 where 主管字號 in (
select 員工字號 from 主管 where 主管字號 is null)


--CTE:
with test
as
(
--這裡放select
)
------------------
--CTE最常用在遞迴
--Recursive遞迴
with 主管階層
as
(
select 姓名, 1 as 層級,員工字號 from 主管 where 主管字號 is null
union all
select 主管.姓名 ,層級+1 as 層級 , 主管.員工字號 from 主管 inner join 主管階層
on 主管.主管字號=主管階層.員工字號
)
select 主管階層.姓名,主管階層.層級 from 主管階層
order by 主管階層.層級
