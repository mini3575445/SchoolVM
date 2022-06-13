----建立資料表關聯：新增資料庫圖表>加入資料表（若資料外來鍵與唯一索引鍵不相同會無法修改）

--alter	修改資料表
alter table Orders
	add foreign key(CustomerID) references Customers(CustomerID) on delete no action on update no action

alter table OrdersDetails
	add foreign key(OrderID) references Orders(OrderID) on delete no action on update no action

alter table OrdersDetails
	add foreign key(ProductID) references Products(ProductID) on delete no action on update no action

alter table Products
	add ProductTypeID char(2) not null

alter table Products
	add foreign key(ProductTypeID) references ProductType(ProductTypeID) on delete no action on update no action
