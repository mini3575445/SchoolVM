--offset �ư��e�X�Ӹ�ơA�Oorder by���l�y
select * from ���u
order by �����Ҧr��
offset 3 rows

--fetch next���X����ơA(�@�w�n��offset)
select * from ���u
order by �����Ҧr��
offset 3 rows
fetch next 2 rows only


-----------------------------------------------------
----cast���ܸ�ƫ��A
select cast(�~�� as varchar)  --varchar�ʺA�r��
from ���u

select ISNULL(cast(�ͤ� as varchar),'�|����g') from �ǥ� 
--��ͤ骺��ƫ��A�ରString

----convert���ܸ�ƫ��A+��ܮ榡
select convert(varchar,�~��,101)
from ���u

select ISNULL(convert(varchar,�ͤ�,111),'�|����g') from �ǥ� 

