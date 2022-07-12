--觸發程序Trigger
--與預存程序一樣是一個預先寫好的程式
--但它無法直接呼叫執行，而是在某個時機點會自己觸發執行

select * from 客戶

insert into 客戶 values('C111','霍元甲','078888888')


update 客戶
set 姓名='霍元乙',電話='067777777'
output inserted.客戶編號,inserted.姓名 as NewName, inserted.電話 as NewTel,
deleted.姓名 as oldName,deleted.電話 as oldTel
where 客戶編號='C111'
---------------------------------------------------------

create trigger showCustomerData on 客戶
after update
as
begin
	select inserted.客戶編號,inserted.姓名 as NewName, inserted.電話 as NewTel
	from inserted

	select deleted.客戶編號, deleted.姓名 as oldName,deleted.電話 as oldTel
	from deleted
	
end
-------------
select * from 客戶

update 客戶
set 姓名='路人乙',電話='0222885544'
where 客戶編號='C010'
----------------------------------
create trigger showNewCourse on 課程
after insert
as
begin
	select * from inserted
end
-----------------------------
insert into 課程 values('CS879','test',3)

