USE [Inventory_system]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(365478,1) NOT NULL,
	[CategoryName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Sorts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
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
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[Id] [int] IDENTITY(587231,1) NOT NULL,
	[InventoryName] [varchar](50) NOT NULL,
	[CategoriesId] [int] NOT NULL,
	[InventoryLocation] [varchar](50) NOT NULL,
	[InventoryCapacity] [bigint] NOT NULL,
 CONSTRAINT [PK_Storages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
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
GO
/****** Object:  Table [dbo].[Products]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
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
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
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
/****** Object:  Table [dbo].[Users]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
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
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_Categories] FOREIGN KEY([CategoriesId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [FK_Inventory_Categories]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Products]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Suppliers] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Suppliers] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Suppliers]
GO
/****** Object:  StoredProcedure [dbo].[addCategories]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[addCategories] @categoryName varchar(50)
as

INSERT INTO Categories (CategoryName) values(@categoryName)
GO
/****** Object:  StoredProcedure [dbo].[addCustomer]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[addCustomer] @name varchar(50),@phone varchar(50),
@email varchar(50),@location varchar(50) as

insert into Customers(Name,Phone,Email,Location) values(@name,@phone,@email,@location)
GO
/****** Object:  StoredProcedure [dbo].[addInventory]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[addInventory] @inventoryName varchar(50),@categoriesId int,
@inventoryLocation varchar(50),@inventoryCapacity bigint as

INSERT INTO Inventory(InventoryName,CategoriesId,InventoryLocation,InventoryCapacity)
values(@inventoryName,@categoriesId,@inventoryLocation,@inventoryCapacity)
GO
/****** Object:  StoredProcedure [dbo].[addOrder]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[addOrder] @productId int,
@orderedQuantity int,@orderDate date,@deliveryStatus varchar(50),@customerId int

as

INSERT INTO Orders(ProductId,OrderedQuantity,OrderDate,DeliveryStatus,CustomerId)
values(@productId,@orderedQuantity,@orderDate,@deliveryStatus,@customerId)
GO
/****** Object:  StoredProcedure [dbo].[addProduct]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[addProduct] @productName varchar(50),
@quantity int,@sellPrice money, @buyPrice money,@entryDate date ,@expirationDate date,
@categoryId int,@supplierId int
as

INSERT INTO Products (ProductName,Quantity,SellPrice,BuyPrice,EntryDate,ExpirationDate
,CategoryId,SupplierId)
values(@productName,@quantity,@sellPrice,@buyPrice,@entryDate,@expirationDate
,@categoryId,@supplierId)
GO
/****** Object:  StoredProcedure [dbo].[addSuppliers]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[addSuppliers] @name varchar(50),@phoneNum varchar(50),@email varchar(50) 
as
INSERT INTO Suppliers(Name,PhoneNum,Email)
values(@name,@phoneNum,@email)
GO
/****** Object:  StoredProcedure [dbo].[addUser]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[addUser] @fulltName varchar(50),@userName varchar(50),
@password varchar(50),@permission varchar(50) as

INSERT INTO Users(FullName,UserName,Passwaord,Permission)
values(@fulltName,@userName,@password,@permission)
GO
/****** Object:  StoredProcedure [dbo].[CategoriesCount]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[CategoriesCount] as
select count(id) from Categories
GO
/****** Object:  StoredProcedure [dbo].[categoryComboBox]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[categoryComboBox]
as
select Categories.CategoryName from Categories
GO
/****** Object:  StoredProcedure [dbo].[customerComboBox]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[customerComboBox]
as
select Customers.Name from Customers
GO
/****** Object:  StoredProcedure [dbo].[customerCount]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[customerCount] as
select count(id) from Customers
GO
/****** Object:  StoredProcedure [dbo].[deleteCategories]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deleteCategories] @id int
as

delete Categories where Id =@id
GO
/****** Object:  StoredProcedure [dbo].[deleteCustomer]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deleteCustomer] @id int
as
delete Customers where Id = @id
GO
/****** Object:  StoredProcedure [dbo].[deleteInventory]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[deleteInventory] @id int as

delete Inventory where Id = @id
GO
/****** Object:  StoredProcedure [dbo].[deleteOrder]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deleteOrder] @id int as

delete Orders where Id =@id
GO
/****** Object:  StoredProcedure [dbo].[deleteProduct]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deleteProduct] @id int as

delete Products where Id = @id
GO
/****** Object:  StoredProcedure [dbo].[deleteSuppliers]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deleteSuppliers] @id int 
as

delete Suppliers where Id =@id
GO
/****** Object:  StoredProcedure [dbo].[deleteUser]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deleteUser] @id int as

delete Users where Id = @id
GO
/****** Object:  StoredProcedure [dbo].[editCategories]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[editCategories] @id int,@categoryName varchar(50)
as

update Categories set CategoryName =@categoryName
where Id =@id
GO
/****** Object:  StoredProcedure [dbo].[editCustomer]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[editCustomer] @id int,@name varchar(50),@phone varchar(50),
@email varchar(50),@location varchar(50) as

update Customers set Name = @name ,Phone=@phone,Email=@email,Location=@location
where Id = @id
GO
/****** Object:  StoredProcedure [dbo].[editInventory]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[editInventory] @id int, @inventoryName varchar(50),@categoriesId int,
@inventoryLocation varchar(50) ,@inventoryCapacity bigint as

update Inventory set InventoryName = @inventoryName,CategoriesId = @categoriesId,
InventoryLocation = @inventoryLocation,InventoryCapacity =@inventoryCapacity
where Id = id
GO
/****** Object:  StoredProcedure [dbo].[editOrder]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[editOrder] @id int,@productId int,
@orderedQuantity int,@orderDate date,@deliveryStatus varchar(50)
,@customerId int
as

update Orders set ProductId =@productId ,
OrderedQuantity =@orderedQuantity ,OrderDate =@orderDate ,
DeliveryStatus = @deliveryStatus, CustomerId =@customerId
where Id =@id
GO
/****** Object:  StoredProcedure [dbo].[editProduct]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[editProduct] @id int, @productName varchar(50),
@quantity int,@sellPrice money, @buyPrice money,@entryDate date,@expirationDate date,
@categoryId int,@supplierId int
as

update Products set ProductName =@productName ,Quantity = @quantity,
SellPrice = @sellPrice,BuyPrice = @buyPrice,EntryDate = @entryDate,ExpirationDate =@expirationDate,
CategoryId =@categoryId,SupplierId =@supplierId
where Id = @id
GO
/****** Object:  StoredProcedure [dbo].[editSuppliers]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[editSuppliers] @id int, @name varchar(50),@phoneNum varchar(50)
,@email varchar(50) as

update Suppliers set Name= @name,PhoneNum = @phoneNum, Email =@email
where Id =@id
GO
/****** Object:  StoredProcedure [dbo].[editUser]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[editUser] @id int, @fulltName varchar(50),@userName varchar(50),
@password varchar(50) ,@permission varchar(50) as

update Users set FullName =@fulltName ,UserName =@userName ,Passwaord = @password,
Permission = @permission
where Id = @id
GO
/****** Object:  StoredProcedure [dbo].[OrdersCount]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[OrdersCount] as
select count(id) from Orders
GO
/****** Object:  StoredProcedure [dbo].[productComboBox]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[productComboBox]
as
select Products.ProductName from Products
GO
/****** Object:  StoredProcedure [dbo].[ProductsCount]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ProductsCount] as
select count(id) from Products
GO
/****** Object:  StoredProcedure [dbo].[selectCategoriesById]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[selectCategoriesById] @id int
as

select Categories.CategoryName from Categories
where Id =@id
GO
/****** Object:  StoredProcedure [dbo].[selectCategory]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[selectCategory] as
SELECT Categories.Id AS 'Category Id', Categories.CategoryName, Inventory.InventoryName,
       SUM(Products.Quantity) AS 'Total Quantity'
FROM Categories
LEFT OUTER JOIN Inventory ON Categories.Id = Inventory.CategoriesId
LEFT OUTER JOIN Products ON Categories.Id = Products.CategoryId
GROUP BY Categories.Id, Categories.CategoryName, Inventory.InventoryName;
GO
/****** Object:  StoredProcedure [dbo].[selectCategoryComboBoxId]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[selectCategoryComboBoxId] @name varchar(50)
as
select Categories.Id from Categories
where Categories.CategoryName = @name
GO
/****** Object:  StoredProcedure [dbo].[selectCustomer]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[selectCustomer] as
select Customers.Id,Customers.Name,Customers.Phone,Customers.Email,
Customers.Location from Customers
GO
/****** Object:  StoredProcedure [dbo].[selectCustomerComboBoxId]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[selectCustomerComboBoxId] @name varchar(50)
as
select Customers.Id from Customers
where Customers.Name =@name
GO
/****** Object:  StoredProcedure [dbo].[selectCustomersById]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[selectCustomersById] @id int
as
select Customers.Name,Customers.Phone,Customers.Email,Customers.Location
from Customers
where Id =@id
GO
/****** Object:  StoredProcedure [dbo].[selectInventory]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[selectInventory] as

select Inventory.Id as 'Inventory Id',Inventory.InventoryName ,Inventory.InventoryLocation 
,InventoryCapacity,sum(Products.Quantity)as 'Products Quantity',Categories.CategoryName 
from Inventory left outer join Categories on Inventory.CategoriesId = Categories.Id
left outer join Products on Categories.Id=Products.CategoryId
GROUP BY  Inventory.Id,Inventory.InventoryName ,Inventory.InventoryLocation 
,InventoryCapacity,Categories.CategoryName;
GO
/****** Object:  StoredProcedure [dbo].[selectInventoryById]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[selectInventoryById] @id int
as
select InventoryName,InventoryLocation,CategoryName,InventoryCapacity 
from Inventory left outer join Categories on Inventory.CategoriesId = Categories.Id
where Inventory.Id =@id
GO
/****** Object:  StoredProcedure [dbo].[selectOrders]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[selectOrders] as

select Orders.Id,Products.ProductName,Orders.OrderedQuantity,Orders.OrderDate,
Orders.DeliveryStatus,Orders.OrderedQuantity * Products.BuyPrice as 'Total Price'
from Orders left outer join Products on Orders.ProductId = Products.Id
GO
/****** Object:  StoredProcedure [dbo].[selectOrdersById]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[selectOrdersById] @id int
as
select Products.ProductName,Orders.OrderedQuantity,Customers.Name AS 'Customer name'
,Orders.DeliveryStatus,Orders.OrderDate
from Orders left outer join Products on Orders.ProductId = Products.Id
left outer join Customers on Orders.CustomerId = Customers.Id
where Orders.Id = @id
GO
/****** Object:  StoredProcedure [dbo].[selectProduct]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[selectProduct] as

select Products.Id as 'Products Id',Products.ProductName,Products.Quantity,
Products.SellPrice,Products.BuyPrice,Products.EntryDate ,Products.ExpirationDate,
Categories.CategoryName,Inventory.InventoryName,Suppliers.Name as 'Suppliers Name'
from Products left outer join Categories on Products.CategoryId = Categories.Id
left outer join Inventory on Categories.Id = Inventory.CategoriesId
left outer join Suppliers on Products.SupplierId = Suppliers.Id
GO
/****** Object:  StoredProcedure [dbo].[selectProductComboBoxId]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[selectProductComboBoxId] @name varchar(50)
as
select Products.Id from Products
where Products.ProductName =@name
GO
/****** Object:  StoredProcedure [dbo].[selectProductsById]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[selectProductsById] @id int
as
select Products.ProductName,Products.Quantity,Products.SellPrice,Products.BuyPrice,
Products.EntryDate,Products.ExpirationDate,Categories.CategoryName,
Suppliers.Name as 'Suppliers Name'
from Products left outer join Categories on Products.CategoryId = Categories.Id
left outer join Suppliers on Products.SupplierId = Suppliers.Id
where Products.Id = @id
GO
/****** Object:  StoredProcedure [dbo].[selectSupplierById]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[selectSupplierById] @id int
as
select Suppliers.Name,Suppliers.PhoneNum,Suppliers.Email
from Suppliers
where Suppliers.Id =@id 
GO
/****** Object:  StoredProcedure [dbo].[selectSuppliers]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[selectSuppliers] as
select Suppliers.Id,Suppliers.Name,Suppliers.PhoneNum
,Suppliers.Email,Products.ProductName 
from Suppliers left outer join Products on Suppliers.Id = Products.SupplierId
GO
/****** Object:  StoredProcedure [dbo].[selectUser]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[selectUser] as
select * from Users
GO
/****** Object:  StoredProcedure [dbo].[selectUserById]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[selectUserById] @id int
as
select Users.FullName,Users.UserName,Users.Passwaord,Users.Permission
from Users
where Users.Id = @id
GO
/****** Object:  StoredProcedure [dbo].[supplierComboBox]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[supplierComboBox]
as
select Suppliers.Name from Suppliers
GO
/****** Object:  StoredProcedure [dbo].[supplierComboBoxId]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[supplierComboBoxId] @name varchar(50)
as
select Suppliers.Id from Suppliers
where Suppliers.Name = @name
GO
/****** Object:  StoredProcedure [dbo].[suppliersCount]    Script Date: 09/04/45 01:32:40 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[suppliersCount]  as 
select count(id) from Suppliers
GO
