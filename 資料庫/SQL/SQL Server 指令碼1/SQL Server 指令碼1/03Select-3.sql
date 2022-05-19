--where 條件篩選(SQL字串用'')
select *
from 學生
where 性別='男'

select *
from 學生
where 學號='S002'

select *
from 員工
where 薪水>=50000

select *
from 學生
where 生日>='1991/1/1'

--找出學生資料中未填寫生日的人
select *
from 學生
where 生日 is null	--找null要特別使用is null

--like 模糊查詢(一定要配合模糊運算，沒用模糊運算的話相當於"=")
--%:代表0~n個任意字元
--_:代表1個任意字元
select *
from 學生
where 姓名 like '陳%'

select *
from 教授
where 科系 like 'c_s'

--[找包含括號中的字]:有c or 有k...
select *
from 教授
where 科系 like '%[cklj]%'	

--[找沒有包含括號中的字]:有c or 有k...
select *
from 教授
where 科系 like '%[^cklj]%'	

--[找沒有包含括號中的字]:有c or 有k...
select *
from 教授
where 科系 like '%[A-DW-Z0-5]%'	
--上面跟下面一樣
select *
from 教授
where 科系 like '%[ABCDWXYZ012345]%'	
----------------------------------------------
--between...and...運算
select * 
from 員工
where 薪水 >= 25000 and 薪水<=55000
--上面跟下面一樣
select * 
from 員工
where 薪水 between 25000 and 55000

--in 運算
select *
from 課程
where 課程編號 ='CS101' or 課程編號 ='CS213'or
課程編號 ='CS349'or 課程編號 ='CS999'

select *
from 課程
where 課程編號 in ('CS101','CS213','CS349','CS999')