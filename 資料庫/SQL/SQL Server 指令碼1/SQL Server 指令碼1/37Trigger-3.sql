--Instead Trigger���Ӫ��ާ@���N��
--�b�ǳ�commit���Ĥ@�ӨB�J������
--Instead Trigger�W�R�׳��u�঳�U�@��


--��ڭn�s�W�ҵ{,�Y�s�W�ɵo�{�ӽҵ{�w�s�b,�ڴN��H�u�ק�ҵ{��ơv���N��Ӫ��s�W�ʧ@
insert into �ҵ{ values('CS777','tesasdt',2)

create trigger add_Course_instead on �ҵ{
instead of insert
ad
begin
	if exists(select * from �ҵ{ where �ҵ{�s��=(select �ҵ{�s�� from inserted))
	begin
	update �ҵ{ set �W��=inserted.�W��,�Ǥ�=inserted.�Ǥ�
	from �ҵ{ inner join inserted on �ҵ{.�ҵ{�s��=inserted.�ҵ{�s��
	end

end