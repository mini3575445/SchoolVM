--系統變數	像內建函數
select * from 學生
print @@rowcount	-- @@rowcount影響的資料有幾列

if @@error=0
begin

end
else
	rollback



--try catch(投手 捕手)例外處理(每個程式語言都有這個功能)


--try裡面如果發生例外，改為執行catch
begin try
	print 3/0	--除以0為例外
end try
begin catch
	print @@error --除以0的錯誤代碼是8134
	print error_message()
	print '伺服器忙碌中...'
end catch