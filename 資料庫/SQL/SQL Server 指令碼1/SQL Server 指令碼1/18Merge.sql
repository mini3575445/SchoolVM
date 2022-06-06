--merge合併
--看條件決定要做
select * from 客戶
select * from 新客戶






	
--若原業績目標>=250,刪除該客戶的業績目標資料
--若原業績目標<250,則將該客戶的業績目標+25
--尚未有業績目標的客戶,則將該客戶的業績目標設定為100
merge 客戶業績 as cs
using 客戶 as c
on c.客戶編號=cs.客戶編號
when matched and cs.業績目標>=250 then delete
when matched then 
			update set cs.業績目標=cs.業績目標+25
when not matched then 
			insert(客戶編號,業績目標) values(c.客戶編號,100)
;

