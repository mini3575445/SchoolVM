--insert into �s�W���(���Ϋ��Ӷ���)
insert into �ǥ�(�Ǹ�,�ͤ�,�q��,�m�W,�ʧO)
values('S999','1999/9/9','07-1234567','�L����','�k')

insert into �ǥ�(�Ǹ�,�m�W,�ʧO)
values('S998','�����s','�k')

insert into �ǥ�(�Ǹ�,�ͤ�,�q��,�m�W,�ʧO)
values('S997','','','','')
--Null������''

---------------------------
--�ٲ���쪺�g�k
--1.�Ҧ���쳣�n����
--2.���Ӹ�ƪ�����
insert into �ǥ�
values('S888','�L����','�k',null,null)
-----------------------------------
--insert/select 
--�s�W�ҵ{2��ƪ�A�q�ҵ{��ƪ�(�ƻs�s����ƪ�)
select *
into �ҵ{2
from �ҵ{

--�N��ƪ����[�J�{������ƪ�
insert into �ҵ{2
select �б½s��,��t,123 from �б�
