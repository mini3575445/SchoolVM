--子句
--distinct 排除重複值
select distinct 學分
from 課程

--top 取前面幾筆資料
--通常排序完才會用TOP
select top 3 *
from 學生

select top 20 percent *
from 學生

--order by 排序，desc為反向排序
select *
from 課程
order by 學分,課程編號 desc
--with ties 抓出同分的
select top 4 with ties *
from 課程
order by 學分,課程編號