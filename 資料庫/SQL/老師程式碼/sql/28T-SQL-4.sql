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
----------------------------------
--*
--**
--***
--****
--*****

declare @i int=1, @star varchar(max)=''

while @i<=50
begin
	set @star+='*'
	print @star
	set @i+=1
end