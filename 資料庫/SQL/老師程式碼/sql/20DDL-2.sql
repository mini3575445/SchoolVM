--------Contraints(條件約束)--------
--primary key Constraints
create table Orders(
	OrderID char(8),
	OrderDate datetime not null,
	CustomerID char(5) not null,
	 primary key(OrderID)
)
go
create table Products(
	ProductID char(8)  primary key, --欄位層級的Contraints
	ProductName nvarchar(30) not null,
	UnitPrice money not null
)
go
create table OrderDetails(
	OrderID char(8) ,
	ProductID char(8) ,
	UnitPrice money not null,
	Quantity int not null,
	UnitTotal as UnitPrice*Quantity,
	primary key(OrderID,ProductID)--資料表層級的Contraints
)
go
-----Unique constraint
create table Customers(
	CustomerID char(5) primary key,
	CustomerName nvarchar(20) not null,
	Account varchar(20) not null unique,
	Password varchar(20) not null
)


-----check Constraint



------Foreign key constraint