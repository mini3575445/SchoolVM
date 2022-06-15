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

----------Check Constaraint，用在比較簡單的檢查
create table ProductType(
	ProductTypeID char(2) primary key,
	ProductTypeName nvarchar(50) not null,
	ProductTypeValue int not null default 0 constraint CK_ProductTypeValueNoLessZero check(ProductTypeValue>=0)
	)


------Foreign key constraint


create table Classes(
	StuID char(4),
	CourseID char(5),
	ProfessorID char(4),
	ClassTime　datetime not null,
	Classroom varchar(8) not null,
	primary key(StuID,CourseID,ProfessorID),
	foreign key(StuID) references Students(StuID) on delete no action on update no action,
	foreign key(CourseID) references Course(CourseID) on delete cascade on update cascade,
	foreign key(ProfessorID) references Professors(ProfessorID) on delete cascade on update no action
)

