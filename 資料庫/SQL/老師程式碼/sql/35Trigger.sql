--Ĳ�o�{��Trigger
--�P�w�s�{�Ǥ@�ˬO�@�ӹw���g�n���{��
--�����L�k�����I�s����A�ӬO�b�Y�Ӯɾ��I�|�ۤvĲ�o����

select * from �Ȥ�

insert into �Ȥ� values('C111','�N����','078888888')


update �Ȥ�
set �m�W='�N���A',�q��='067777777'
output inserted.�Ȥ�s��,inserted.�m�W as NewName, inserted.�q�� as NewTel,
deleted.�m�W as oldName,deleted.�q�� as oldTel
where �Ȥ�s��='C111'
---------------------------------------------------------

create trigger showCustomerData on �Ȥ�
after update
as
begin
	select inserted.�Ȥ�s��,inserted.�m�W as NewName, inserted.�q�� as NewTel
	from inserted

	select deleted.�Ȥ�s��, deleted.�m�W as oldName,deleted.�q�� as oldTel
	from deleted
	
end
-------------
select * from �Ȥ�

update �Ȥ�
set �m�W='���H�A',�q��='0222885544'
where �Ȥ�s��='C010'
----------------------------------
create trigger showNewCourse on �ҵ{
after insert
as
begin
	select * from inserted
end
-----------------------------
insert into �ҵ{ values('CS879','test',3)

