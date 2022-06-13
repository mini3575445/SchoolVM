----------Check Constaraint�A�Φb���²�檺�ˬd
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
	ClassTime�@datetime not null,
	Classroom varchar(8) not null,
	primary key(StuID,CourseID,ProfessorID),
	foreign key(StuID) references Students(StuID) on delete no action on update no action,
	foreign key(CourseID) references Course(CourseID) on delete cascade on update cascade,
	foreign key(ProfessorID) references Professors(ProfessorID) on delete cascade on update no action
)

