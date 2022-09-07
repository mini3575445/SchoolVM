--DDL的Trigger
create trigger readonly_table on database
for drop_table,alter_table
as
begin
	rollback
end


drop table 課程
-----------------------------------------
--停用資料庫Trigger
disable trigger readonly_table on database

--停用某個Trigger
alter table 課程
	disable trigger showNewCourse



--啟用某個Trigger
alter table 課程
	enable trigger showNewCourse


--啟用資料庫Trigger
enable trigger readonly_table on database