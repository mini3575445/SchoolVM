-------------���X�B��(�i�Ω��Ӳ@�L���p����ƪ�)
--�p��
--����u�M�ǥͦ@�����ǤH
select �m�W from ���u
union
select �m�W from �ǥ�

--�涰
--����u�P�ɤ]�O�ǥ�
select �m�W from ���u
intersect
select �m�W from �ǥ�

--�t��
--���u��ƪ����O�ǥͪ��H�A�ѤU�u�����u�������H
select �m�W from ���u
except
select �m�W from �ǥ�

--�ǥ͸�ƪ����O���u���H�A�ѤU�u���ǥͨ������H
select �m�W from �ǥ�
except
select �m�W from ���u
