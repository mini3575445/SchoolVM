--DDL��Trigger
create trigger readonly_table on database
for drop_table,alter_table
as
begin
	rollback
end


drop table �ҵ{
-----------------------------------------
--���θ�ƮwTrigger
disable trigger readonly_table on database

--���άY��Trigger
alter table �ҵ{
	disable trigger showNewCourse



--�ҥάY��Trigger
alter table �ҵ{
	enable trigger showNewCourse


--�ҥθ�ƮwTrigger
enable trigger readonly_table on database