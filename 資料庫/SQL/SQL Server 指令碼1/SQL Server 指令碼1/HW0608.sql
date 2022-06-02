--1.�иռg�@�X�֬d�ߡA�d�ߥX�q�ʤ�����b1996�~7��ë��w�e�f���q���uUnited Package�v�����q�椧�q�f���Ӹ�ơA�æC�X�q�渹�X�B���~���O�W�١B���~�W�١B���~�q�ʳ���B���~�q�ʼƶq�B���~�����p�p�B�Ȥ�s���B�Ȥ�W�١B���f�H�W�r�B�q�ʤ���B�B�z�q����u���m�W�B�e�f�覡�B�����ӦW�ٵ���ƶ��ءA�䤤���~�����p�p�ХH�|�ˤ��J�p��ܾ�Ʀ�C
select o.OrderID, cate.CategoryName, p.ProductName , od.UnitPrice , od.Quantity , round(od.UnitPrice*od.Quantity*(1-od.Discount),0) as ���~�����p�p  ,
cust.CustomerID , cust.CompanyName , cust.ContactName , o.OrderDate , e.LastName , e.FirstName , Ship.CompanyName as �e�f�覡 , sup.CompanyName as �����ӦW��
from Orders as o 
inner join [Order Details] as od on o.OrderID=od.OrderID
inner join Products as p on p.ProductID=od.ProductID
inner join Categories as cate on cate.CategoryID=p.CategoryID
inner join Customers as cust on cust.CustomerID=o.CustomerID
inner join Employees as e on e.EmployeeID=o.EmployeeID
inner join Shippers as Ship on Ship.ShipperID = o.ShipVia
inner join Suppliers as sup on sup.SupplierID=p.SupplierID
where OrderDate >= '1996/07/01' and OrderDate <= '1996/07/31' and Ship.CompanyName='United Package'


--2.�иռg�@�X�֬d�ߡA�d�߫Ȥ�ANTON���~�өҭq�ʪ��Ҧ����~�A�òέp�X�U�ز��~���q�ʼƶq�A��X�p�U���G�C
select c.CustomerID , c.ContactName , p.ProductName , od.Quantity from Products as p
inner join [Order Details] as od on od.ProductID=p.ProductID
inner join Orders as o on o.OrderID=od.OrderID
inner join Customers as c on c.CustomerID=o.CustomerID
where c.CustomerID='ANTON'

--3. �ЧQ��exists�B��l�t�X�l�d�ߦ��A��X���ǫȤ�q���U�L�q��A�æC�X�Ȥ᪺�Ҧ����C(���i�Ψ�in�B��A�礣�i�ΦX�֬d�ߦ�) 
select * from Customers
where not exists (select * from Orders where Customers.CustomerID = Orders.CustomerID ) 

--4. �ЧQ��in�B��l�t�X�l�d�ߦ��A�d�߭��ǭ��u���B�z�L�q��A�æC�X���u�����u�s���B�m�W�B¾�١B�����������X
--�B�������C(���i�Ψ�exists�B��A�礣�i�ΦX�֬d�ߦ�) 
select EmployeeID,LastName,FirstName,Title,Extension,Notes from Employees
where EmployeeID in (select EmployeeID from Orders )

--5. �ЦX�֬d�߻P�l�d�ߨ�ؼg�k�A�C�X1998�~�שҦ��Q�q�ʹL�����~��ơA�æC�X���~���Ҧ����A�B�̲��~�s���Ѥp
--��j�ƧǡC(�g�X�֬d�߮ɤ��o�Υ���l�d�ߦ��A�g�l�d�߮ɤ��o�Υ���X�֬d�ߦ�)
--�X�֬d��
select distinct p.* from Products as p
inner join [Order Details] as od on p.ProductID=od.ProductID
inner join Orders as o on od.OrderID = o.OrderID
where o.OrderDate >='1998/1/1' and o.OrderDate<='1998/12/31'
--�l�d��
select * from Products 
where ProductID in(select ProductID from [Order Details] 
where OrderID in (select OrderID from Orders where OrderDate>='1998/1/1'and OrderDate<='1998/12/31'))
order by ProductID

