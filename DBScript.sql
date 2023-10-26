USE [Inventory_system]
 

---------------- Code To Create DB Tables ---------------------------------
CREATE TABLE Categories(
	[Id] [int] IDENTITY(365478,1) NOT NULL,
	[CategoryName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Sorts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE Customers(
	[Id] [int] IDENTITY(785423,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Phone] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Location] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE  Inventory(
	[Id] [int] IDENTITY(587231,1) NOT NULL,
	[InventoryName] [varchar](50) NOT NULL,
	[CategoriesId] [int] NULL,
	[InventoryLocation] [varchar](50) NOT NULL,
	[InventoryCapacity] [bigint] NOT NULL,
 CONSTRAINT [PK_Storages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE  Orders(
	[Id] [int] IDENTITY(456123,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[OrderedQuantity] [int] NOT NULL,
	[OrderDate] [date] NOT NULL,
	[DeliveryStatus] [varchar](50) NOT NULL,
	[CustomerId] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE  Products(
	[Id] [int] IDENTITY(147963,1) NOT NULL,
	[ProductName] [varchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[SellPrice] [money] NOT NULL,
	[BuyPrice] [money] NOT NULL,
	[EntryDate] [date] NOT NULL,
	[ExpirationDate] [date] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[SupplierId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE  Suppliers(
	[Id] [int] IDENTITY(654789,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[PhoneNum] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE  Users(
	[Id] [int] IDENTITY(254357,1) NOT NULL,
	[FullName] [varchar](50) NULL,
	[UserName] [varchar](50) NOT NULL,
	[Passwaord] [varchar](50) NOT NULL,
	[Permission] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE  Inventory  WITH CHECK ADD  CONSTRAINT [FK_Inventory_Categories] FOREIGN KEY([CategoriesId])
REFERENCES  [Categories] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE  Inventory CHECK CONSTRAINT [FK_Inventory_Categories]
GO
ALTER TABLE  Orders  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerId])
REFERENCES  Customers ([Id])
GO
ALTER TABLE  Orders CHECK CONSTRAINT [FK_Orders_Customers]
GO
ALTER TABLE  Orders  WITH CHECK ADD  CONSTRAINT [FK_Orders_Products] FOREIGN KEY([ProductId])
REFERENCES  Products ([Id])
ON DELETE CASCADE
GO
ALTER TABLE  Orders CHECK CONSTRAINT [FK_Orders_Products]
GO
ALTER TABLE  Products  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryId])
REFERENCES  [Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE  Products CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE  Products  WITH CHECK ADD  CONSTRAINT [FK_Products_Suppliers] FOREIGN KEY([SupplierId])
REFERENCES  Suppliers ([Id])
GO
ALTER TABLE  Products CHECK CONSTRAINT [FK_Products_Suppliers]
GO




------------------------- Code for Stored Procedure -----------------------------------


-------------------Categories Stored Procedures---------------------------------------- 

CREATE procedure  addCategories @categoryName varchar(50)
as

INSERT INTO Categories (CategoryName) values(@categoryName)
go

CREATE procedure  editCategories @id int,@categoryName varchar(50)
as

update Categories set CategoryName =@categoryName
where Id =@id
GO

create procedure  deleteCategories @id int
as

delete Categories where Id =@id
GO

CREATE procedure  selectCategory as
SELECT Categories.Id AS 'Category Id', Categories.CategoryName, Inventory.InventoryName,
       SUM(Products.Quantity) AS 'Total Quantity'
FROM Categories
LEFT OUTER JOIN Inventory ON Categories.Id = Inventory.CategoriesId
LEFT OUTER JOIN Products ON Categories.Id = Products.CategoryId
GROUP BY Categories.Id, Categories.CategoryName, Inventory.InventoryName;
GO

create procedure  selectCategoriesById @id int
as

select Categories.CategoryName from Categories
where Id =@id
GO


Create procedure  CategoriesCount as
select count(id) from Categories 
go 


----Fill Category ComboBox
create procedure  categoryComboBox
as
select Categories.CategoryName from Categories
GO

----Get the id of Category Name from ComboBox
create procedure  selectCategoryComboBoxId @name varchar(50)
as
select Categories.Id from Categories
where Categories.CategoryName = @name
GO

----------------------------------------------------------------------------------------------

------------------------------ Customer Stored Procedure -------------------------------------

CREATE procedure  addCustomer @name varchar(50),@phone varchar(50),
@email varchar(50),@location varchar(50) as

insert into Customers(Name,Phone,Email,Location) values(@name,@phone,@email,@location)
GO

CREATE procedure  editCustomer @id int,@name varchar(50),@phone varchar(50),
@email varchar(50),@location varchar(50) as

update Customers set Name = @name ,Phone=@phone,Email=@email,Location=@location
where Id = @id
GO

create procedure  deleteCustomer @id int
as
delete Customers where Id = @id
GO

CREATE procedure  selectCustomer as
select Customers.Id,Customers.Name,Customers.Phone,Customers.Email,
Customers.Location from Customers
GO

create procedure  selectCustomersById @id int
as
select Customers.Name,Customers.Phone,Customers.Email,Customers.Location
from Customers
where Id =@id
GO

create procedure  customerCount as
select count(id) from Customers
GO

----Fill Category ComboBox
create procedure  customerComboBox
as
select Customers.Name from Customers
GO

----Get the id of Customer Name from ComboBox
create procedure  selectCustomerComboBoxId @name varchar(50)
as
select Customers.Id from Customers
where Customers.Name =@name
GO

----------------------------------------------------------------------------------------------

------------------------------ Inventory Stored Procedure -------------------------------------
CREATE procedure  addInventory @inventoryName varchar(50),@categoriesId int,
@inventoryLocation varchar(50),@inventoryCapacity bigint as

INSERT INTO Inventory(InventoryName,CategoriesId,InventoryLocation,InventoryCapacity)
values(@inventoryName,@categoriesId,@inventoryLocation,@inventoryCapacity)
GO

CREATE procedure  editInventory @id int, @inventoryName varchar(50),@categoriesId int,
@inventoryLocation varchar(50) ,@inventoryCapacity bigint as

update Inventory set InventoryName = @inventoryName,CategoriesId = @categoriesId,
InventoryLocation = @inventoryLocation,InventoryCapacity =@inventoryCapacity
where Id = id
GO

CREATE procedure  deleteInventory @id int as

delete Inventory where Id = @id
GO

CREATE procedure  selectInventory as

select Inventory.Id as 'Inventory Id',Inventory.InventoryName ,Inventory.InventoryLocation 
,InventoryCapacity,sum(Products.Quantity)as 'Products Quantity',Categories.CategoryName 
from Inventory left outer join Categories on Inventory.CategoriesId = Categories.Id
left outer join Products on Categories.Id=Products.CategoryId
GROUP BY  Inventory.Id,Inventory.InventoryName ,Inventory.InventoryLocation 
,InventoryCapacity,Categories.CategoryName;
GO

CREATE procedure  selectInventoryById @id int
as
select InventoryName,InventoryLocation,CategoryName,InventoryCapacity 
from Inventory left outer join Categories on Inventory.CategoriesId = Categories.Id
where Inventory.Id =@id
GO

----------------------------------------------------------------------------------------------

------------------------------ Order Stored Procedure -------------------------------------
CREATE procedure  addOrder @productId int,
@orderedQuantity int,@orderDate date,@deliveryStatus varchar(50),@customerId int

as

INSERT INTO Orders(ProductId,OrderedQuantity,OrderDate,DeliveryStatus,CustomerId)
values(@productId,@orderedQuantity,@orderDate,@deliveryStatus,@customerId)
GO

CREATE procedure  editOrder @id int,@productId int,
@orderedQuantity int,@orderDate date,@deliveryStatus varchar(50)
,@customerId int
as

update Orders set ProductId =@productId ,
OrderedQuantity =@orderedQuantity ,OrderDate =@orderDate ,
DeliveryStatus = @deliveryStatus, CustomerId =@customerId
where Id =@id
GO

create procedure  deleteOrder @id int as

delete Orders where Id =@id
GO

CREATE procedure  selectOrders as

select Orders.Id,Products.ProductName,Orders.OrderedQuantity,Orders.OrderDate,
Orders.DeliveryStatus,Orders.OrderedQuantity * Products.BuyPrice as 'Total Price'
from Orders left outer join Products on Orders.ProductId = Products.Id
GO

CREATE procedure  selectOrdersById @id int
as
select Products.ProductName,Orders.OrderedQuantity,Customers.Name AS 'Customer name'
,Orders.DeliveryStatus,Orders.OrderDate
from Orders left outer join Products on Orders.ProductId = Products.Id
left outer join Customers on Orders.CustomerId = Customers.Id
where Orders.Id = @id
GO

create procedure  OrdersCount as
select count(id) from Orders
GO

----------------------------------------------------------------------------------------------

------------------------------ Product Stored Procedure -------------------------------------
CREATE procedure  addProduct @productName varchar(50),
@quantity int,@sellPrice money, @buyPrice money,@entryDate date ,@expirationDate date,
@categoryId int,@supplierId int
as

INSERT INTO Products (ProductName,Quantity,SellPrice,BuyPrice,EntryDate,ExpirationDate
,CategoryId,SupplierId)
values(@productName,@quantity,@sellPrice,@buyPrice,@entryDate,@expirationDate
,@categoryId,@supplierId)
GO

CREATE procedure  editProduct @id int, @productName varchar(50),
@quantity int,@sellPrice money, @buyPrice money,@entryDate date,@expirationDate date,
@categoryId int,@supplierId int
as

update Products set ProductName =@productName ,Quantity = @quantity,
SellPrice = @sellPrice,BuyPrice = @buyPrice,EntryDate = @entryDate,ExpirationDate =@expirationDate,
CategoryId =@categoryId,SupplierId =@supplierId
where Id = @id
GO

create procedure  deleteProduct @id int as

delete Products where Id = @id
GO

CREATE procedure  selectProduct as

select Products.Id as 'Products Id',Products.ProductName,Products.Quantity,Products.Quantity - Orders.OrderedQuantity as 'Remaining Quantity',
Products.SellPrice,Products.BuyPrice,Products.EntryDate ,Products.ExpirationDate,
Categories.CategoryName,Inventory.InventoryName,Suppliers.Name as 'Suppliers Name'
from Products left outer join Categories on Products.CategoryId = Categories.Id
left outer join Inventory on Categories.Id = Inventory.CategoriesId
left outer join Suppliers on Products.SupplierId = Suppliers.Id
left outer join Orders on Products.id = Orders.ProductId
GO

create procedure  selectProductsById @id int
as
select Products.ProductName,Products.Quantity,Products.SellPrice,Products.BuyPrice,
Products.EntryDate,Products.ExpirationDate,Categories.CategoryName,
Suppliers.Name as 'Suppliers Name'
from Products left outer join Categories on Products.CategoryId = Categories.Id
left outer join Suppliers on Products.SupplierId = Suppliers.Id
where Products.Id = @id
GO

create procedure ProductsCount as
select count(id) from Products
GO

----Fill Product ComboBox
create procedure  productComboBox
as
select Products.ProductName from Products
GO
----Get the id of Product Name from ComboBox
create procedure  selectProductComboBoxId @name varchar(50)
as
select Products.Id from Products
where Products.ProductName =@name
GO
----------------------------------------------------------------------------------------------

------------------------------ Supplier Stored Procedure -------------------------------------
CREATE procedure  addSuppliers @name varchar(50),@phoneNum varchar(50),@email varchar(50) 
as
INSERT INTO Suppliers(Name,PhoneNum,Email)
values(@name,@phoneNum,@email)
GO

CREATE procedure  editSuppliers @id int, @name varchar(50),@phoneNum varchar(50)
,@email varchar(50) as

update Suppliers set Name= @name,PhoneNum = @phoneNum, Email =@email
where Id =@id
GO

create procedure  deleteSuppliers @id int 
as

delete Suppliers where Id =@id
GO

create procedure  selectSuppliers as
select Suppliers.Id,Suppliers.Name,Suppliers.PhoneNum
,Suppliers.Email,Products.ProductName 
from Suppliers left outer join Products on Suppliers.Id = Products.SupplierId
GO

create procedure  selectSupplierById @id int
as
select Suppliers.Name,Suppliers.PhoneNum,Suppliers.Email
from Suppliers
where Suppliers.Id =@id 
GO

create procedure  suppliersCount  as 
select count(id) from Suppliers
GO

----Fill Supplier ComboBox
create procedure  supplierComboBox
as
select Suppliers.Name from Suppliers
GO

----Get the id of Supplier Name from ComboBox
create procedure  supplierComboBoxId @name varchar(50)
as
select Suppliers.Id from Suppliers
where Suppliers.Name = @name
GO



----------------------------------------------------------------------------------------------

------------------------------ User Stored Procedure -------------------------------------
CREATE procedure  addUser @fulltName varchar(50),@userName varchar(50),
@password varchar(50),@permission varchar(50) as

INSERT INTO Users(FullName,UserName,Passwaord,Permission)
values(@fulltName,@userName,@password,@permission)
GO

CREATE procedure  editUser @id int, @fulltName varchar(50),@userName varchar(50),
@password varchar(50) ,@permission varchar(50) as

update Users set FullName =@fulltName ,UserName =@userName ,Passwaord = @password,
Permission = @permission
where Id = @id
GO

create procedure  deleteUser @id int as

delete Users where Id = @id
GO

create procedure  selectUser as
select * from Users
GO

create procedure selectUserById @id int
as
select Users.FullName,Users.UserName,Users.Passwaord,Users.Permission
from Users
where Users.Id = @id
GO

-------------------------------------------------------------------------------------------------

---------------------------Alterd Code After Creating DB ----------------------------------------


-------Alter stored Procedure

---Add the remaining Product column
ALTER procedure selectProduct as

select Products.Id as 'Products Id',Products.ProductName,Products.Quantity,Products.Quantity - Orders.OrderedQuantity as 'Remaining Quantity',
Products.SellPrice,Products.BuyPrice,Products.EntryDate ,Products.ExpirationDate,
Categories.CategoryName,Inventory.InventoryName,Suppliers.Name as 'Suppliers Name'
from Products left outer join Categories on Products.CategoryId = Categories.Id
left outer join Inventory on Categories.Id = Inventory.CategoriesId
left outer join Suppliers on Products.SupplierId = Suppliers.Id
left outer join Orders on Products.id = Orders.ProductId
GO


--------------


--------Alter Table

---Allow to delete Categories related to Inventory
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_Categories] FOREIGN KEY([CategoriesId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE SET NULL
GO
---When deleting Categories all Related Products are deleted
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
---When deleting Products all Related Orders are deleted
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
---CategoriesId can be null in Inventory
Alter TABLE Inventory alter column CategoriesId int NULL