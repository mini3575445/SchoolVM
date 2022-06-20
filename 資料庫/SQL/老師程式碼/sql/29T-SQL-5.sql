--系統變數
declare @number int=3,@number2 int =0

begin try
	print @number/@number2
end try
begin catch
	
	if @@error=8134
		print '伺服器忙路中...'
	else
		print '資料尚未建置'

	select @@error as 錯誤代碼,error_message() as 錯誤訊息,@@ROWCOUNT as 影響資料筆數
end catch