--pivot
select * from �Z�� as c
inner join �ǥ� as s on c.�Ǹ�=s.�Ǹ�
inner join �ҵ{ as co on c.�ҵ{�s��=co.�ҵ{�s��

select *
from (select �Ǹ�,�ҵ{�s��,�Ы� from �Z��) as x
pivot
(
	max(�Ы�)
	for �ҵ{�s�� in
	([CS101],[CS213],[CS349],[CS222],[CS203],[CS111],[CS121],[CS205])
) as pvt
go

--�i��
select �Ǹ�,isnull([CS101],'---') as CS101,isnull([CS213],'---') as CS213,
isnull([CS349],'---') as CS349,isnull([CS222],'---') as CS222,
isnull([CS203],'---') as CS203,isnull([CS111],'---') as CS111,
isnull([CS121],'---') as CS121,isnull([CS205],'---') as CS205
from (select �Ǹ�,�ҵ{�s��,�Ы� from �Z��) as x
pivot
(
	max(�Ы�)
	for �ҵ{�s�� in
	([CS101],[CS213],[CS349],[CS222],[CS203],[CS111],[CS121],[CS205])
) as pvt
go


--�A�i��
declare @in_columns nvarchar(max)
declare @sql nvarchar(max)
select @in_columns=isnull(@in_columns+',['+�ҵ{�s��+']','['+�ҵ{�s��+']')
from 
(select �ҵ{�s�� from �ҵ{) as a

print @in_columns

set @sql=
'select *
from (select �Ǹ�,�ҵ{�s��,�Ы� from �Z��) as x
pivot
(
	max(�Ы�)
	for �ҵ{�s�� in
	('+@in_columns+' )
) as pvt'

exec(@sql)
go


--�̲׶i��
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



