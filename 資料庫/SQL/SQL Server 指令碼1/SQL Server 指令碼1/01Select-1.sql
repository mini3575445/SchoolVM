
select 10 as score

--選特定欄位
select 姓名,生日,電話
 from 學生

--取別名
select 姓名 as name,生日 as birthday,電話 as Tel
 from 學生

--數值運算
select 姓名,薪水,保險,扣稅, 薪水-保險-扣稅 as 淨所得
from 員工

--日期時間運算
select 姓名,生日,DATEDIFF(YEAR,生日,getdate())as 年齡
from 學生

