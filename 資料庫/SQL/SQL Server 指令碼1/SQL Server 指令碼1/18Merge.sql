--merge�X��
--�ݱ���M�w�n��
select * from �Ȥ�
select * from �s�Ȥ�






	
--�Y��~�Z�ؼ�>=250,�R���ӫȤ᪺�~�Z�ؼи��
--�Y��~�Z�ؼ�<250,�h�N�ӫȤ᪺�~�Z�ؼ�+25
--�|�����~�Z�ؼЪ��Ȥ�,�h�N�ӫȤ᪺�~�Z�ؼг]�w��100
merge �Ȥ�~�Z as cs
using �Ȥ� as c
on c.�Ȥ�s��=cs.�Ȥ�s��
when matched and cs.�~�Z�ؼ�>=250 then delete
when matched then 
			update set cs.�~�Z�ؼ�=cs.�~�Z�ؼ�+25
when not matched then 
			insert(�Ȥ�s��,�~�Z�ؼ�) values(c.�Ȥ�s��,100)
;

