--�t���ܼ�
declare @number int=3,@number2 int =0

begin try
	print @number/@number2
end try
begin catch
	
	if @@error=8134
		print '���A��������...'
	else
		print '��Ʃ|���ظm'

	select @@error as ���~�N�X,error_message() as ���~�T��,@@ROWCOUNT as �v�T��Ƶ���
end catch