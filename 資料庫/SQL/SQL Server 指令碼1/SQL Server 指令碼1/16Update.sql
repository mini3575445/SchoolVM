--update 修改(建議where用PK篩選，不然會改到相同條件的資料
update 課程2
set 學分=2
where 課程編號='CS222'

--若選課人數>=3,將課程學分數改為30

--子查詢
update 課程2
set 學分=30
where 課程編號 in (select 課程編號 from 班級
group by 課程編號
having count(*)>=3)

--合併查詢
update 課程2
set 學分=100
select * from 課程2 inner join 班級 on 課程2.課程編號=班級.課程編號
