----�إ߸�ƪ����p�G�s�W��Ʈw�Ϫ�>�[�J��ƪ�]�Y��ƥ~����P�ߤ@�����䤣�ۦP�|�L�k�ק�^

--alter	�ק��ƪ�
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
