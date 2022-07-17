ALTER DATABASE HW4_TaskAdd
COLLATE Cyrillic_General_CI_AS



CREATE TABLE Employees
	(
		EmployeeID int NOT NULL ,
		FName nvarchar(15) NOT NULL,
		LName nvarchar(15) NOT NULL,
		MName nvarchar(15) NOT NULL,
		Salary money NOT NULL,
		PriorSalary money NOT NULL,
		HireDate date NOT NULL,
		TerminationDate date NULL,
		ManagerEmpID int NULL
	)  
GO

ALTER TABLE Employees ADD 
	CONSTRAINT PK_Employees PRIMARY KEY(EmployeeID) 
GO

ALTER TABLE Employees ADD CONSTRAINT
	FK_Employees_Employees FOREIGN KEY(ManagerEmpID) 
	REFERENCES Employees(EmployeeID)  
GO

CREATE TABLE Customers
	(
	CustomerNo int NOT NULL IDENTITY,
	FName nvarchar(15) NOT NULL,
	LName nvarchar(15) NOT NULL,
	MName nvarchar(15) NULL,
	Address1 nvarchar(50) NOT NULL,
	Address2 nvarchar(50) NULL,
	City nchar(10) NOT NULL,
	Phone char(12) NOT NULL,
	DateInSystem date NULL
	)  
GO

ALTER TABLE Customers ADD 
	CONSTRAINT PK_Customers PRIMARY KEY(CustomerNo) 
GO


CREATE TABLE Orders
	(
	OrderID int NOT NULL IDENTITY,
	CustomerNo int NULL,
	OrderDate date NOT NULL,
	EmployeeID int NULL
	)  
GO

ALTER TABLE Orders ADD 
	CONSTRAINT PK_Orders PRIMARY KEY (OrderID) 

GO

ALTER TABLE Orders ADD CONSTRAINT
	FK_Orders_Customers FOREIGN KEY(CustomerNo) 
	REFERENCES Customers(CustomerNo) 
		ON UPDATE  CASCADE 
		ON DELETE  SET NULL 
	
GO

ALTER TABLE Orders ADD CONSTRAINT
	FK_Orders_Employees FOREIGN KEY(EmployeeID) 
	REFERENCES Employees(EmployeeID)
		ON UPDATE  CASCADE 
		ON DELETE  SET NULL 
GO

---
CREATE TABLE Products
	(
	ProdID int NOT NULL IDENTITY,
	Description nchar(50) NOT NULL,
	UnitPrice money NULL,
	Weight numeric(18, 0) NULL
	)
GO

ALTER TABLE Products ADD CONSTRAINT
	PK_Products PRIMARY KEY (ProdID)
GO

CREATE TABLE OrderDetails
	(
	OrderID int NOT NULL,
	LineItem int NOT NULL,
	ProdID int NULL,
	Qty int NOT NULL,
	UnitPrice money NOT NULL,
	TotalPrice as Qty*UnitPrice
	)  
GO

ALTER TABLE OrderDetails ADD CONSTRAINT
	PK_OrderDetails PRIMARY KEY
	(
	OrderID,
	LineItem
	) 
GO

ALTER TABLE OrderDetails ADD CONSTRAINT
	FK_OrderDetails_Products FOREIGN KEY(ProdID) 
		REFERENCES Products(ProdID) 
		ON UPDATE  NO ACTION 
		ON DELETE  SET NULL 	
GO

ALTER TABLE OrderDetails ADD CONSTRAINT
	FK_OrderDetails_Orders FOREIGN KEY(OrderID) 
	REFERENCES Orders(OrderID) 
	 ON UPDATE  CASCADE 
	 ON DELETE  CASCADE
GO
 
INSERT Employees
(EmployeeID, FName, MName, LName, Salary, PriorSalary, HireDate, TerminationDate, ManagerEmpID)
VALUES
(1,'Василий', 'Петрович', 'Лященко', 5000, 800, '11/20/2009', NULL, NULL),
(2,'Иван', 'Иванович', 'Белецкий', 2000, 0, '11/20/2009', NULL, 1),
(3,'Петр', 'Григорьевич', 'Дяченко', 1000, 0, '11/20/2009', NULL, 2),
(4,'Светлана', 'Олеговна', 'Лялечкина', 800, 0, '11/20/2009', NULL, 2);
GO

INSERT Customers 
(LName, FName, MName, Address1, Address2, City, Phone,DateInSystem)
VALUES
('Круковский','Анатолий','Петрович','Лужная 15',NULL,'Харьков','(092)3212211','11/20/2009'),
('Дурнев','Виктор','Викторович','Зелинская 10',NULL,'Киев','(067)4242132','08/03/2010'),
('Унакий','Зигмунд','федорович','Дихтяревская 5',NULL,'Киев','(092)7612343','08/17/2010'),
('Левченко','Виталий','Викторович','Глущенка 5','Драйзера 12','Киев','(053)3456788','08/20/2010'),
('Выжлецов','Олег','Евстафьевич','Киевская 3','Одесская 8','Чернигов','(044)2134212','09/18/2010');
GO

INSERT Products
( Description, UnitPrice, Weight )
VALUES
('LV231 Джинсы',45,0.9),
('GC111 Футболка',20,0.3),
('GC203 Джинсы',48,0.7),
('DG30 Ремень',30,0.5),
('LV12 Обувь',26,1),
('GC11 Шапка',32,0.35)
GO

INSERT Orders
(CustomerNo, OrderDate, EmployeeID)
VALUES
(1,'12/28/2009',2),
(3,'09/01/2010',4),
(5,'09/18/2010',4)
GO

INSERT OrderDetails
(OrderID, LineItem, ProdID, Qty, UnitPrice)
VALUES
(1,1,1,5,45),
(1,2,4,5,29),
(1,3,5,5,25),
(2,1,6,10,32),
(2,2,2,15,20),
(3,1,5,20,26),
(3,2,6,18,32)
GO

SELECT * FROM Employees;
SELECT * FROM OrderDetails;
SELECT * FROM Products;
SELECT * FROM Orders;
SELECT * FROM Customers;