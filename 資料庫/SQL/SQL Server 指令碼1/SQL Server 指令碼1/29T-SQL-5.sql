--�t���ܼ�	�����ب��
select * from �ǥ�
print @@rowcount	-- @@rowcount�v�T����Ʀ��X�C

if @@error=0
begin

end
else
	rollback



--try catch(��� ����)�ҥ~�B�z(�C�ӵ{���y�������o�ӥ\��)


--try�̭��p�G�o�ͨҥ~�A�אּ����catch
begin try
	print 3/0	--���H0���ҥ~
end try
begin catch
	print @@error --���H0�����~�N�X�O8134
	print error_message()
	print '���A�����L��...'
end catch