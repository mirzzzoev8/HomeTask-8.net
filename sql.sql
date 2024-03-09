create table Customers
(
	Customer_Id serial primary key,
	Customer_Name varchar,
	Email varchar,
	Address varchar
);

create table Products
(
	Product_Id serial primary key,
	Product_Name varchar,
	Price decimal,
	Quantity int
	
);

create table Orders
(
	Order_Id int primary key,
	Customer_Id int references Customers(Customer_Id),
	Order_Date date,
	Amount decimal
);

create table OrderDetails
(
	Order_Detail_Id serial primary key,
	Order_Id int references Orders(Order_Id),
	Product_Id int references Products(Product_Id),
	Quantity int,
	Price decimal
);