--merge
--看條件決定要做新增、修改或刪除
--比對客戶資料表與新客戶資料表
--若已存在的客戶則修改其資料,若屬新客戶則新增其資料

merge 客戶 as c
using 新客戶 as nc
on c.客戶編號=nc.客戶編號
when matched then 
	update set 姓名=nc.姓名,電話=nc.電話
when not matched then 
	insert (客戶編號,姓名,電話) values(nc.客戶編號,nc.姓名,nc.電話)
;

--若原業績目標>=250,刪除該客戶的業績目標資料
--若原業績目標<250,則將該客戶的業績目標+25
--尚未有業績目標的客戶,則將該客戶的業績目標設定為100

merge 客戶業績 as cs
using 客戶 as c
on cs.客戶編號=c.客戶編號
when matched and cs.業績目標>=250 then
	delete
when matched then
	update set 業績目標=cs.業績目標+25
when not matched then
	insert(客戶編號,業績目標) values(c.客戶編號,100)
;



