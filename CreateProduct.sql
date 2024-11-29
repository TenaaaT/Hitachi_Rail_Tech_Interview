CREATE TABLE Product (
	Item_ID INT IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(50),
	Quantity INT,
	Price DECIMAL(10,2),
	Description NVARCHAR(100)
);