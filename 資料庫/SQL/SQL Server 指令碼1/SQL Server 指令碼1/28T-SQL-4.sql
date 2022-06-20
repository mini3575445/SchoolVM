--¬yµ{±±¨î
--while

declare @i int=1,@sum int=0

while @i<=100
begin
set @sum+=@i
set @i+=1
end
print @sum
go
------------------------
--*
--**
--***
--****
--*****

declare @i int=1 , @result varchar(max)=''

while @i<=10
begin
	set @result += '*'
	set @i+=1
	print @result
end

