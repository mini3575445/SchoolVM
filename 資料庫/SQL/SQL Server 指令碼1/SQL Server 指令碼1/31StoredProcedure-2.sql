--���m��Excel�ϯä��R��
--pivot	(select�i���g�k)

--1.���n�C���
--2.���g�l�d��(�~���pivot�B��l)
--3.pivot�̭��g�έp��


select * from --2.�l�d��
--1.	�C  ,  ��  ,  ��
(select �Ǹ�,�ҵ{�s��,�Ы� from �Z��) as x


pivot --3.�o�Ӫ�S���έp��
(
--�Ы��ݩ���@�ӽҵ{�A�ҥH��FOR
max(�Ы�)
for �ҵ{�s�� in	--[]��ܬ�����A���O�r��
([CS101],[CS213],[CS349],[CS222],[CS203],[CS111],[CS121],[CS205])	--�o�̬O�檺���D
) as pvt




--4.NULL�אּ---(�n�bselect�~���isNull)
select �Ǹ�,isnull([CS101],'---')as[CS101],isnull([CS213],'---')as[CS213],isnull([CS349],'---')as[CS349]
,isnull([CS222],'---')as[CS222],isnull([CS203],'---')as[CS203],isnull([CS111],'---')as[CS111]
,isnull([CS121],'---')as[CS121],isnull([CS205],'---')as[CS205]from
(select �Ǹ�,�ҵ{�s��,�Ы� from �Z��) as x 
pivot
(
max(�Ы�)
for �ҵ{�s�� in 
(
[CS101],[CS213],[CS349],[CS222],[CS203],[CS111],[CS121],[CS205])--�U�@�B��o�̼g������ 
)as pvt
go



--5.
declare @in_colunms nvarchar(max)
declare @sql nvarchar(max)

--***�B�z�r�ꪺ�r�I
--ISNULL(�����Ū������,�Ū������)
select @in_colunms = ISNULL(@in_colunms+',['+�ҵ{�s��+']','['+�ҵ{�s��+']')
from (select �ҵ{�s�� from �ҵ{) as a
print @in_colunms

set @sql=
'select *
from(select �Ǹ�,�ҵ{�s��,�Ы� from �Z��) as x 
pivot
(
max(�Ы�)
for �ҵ{�s�� in 
('+@in_colunms+')
)as pvt'

exec(@sql)
--exec�i�H����r��
--EX:exec ('select * from �ǥ�')


--6.
Create proc getCoursePivot
as
begin
	declare @in_columns nvarchar(max)
	declare @sql nvarchar(max)
	select @in_columns=isnull(@in_columns+',['+�ҵ{�s��+']','['+�ҵ{�s��+']')
	from 
	(select �ҵ{�s�� from �ҵ{) as a
	print @in_columns

	declare @select_columns nvarchar(max)=''
	select @select_columns+=',isnull(['+�ҵ{�s��+'],''---'') as ['+�ҵ{�s��+']'
	from 
	(select �ҵ{�s�� from �ҵ{) as b
	order by �ҵ{�s��
	print @select_columns

	set @sql=
	'select �Ǹ�'+@select_columns+'
	from (select �Ǹ�,�ҵ{�s��,�Ы� from �Z��) as x
	pivot
	(
		max(�Ы�)
		for �ҵ{�s�� in
		('+@in_columns+' )
	) as pvt'

	exec(@sql)
end