--after trigger

create trigger checkOrderCourse on �Z��
after insert
as
begin
	declare @num int
	select @num= count(*)
	from �Z�� where �Ǹ�=(select �Ǹ� from inserted)

	if @num>=5
	begin
		print '�z�w�ﺡ5����,�Х��h���A��[��'
		rollback
	end
end

insert into �Z�� values('I001','S001','CS222','2022-7-12','dddd')

select * from �Z��
where �Ǹ�='S001'
------------------------------------------------
--�Y�ק�ҾǤ�,���o�C���Ǥ���
create trigger checkCredit on �ҵ{
after update
as
begin
	declare @old int,@new int
	select @new=�Ǥ� from inserted
	select @old=�Ǥ� from deleted

	if @new<@old
	begin
		print '�Ǥ��Ƥ��i�C���Ǥ�'
		rollback
	end
end
------------------------------------------
--�Y�R�����u��Ʈ�,�ӭ��u�]�O�ǥ�,�h���o�R��
select * from ���u
select * from �ǥ�

create trigger checkEmplyoeeIsStudent on ���u
after delete,update
as
begin
	if exists(select * from �ǥ� where �m�W=(select �m�W from deleted))
	begin
		rollback
	end
end

