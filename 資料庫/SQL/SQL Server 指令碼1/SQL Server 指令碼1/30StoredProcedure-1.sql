--預存程序Stored Procedure	預存程序	VS	函數
						--  沒有回傳值		有回傳值
						--					名稱(get或setOrderDetails)
						--呼叫的程式較複雜	簡單


--建立預存程序，命名為orderDetails，內容為查詢學生資料表
--物件總管>資料庫>可程式性>預存程序	，可以看到建立的預存程序
--create proc orderDetails 
create procedure orderDetails 
as
begin
	select * from 學生
end
--執行預存程序
execute orderDetails
--exec orderDetails
-------------------------------------------------------------

create procedure drawStar
as
begin
declare @i int=1 , @result varchar(max)=''

while @i<=10
begin
	set @result += '*'
	set @i+=1
	print @result
	end
end

--有參數的預存程序
create proc drawStar2
@c int	--建立c參數
as
begin
declare @i int=1 , @result varchar(max)=''

while @i<=@c
	begin
		set @result += '*'
		set @i+=1
		print @result		
	end
end

--執行有參數的預存程序
execute drawStar2 5	--用法一:直接輸入參數
execute drawStar2 @c=10	--用法二




create proc employeeDataRow
	@i int, @j int
as
begin
	select * 
	from 員工
	order by 身份證字號
	offset @i rows
	fetch next @j rows only
end


------------------------
exec employeeDataRow 2,3

exec employeeDataRow @j=2,@i=3
-----------------------