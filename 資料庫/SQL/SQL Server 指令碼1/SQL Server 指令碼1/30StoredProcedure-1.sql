--�w�s�{��Stored Procedure	�w�s�{��	VS	���
						--  �S���^�ǭ�		���^�ǭ�
						--					�W��(get��setOrderDetails)
						--�I�s���{��������	²��


--�إ߹w�s�{�ǡA�R�W��orderDetails�A���e���d�߾ǥ͸�ƪ�
--�����`��>��Ʈw>�i�{����>�w�s�{��	�A�i�H�ݨ�إߪ��w�s�{��
--create proc orderDetails 
create procedure orderDetails 
as
begin
	select * from �ǥ�
end
--����w�s�{��
execute orderDetails
--exec orderDetails
-------------------------------------------------------------

create procedure drawStar
as
begin
declare @i int=1 , @result varchar(max)=''

while @i<=10
begin
	set @result += '*'
	set @i+=1
	print @result
	end
end

--���Ѽƪ��w�s�{��
create proc drawStar2
@c int	--�إ�c�Ѽ�
as
begin
declare @i int=1 , @result varchar(max)=''

while @i<=@c
	begin
		set @result += '*'
		set @i+=1
		print @result		
	end
end

--���榳�Ѽƪ��w�s�{��
execute drawStar2 5	--�Ϊk�@:������J�Ѽ�
execute drawStar2 @c=10	--�Ϊk�G




create proc employeeDataRow
	@i int, @j int
as
begin
	select * 
	from ���u
	order by �����Ҧr��
	offset @i rows
	fetch next @j rows only
end


------------------------
exec employeeDataRow 2,3

exec employeeDataRow @j=2,@i=3
-----------------------