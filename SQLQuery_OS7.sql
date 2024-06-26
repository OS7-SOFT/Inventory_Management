USE [master]
GO
/****** Object:  Database [Inventory_system]    Script Date: 11/6/2023 10:44:35 PM ******/
CREATE DATABASE [Inventory_system]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Inventory_system', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Inventory_system.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Inventory_system_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Inventory_system_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [Inventory_system] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Inventory_system].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Inventory_system] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Inventory_system] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Inventory_system] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Inventory_system] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Inventory_system] SET ARITHABORT OFF 
GO
ALTER DATABASE [Inventory_system] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Inventory_system] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Inventory_system] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Inventory_system] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Inventory_system] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Inventory_system] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Inventory_system] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Inventory_system] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Inventory_system] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Inventory_system] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Inventory_system] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Inventory_system] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Inventory_system] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Inventory_system] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Inventory_system] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Inventory_system] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Inventory_system] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Inventory_system] SET RECOVERY FULL 
GO
ALTER DATABASE [Inventory_system] SET  MULTI_USER 
GO
ALTER DATABASE [Inventory_system] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Inventory_system] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Inventory_system] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Inventory_system] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Inventory_system] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Inventory_system', N'ON'
GO
USE [Inventory_system]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(365478,1) NOT NULL,
	[CategoryName] [varchar](50) NULL,
 CONSTRAINT [PK_Sorts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Inventory](
	[Id] [int] IDENTITY(587231,1) NOT NULL,
	[InventoryName] [varchar](50) NOT NULL,
	[CategoriesId] [int] NULL,
	[InventoryLocation] [varchar](50) NOT NULL,
	[InventoryCapacity] [bigint] NOT NULL,
	[Available] [bigint] NULL,
 CONSTRAINT [PK_Storages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InventoryProducts]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryProducts](
	[InventoryId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[InventoryId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(456123,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[OrderedQuantity] [int] NOT NULL,
	[OrderDate] [date] NOT NULL,
	[DeliveryStatus] [varchar](50) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[TotalPrcie] [money] NULL,
	[InventoryId] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Products]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(147963,1) NOT NULL,
	[ProductName] [varchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Available] [int] NULL,
	[SellPrice] [money] NOT NULL,
	[BuyPrice] [money] NOT NULL,
	[QuantitySold] [int] NULL,
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Categories] FOREIGN KEY([Id])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Categories]
GO
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_Categories] FOREIGN KEY([CategoriesId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [FK_Inventory_Categories]
GO
ALTER TABLE [dbo].[InventoryProducts]  WITH CHECK ADD FOREIGN KEY([InventoryId])
REFERENCES [dbo].[Inventory] ([Id])
GO
ALTER TABLE [dbo].[InventoryProducts]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Inventory] FOREIGN KEY([InventoryId])
REFERENCES [dbo].[Inventory] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Inventory]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Products]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Suppliers] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Suppliers] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Suppliers]
GO
/****** Object:  StoredProcedure [dbo].[addCategories]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[addCategories] @categoryName varchar(50)
as

INSERT INTO Categories (CategoryName) values(@categoryName)

GO
/****** Object:  StoredProcedure [dbo].[addCustomer]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[addCustomer] @name varchar(50),@phone varchar(50),
@email varchar(50),@location varchar(50) as

insert into Customers(Name,Phone,Email,Location) values(@name,@phone,@email,@location)

GO
/****** Object:  StoredProcedure [dbo].[addInventory]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE procedure [dbo].[addInventory] @inventoryName varchar(50),@categoriesId int,
@inventoryLocation varchar(50),@inventoryCapacity bigint as

INSERT INTO Inventory(InventoryName,CategoriesId,InventoryLocation,InventoryCapacity,Available)
values(@inventoryName,@categoriesId,@inventoryLocation,@inventoryCapacity,@inventoryCapacity)

GO
/****** Object:  StoredProcedure [dbo].[addOrder]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


------------------------------------------

CREATE proc [dbo].[addOrder] 
@productId int,@orderedQuantity int,@orderDate date,@deliveryStatus varchar(50),@customerId int,@inventoryId int
as
begin
	
	INSERT INTO Orders(ProductId,OrderedQuantity,OrderDate,DeliveryStatus,CustomerId,InventoryId)
	values(@productId,@orderedQuantity,@orderDate,@deliveryStatus,@customerId,@inventoryId)

	--Check if not canceled 
	if @deliveryStatus != 'Canceled'
	begin 
		
		update InventoryProducts
		SET Quantity = Quantity - @orderedQuantity
		Where  InventoryProducts.ProductId = @productId 
		AND InventoryProducts.InventoryId = @inventoryId
		
		update Products
		set Available = Available - @orderedQuantity,
		QuantitySold += @orderedQuantity
		where 
		Id = @productId


		 Update Inventory
		 set Available = Available + @orderedQuantity
		 where Inventory.Id = @inventoryId
	end
end

GO
/****** Object:  StoredProcedure [dbo].[addProduct]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure  [dbo].[addProduct] @productName varchar(50),
@quantity int,@sellPrice money, @buyPrice money,@entryDate date ,@expirationDate date,
@categoryId int,@supplierId int,@inventorId int
as
BEGIN
	--Add Product
	INSERT INTO Products (ProductName,Quantity,Available,SellPrice,BuyPrice,QuantitySold,EntryDate,ExpirationDate
	,CategoryId,SupplierId)
	values(@productName,@quantity,@quantity,@sellPrice,@buyPrice,0,@entryDate,@expirationDate
	,@categoryId,@supplierId)

	--Get product id 
	DECLARE @id INT;
	SELECT @id = Products.Id FROM Products WHERE Products.ProductName = @productName
	--Add product id & add inventory id 
	INSERT INTO InventoryProducts (InventoryId,ProductId,Quantity)
		   VALUES(@inventorId,@id,@quantity)

	--update availabe in inventory
	Update Inventory
	set Available -= @quantity
	where Inventory.Id = @inventorId
END

GO
/****** Object:  StoredProcedure [dbo].[addSuppliers]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[addSuppliers] @name varchar(50),@phoneNum varchar(50),@email varchar(50) 
as
INSERT INTO Suppliers(Name,PhoneNum,Email)
values(@name,@phoneNum,@email)

GO
/****** Object:  StoredProcedure [dbo].[addUser]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[addUser] @fulltName varchar(50),@userName varchar(50),
@password varchar(50),@permission varchar(50) as

INSERT INTO Users(FullName,UserName,Passwaord,Permission)
values(@fulltName,@userName,@password,@permission)

GO
/****** Object:  StoredProcedure [dbo].[CategoriesCount]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[CategoriesCount] as
select count(id) from Categories

GO
/****** Object:  StoredProcedure [dbo].[categoryComboBox]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[categoryComboBox]
as
select Categories.CategoryName from Categories

GO
/****** Object:  StoredProcedure [dbo].[customerComboBox]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[customerComboBox]
as
select Customers.Name from Customers

GO
/****** Object:  StoredProcedure [dbo].[customerCount]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[customerCount] as
select count(id) from Customers

GO
/****** Object:  StoredProcedure [dbo].[deleteCategories]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deleteCategories] @id int
as

delete Categories where Id =@id

GO
/****** Object:  StoredProcedure [dbo].[deleteCustomer]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deleteCustomer] @id int
as
delete Customers where Id = @id

GO
/****** Object:  StoredProcedure [dbo].[deleteInventory]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[deleteInventory] @id int as

delete Inventory where Id = @id

GO
/****** Object:  StoredProcedure [dbo].[deleteOrder]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[deleteOrder] @id int
as
BEGIN
	DECLARE @status varchar(20);
	DECLARE @productId int;
	DECLARE @inventoryId int;
	DECLARE @quantity int;

	SELECT @status = Orders.DeliveryStatus
	FROM Orders WHERE Orders.Id = @id;
	SELECT @productId = Orders.ProductId
	FROM Orders WHERE Orders.Id = @id;
	SELECT @inventoryId = Orders.InventoryId
	FROM Orders WHERE Orders.Id = @id;
	SELECT @quantity = Orders.OrderedQuantity
	FROM Orders WHERE Orders.Id = @id;


	IF @status = 'Under proccessing'
	BEGIN
		 UPDATE Products
        SET
            Available = Available + @quantity, -- 14 = 14 +4 =18
            QuantitySold = QuantitySold - @quantity
        WHERE Id = @productId;

		Update Inventory
		set Available = Available - @quantity
		where Inventory.Id = @inventoryId

		Update InventoryProducts
		SET Quantity = Quantity + @quantity
		where InventoryId = @inventoryId
		and ProductId = @productId
	END

	delete Orders where Id =@id

END
GO
/****** Object:  StoredProcedure [dbo].[deleteProduct]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[deleteProduct] @id int 
as
BEGIN
	

	UPDATE Inventory
	SET Available = Available +(
		SELECT InventoryProducts.Quantity
		FROM InventoryProducts
		WHERE InventoryProducts.ProductId = @id
	)
	WHERE Inventory.Id IN(
		SELECT InventoryProducts.InventoryId
		FROM InventoryProducts
		WHERE InventoryProducts.ProductId = @id
	)

	DELETE FROM Products
	WHERE Products.Id = @id

	DELETE FROM InventoryProducts
	WHERE InventoryProducts.ProductId = @id

END
GO
/****** Object:  StoredProcedure [dbo].[deleteSuppliers]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deleteSuppliers] @id int 
as

delete Suppliers where Id =@id

GO
/****** Object:  StoredProcedure [dbo].[deleteUser]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deleteUser] @id int as

delete Users where Id = @id

GO
/****** Object:  StoredProcedure [dbo].[editCategories]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[editCategories] @id int,@categoryName varchar(50)
as

update Categories set CategoryName =@categoryName
where Id =@id

GO
/****** Object:  StoredProcedure [dbo].[editCustomer]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[editCustomer] @id int,@name varchar(50),@phone varchar(50),
@email varchar(50),@location varchar(50) as

update Customers set Name = @name ,Phone=@phone,Email=@email,Location=@location
where Id = @id

GO
/****** Object:  StoredProcedure [dbo].[editInventory]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[editInventory] @id int, @inventoryName varchar(50),@categoriesId int,
@inventoryLocation varchar(50) ,@inventoryCapacity bigint 
as
Begin
	DECLARE @current_capacity Bigint;
	SELECT @current_capacity = Inventory.InventoryCapacity
	FROM Inventory 
	Where Id = @id

	if @current_capacity > @inventoryCapacity
	BEGIN
		update Inventory set InventoryName = @inventoryName,CategoriesId = @categoriesId,
	InventoryLocation = @inventoryLocation,InventoryCapacity =@inventoryCapacity,
	Available = Available - (@current_capacity - @inventoryCapacity)
	where Id = @id
	END
	ELSE if @current_capacity < @inventoryCapacity
	BEGIN
		update Inventory set InventoryName = @inventoryName,CategoriesId = @categoriesId,
	InventoryLocation = @inventoryLocation,InventoryCapacity =@inventoryCapacity,
	Available = Available + (@inventoryCapacity - @current_capacity)
	where Id = @id
	END

	ELSE if @current_capacity = @inventoryCapacity
	BEGIN
		update Inventory set InventoryName = @inventoryName,CategoriesId = @categoriesId,
	InventoryLocation = @inventoryLocation,InventoryCapacity =@inventoryCapacity
	where Id = @id
	END
	

END

GO
/****** Object:  StoredProcedure [dbo].[editOrder]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[editOrder]
    @id INT,
    @productId INT,
    @orderedQuantity INT,
    @orderDate DATE,
    @deliveryStatus VARCHAR(50),
    @customerId INT,
	@inventoryId INT
AS
BEGIN 
    DECLARE @quantity INT;
	DECLARE @status VARCHAR(50);
	DECLARE @current_Available INT;
    DECLARE @current_inventoryId INT;
    -- Retrieve the current ordered quantity from the Orders table
    SELECT @quantity = Orders.OrderedQuantity --4
    FROM Orders
    WHERE Orders.Id = @id;

	SELECT @status = Orders.DeliveryStatus
    FROM Orders
    WHERE Orders.Id = @id;

	SELECT @current_inventoryId = Orders.InventoryId
    FROM Orders
    WHERE Orders.Id = @id;

	SELECT @current_Available = Products.Available --4
    FROM Products
    WHERE Products.Id = @productId;
    -- Update the Orders table with the new values
    UPDATE Orders
    SET
        ProductId = @productId,
		InventoryId = @inventoryId,
        OrderedQuantity = @orderedQuantity,
        OrderDate = @orderDate,
        DeliveryStatus = @deliveryStatus,
        CustomerId = @customerId
    WHERE Id = @id;

	IF @current_inventoryId != @inventoryId AND @status != 'Canceled'
	Begin
		Update Inventory
		set Available = Available - @quantity
		where Inventory.Id = @current_inventoryId

		Update InventoryProducts
		SET Quantity = Quantity + @quantity
		where InventoryId = @current_inventoryId
		and ProductId = @productId

		Update Inventory
		set Available = Available + @orderedQuantity
		where Inventory.Id = @inventoryId

		Update InventoryProducts
		SET Quantity = Quantity - @orderedQuantity
		where InventoryId = @inventoryId
		and ProductId = @productId

		 IF @orderedQuantity > @quantity 
			BEGIN
			-- Quantity increased
			   UPDATE Products
			   SET
			    Available = Available - (@orderedQuantity - @quantity),
			    QuantitySold = QuantitySold + (@orderedQuantity - @quantity)
			   WHERE Id = @productId;
			END
			ELSE IF @orderedQuantity < @quantity
			BEGIN
			-- Quantity decreased
			  UPDATE Products
			  SET
			    Available = Available + (@quantity - @orderedQuantity),
			    QuantitySold = QuantitySold - (@quantity - @orderedQuantity)
			  WHERE Id = @productId;
			END
			ELSE IF @orderedQuantity = @quantity
			BEGIN
			UPDATE Products
			   SET
			    Available = Available -  @quantity,
			    QuantitySold = QuantitySold +  @quantity
			   WHERE Id = @productId;
			END
	END

    -- Update the Products table based on quantity change
    ELSE IF @deliveryStatus = 'Canceled' and @status != 'Canceled'
    BEGIN
        -- Quantity is being canceled, so return it to the product quantity
        UPDATE Products
        SET
            Available = Available + @quantity, -- 14 = 14 +4 =18
            QuantitySold = QuantitySold - @quantity
        WHERE Id = @productId;

		Update Inventory
		set Available = Available - @quantity
		where Inventory.Id = @inventoryId

		Update InventoryProducts
		SET Quantity = Quantity + @quantity
		where InventoryId = @inventoryId
		and ProductId = @productId

    END
    ELSE IF @deliveryStatus = 'Under proccessing' or  @deliveryStatus = 'Completed'
    BEGIN
      IF @status = 'Canceled' 
	  BEGIN
	   UPDATE Products
        SET
            Available = Available - @orderedQuantity, -- 14 = 14 +4 =18
            QuantitySold = QuantitySold + @orderedQuantity
        WHERE Id = @productId;

		Update Inventory
		set Available = Available + @orderedQuantity 
		where Inventory.Id = @inventoryId

		Update InventoryProducts
		SET Quantity = Quantity - @orderedQuantity
		where InventoryId = @inventoryId
		and ProductId = @productId
	  END
	  ELSE IF @quantity != @orderedQuantity
	  BEGIN
		   IF @orderedQuantity > @quantity 
			BEGIN
			-- Quantity increased
			   UPDATE Products
			   SET
			    Available = Available - (@orderedQuantity - @quantity),
			    QuantitySold = QuantitySold + (@orderedQuantity - @quantity)
			   WHERE Id = @productId;

			   Update Inventory
			   set Available = Available + (@orderedQuantity - @quantity)
			   where Inventory.Id = @inventoryId

			   Update InventoryProducts
			   SET Quantity = Quantity - (@orderedQuantity - @quantity)
			   where InventoryId = @inventoryId
			   and ProductId = @productId
			END
			ELSE IF @orderedQuantity < @quantity
			BEGIN
			-- Quantity decreased
			  UPDATE Products
			  SET
			    Available = Available + (@quantity - @orderedQuantity),
			    QuantitySold = QuantitySold - (@quantity - @orderedQuantity)
			  WHERE Id = @productId;

			   Update Inventory
			   set Available = Available - (@quantity - @orderedQuantity)
			   where Inventory.Id = @inventoryId
			   
			   Update InventoryProducts
			   SET Quantity = Quantity + (@quantity - @orderedQuantity)
			   where InventoryId = @inventoryId
			   and ProductId = @productId

			END
			ELSE IF @orderedQuantity = @quantity
			BEGIN
			UPDATE Products
			   SET
			    Available = Available -  @quantity,
			    QuantitySold = QuantitySold +  @quantity
			   WHERE Id = @productId;

			 Update Inventory
			   set Available = Available +  @quantity
			   where Inventory.Id = @inventoryId

			 Update InventoryProducts
			   SET Quantity = Quantity - @quantity
			   where InventoryId = @inventoryId
			   and ProductId = @productId
			END
	  END
    END
END

GO
/****** Object:  StoredProcedure [dbo].[editProduct]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure  [dbo].[editProduct] @id int, @productName varchar(50),
@quantity int,@sellPrice money, @buyPrice money,@entryDate date,@expirationDate date,
@categoryId int,@supplierId int,@inventorId int
as
BEGIN
	DECLARE @current_quantity INT;
	select @current_quantity = Products.Quantity
	from Products where Products.Id = @id

	update Products set ProductName =@productName ,Quantity = @quantity,
	SellPrice = @sellPrice,BuyPrice = @buyPrice,EntryDate = @entryDate,ExpirationDate =@expirationDate,
	CategoryId =@categoryId,SupplierId = @supplierId 
	where Id = @id

	IF @current_quantity > @quantity
	BEGIN
		update Products
		set Available = Available - (@current_quantity - @quantity )
		where Id = @id

		update Inventory
		set Available = Available + (@current_quantity - @quantity )
		where Id = @inventorId
	END
	ELSE IF @current_quantity < @quantity
	BEGIN
		update Products
		set Available = Available + (@quantity - @current_quantity )
		where Id = @id
		
		update Inventory
		set Available = Available - ( @quantity - @current_quantity  )
		where Id = @inventorId
	END

	update InventoryProducts 
	SET InventoryId = @inventorId,
		ProductId = @id,
		Quantity = @quantity

END


GO
/****** Object:  StoredProcedure [dbo].[editProductQuantityOnInventory]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE procedure  [dbo].[editProductQuantityOnInventory] @id int, @productName varchar(50),
@quantity int,@sellPrice money, @buyPrice money,@entryDate date,@expirationDate date,
@categoryId int,@supplierId int,@inventorId int
as
BEGIN
	DECLARE @current_quantity INT;
	select @current_quantity = InventoryProducts.Quantity
	from InventoryProducts 
	where InventoryProducts.ProductId = @id
	AND InventoryProducts.InventoryId = @inventorId

	UPDATE InventoryProducts
	SET Quantity = @quantity
	WHERE InventoryProducts.ProductId = @id
	AND InventoryProducts.InventoryId = @inventorId

	IF @current_quantity > @quantity
	BEGIN
		update Products
		set Available = Available - (@current_quantity - @quantity )
		where Id = @id

		update Inventory
		set Available = Available + (@current_quantity - @quantity )
		where Id = @inventorId
	END
	ELSE IF @current_quantity < @quantity
	BEGIN
		update Products
		set Available = Available + (@quantity - @current_quantity )
		where Id = @id
		
		update Inventory
		set Available = Available - ( @quantity - @current_quantity  )
		where Id = @inventorId
	END

END


GO
/****** Object:  StoredProcedure [dbo].[editSuppliers]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[editSuppliers] @id int, @name varchar(50),@phoneNum varchar(50)
,@email varchar(50) as

update Suppliers set Name= @name,PhoneNum = @phoneNum, Email =@email
where Id =@id

GO
/****** Object:  StoredProcedure [dbo].[editUser]    Script Date: 11/6/2023 10:44:35 PM ******/
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
/****** Object:  StoredProcedure [dbo].[get_inventoryNameAndCategoryName]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[get_inventoryNameAndCategoryName]
AS
SELECT Categories.CategoryName,Inventory.InventoryName 
FROM Categories
LEFT OUTER JOIN Inventory ON Categories.Id = Inventory.CategoriesId
LEFT OUTER JOIN Products ON Categories.Id = Products.CategoryId
GROUP BY Categories.CategoryName, Inventory.InventoryName;
GO
/****** Object:  StoredProcedure [dbo].[inventoryComboBox]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure  [dbo].[inventoryComboBox]
as
select Inventory.InventoryName ,Inventory.Available,Categories.CategoryName
from Inventory
LEFT JOIN Categories on Inventory.CategoriesId = Categories.Id
GO
/****** Object:  StoredProcedure [dbo].[inventoryFromComboBox]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure  [dbo].[inventoryFromComboBox]
as
select Inventory.InventoryName from Inventory

GO
/****** Object:  StoredProcedure [dbo].[inventoryToComboBox]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[inventoryToComboBox]
    @CategoryId int = NULL
AS
    -- Category with the same or empty Inventory
    SELECT Inventory.InventoryName
    FROM Inventory
    INNER JOIN Categories ON Inventory.CategoriesId = @CategoryId
    WHERE Categories.Id IS NOT NULL
    OR (
        Categories.Id IS NULL
        AND EXISTS (
            SELECT 1
            FROM Inventory AS I
            LEFT JOIN Categories AS C ON I.CategoriesId = C.Id
            WHERE C.Id IS NULL
            AND I.InventoryName = Inventory.InventoryName
        )
    )
    GROUP BY Inventory.InventoryName;

GO
/****** Object:  StoredProcedure [dbo].[OrdersCount]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[OrdersCount] as
select count(id) from Orders

GO
/****** Object:  StoredProcedure [dbo].[productComboBox]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------

CREATE procedure  [dbo].[productComboBox]
as
select Products.ProductName,Products.Available 
from Products

GO
/****** Object:  StoredProcedure [dbo].[ProductsCount]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ProductsCount] as
select count(id) from Products

GO
/****** Object:  StoredProcedure [dbo].[selectCategoriesById]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[selectCategoriesById] @id int
as

select Categories.CategoryName from Categories
where Id =@id

GO
/****** Object:  StoredProcedure [dbo].[selectCategory]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[selectCategory] as
SELECT Categories.Id AS 'Category Id', Categories.CategoryName, Inventory.InventoryName,
       SUM(Products.Quantity) AS 'Total Quantity'
FROM Categories
LEFT OUTER JOIN Inventory ON Categories.Id = Inventory.CategoriesId
LEFT OUTER JOIN Products ON Categories.Id = Products.CategoryId
GROUP BY Categories.Id, Categories.CategoryName, Inventory.InventoryName;

GO
/****** Object:  StoredProcedure [dbo].[selectCategoryComboBoxId]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[selectCategoryComboBoxId] 
    @name varchar(50) = NULL
AS
BEGIN
    IF @name IS NOT NULL
    BEGIN
        SELECT Categories.Id 
        FROM Categories
        WHERE Categories.CategoryName = @name;
    END
    ELSE
    BEGIN
        SELECT null AS Id;
    END
END

GO
/****** Object:  StoredProcedure [dbo].[selectCustomer]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[selectCustomer] as
select Customers.Id,Customers.Name,Customers.Phone,Customers.Email,
Customers.Location from Customers


GO
/****** Object:  StoredProcedure [dbo].[selectCustomerComboBoxId]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[selectCustomerComboBoxId] @name varchar(50)
as
select Customers.Id from Customers
where Customers.Name =@name

GO
/****** Object:  StoredProcedure [dbo].[selectCustomersById]    Script Date: 11/6/2023 10:44:35 PM ******/
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
/****** Object:  StoredProcedure [dbo].[selectInventory]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure  [dbo].[selectInventory] as

select Inventory.Id as 'Inventory Id',Inventory.InventoryName as'Inventory Name' ,
Inventory.InventoryLocation as'Inventory Location',InventoryCapacity  as'Inventory Capacity'
,
	CASE 
		WHEN InventoryProducts.Quantity IS NOT NULL 
		THEN InventoryProducts.Quantity
		ELSE 0
		END as 'Products Quantity'
		,
Inventory.Available
,Categories.CategoryName as 'Category Name'
from Inventory 
left outer join Categories on Inventory.CategoriesId = Categories.Id
LEFT JOIN InventoryProducts ip ON Inventory.Id = ip.InventoryId
LEFT JOIN Products p ON ip.ProductId = p.Id
LEFT JOIN InventoryProducts  ON Inventory.Id = InventoryProducts.InventoryId
AND p.Id = InventoryProducts.ProductId

GO
/****** Object:  StoredProcedure [dbo].[selectInventoryById]    Script Date: 11/6/2023 10:44:35 PM ******/
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
/****** Object:  StoredProcedure [dbo].[selectInventoryComboBoxId]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure  [dbo].[selectInventoryComboBoxId] @name varchar(50)
as
select Inventory.Id from Inventory
where Inventory.InventoryName = @name

GO
/****** Object:  StoredProcedure [dbo].[selectInventoryProducts]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[selectInventoryProducts] @id int as

select Products.Id as 'Products Id'
,Products.ProductName as 'Products Name'
,InventoryProducts.Quantity as 'Quantity'
,Products.QuantitySold as 'Sold'
,Products.Available as 'Available'
,Products.SellPrice as 'Sell Price'
,Products.BuyPrice as 'Buy Price'
,Products.EntryDate as 'Entry Date'
,Products.ExpirationDate as 'Ex Date'
,Categories.CategoryName as 'Category'
,Inventory.InventoryName as 'Inventory',
Suppliers.Name as 'Suppliers'
from Products 
JOIN InventoryProducts ON Products.Id = InventoryProducts.ProductId
JOIN Inventory ON InventoryProducts.InventoryId = Inventory.Id
left outer join Categories on Products.CategoryId = Categories.Id
left outer join Suppliers on Products.SupplierId = Suppliers.Id
WHERE InventoryId = @id

GO
/****** Object:  StoredProcedure [dbo].[selectOrders]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[selectOrders] as

select Orders.Id,Products.ProductName,Inventory.InventoryName,Orders.OrderedQuantity,Orders.OrderDate,
Orders.DeliveryStatus,Orders.OrderedQuantity * Products.BuyPrice as 'Total Price'
from Orders 
left outer join Products on Orders.ProductId = Products.Id
left outer join Inventory on Orders.InventoryId = Inventory.Id


GO
/****** Object:  StoredProcedure [dbo].[selectOrdersById]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[selectOrdersById] @id int
as
select Products.ProductName,Orders.OrderedQuantity,Customers.Name AS 'Customer name'
,Orders.DeliveryStatus,
CASE 
	WHEN Inventory.Id IS NOT NULL 
	THEN Inventory.Id
	ELSE 0
	END
,Orders.OrderDate
from Orders 
left outer join Products on Orders.ProductId = Products.Id
left outer join Inventory on Orders.InventoryId = Inventory.Id
left outer join Customers on Orders.CustomerId = Customers.Id
where Orders.Id = @id

GO
/****** Object:  StoredProcedure [dbo].[selectProduct]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[selectProduct] as

select Products.Id as 'Products Id'
,Products.ProductName as 'Products Name'
,Products.Quantity as 'Quantity'
,Products.QuantitySold as 'Sold'
,Products.Available as 'Available'
,Products.SellPrice as 'Sell Price'
,Products.BuyPrice as 'Buy Price'
,Products.EntryDate as 'Entry Date'
,Products.ExpirationDate as 'Ex Date'
,Categories.CategoryName as 'Category'
,Inventory.InventoryName as 'Inventory',
Suppliers.Name as 'Suppliers'
from Products 
JOIN InventoryProducts ON Products.Id = InventoryProducts.ProductId
JOIN Inventory ON InventoryProducts.InventoryId = Inventory.Id
left outer join Categories on Products.CategoryId = Categories.Id
left outer join Suppliers on Products.SupplierId = Suppliers.Id

GO
/****** Object:  StoredProcedure [dbo].[selectProductComboBoxId]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[selectProductComboBoxId] @name varchar(50)
as
select Products.Id from Products
where Products.ProductName =@name

GO
/****** Object:  StoredProcedure [dbo].[selectProductsById]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure  [dbo].[selectProductsById] @id int
as
select Products.ProductName,Products.Quantity,Products.SellPrice,Products.BuyPrice,
Products.EntryDate,Products.ExpirationDate,Categories.CategoryName,
Inventory.InventoryName,Suppliers.Name as 'Suppliers Name'
from Products left outer join Categories on Products.CategoryId = Categories.Id
left outer join Suppliers on Products.SupplierId = Suppliers.Id
JOIN InventoryProducts ON Products.Id = InventoryProducts.ProductId
JOIN Inventory ON InventoryProducts.InventoryId = Inventory.Id
where Products.Id = @id

GO
/****** Object:  StoredProcedure [dbo].[selectSupplierById]    Script Date: 11/6/2023 10:44:35 PM ******/
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
/****** Object:  StoredProcedure [dbo].[selectSuppliers]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[selectSuppliers] as
select Suppliers.Id,Suppliers.Name,Suppliers.PhoneNum
,Suppliers.Email,Products.ProductName 
from Suppliers left outer join Products on Suppliers.Id = Products.SupplierId

GO
/****** Object:  StoredProcedure [dbo].[SelectToInventoryOrderedCbx]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SelectToInventoryOrderedCbx]
as 
BEGIN
	select Inventory.Id,Inventory.InventoryName,
		CASE 
			WHEN InventoryProducts.Quantity IS NOT NULL 
			THEN InventoryProducts.Quantity
			ELSE 0
			END as 'Products Quantity',
	Products.ProductName

	from Inventory 
	JOIN InventoryProducts ON Inventory.Id = InventoryProducts.InventoryId
	JOIN Products  ON InventoryProducts.ProductId = Products.Id
	LEFT JOIN InventoryProducts ip ON Inventory.Id = ip.InventoryId
	LEFT JOIN Products p ON ip.ProductId = p.Id
	LEFT JOIN InventoryProducts inventProd  ON Inventory.Id = inventProd.InventoryId
	AND p.Id = inventProd.ProductId
	
END
GO
/****** Object:  StoredProcedure [dbo].[selectUser]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[selectUser] as
select * from Users

GO
/****** Object:  StoredProcedure [dbo].[selectUserById]    Script Date: 11/6/2023 10:44:35 PM ******/
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
/****** Object:  StoredProcedure [dbo].[supplierComboBox]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[supplierComboBox]
as
select Suppliers.Name from Suppliers

GO
/****** Object:  StoredProcedure [dbo].[supplierComboBoxId]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[supplierComboBoxId] @name varchar(50)
as
select Suppliers.Id from Suppliers
where Suppliers.Name = @name

GO
/****** Object:  StoredProcedure [dbo].[suppliersCount]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[suppliersCount]  as 
select count(id) from Suppliers

GO
/****** Object:  StoredProcedure [dbo].[transfer_product]    Script Date: 11/6/2023 10:44:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---Transfer

CREATE PROC [dbo].[transfer_product] 
@productId INT, @fromInventId INT, @toInventId INT ,@quantity INT 
AS 
BEGIN
	DECLARE @categoryOne varchar(50);
	SELECT @categoryOne = Inventory.CategoriesId
	FROM Inventory 
	where Inventory.Id = @fromInventId;

	DECLARE @categoryTwo varchar(50);
	SELECT @categoryTwo = Inventory.CategoriesId
	FROM Inventory 
	where Inventory.Id = @toInventId;



	IF @categoryTwo is Null
	BEGIN
		
		UPDATE Inventory
		SET CategoriesId = @categoryOne
		WHERE Inventory.Id = @toInventId
	END
	IF NOT EXISTS (
		SELECT 1 
		FROM InventoryProducts
		where InventoryProducts.ProductId = @productId
		AND InventoryProducts.InventoryId = @toInventId
		)
	BEGIN
		INSERT INTO InventoryProducts(InventoryId,ProductId,Quantity)
		VALUES(@toInventId,@productId,@quantity)
	END

	ELSE
	BEGIN
		UPDATE InventoryProducts
		SET Quantity = Quantity + @quantity
		where InventoryId = @toInventId
		AND ProductId = @productId
	END

		UPDATE InventoryProducts
		SET Quantity = Quantity - @quantity
		where InventoryId = @fromInventId
		AND ProductId = @productId 

		UPDATE Inventory
		SET Available = Available + @quantity
		WHERE Id = @fromInventId

		
		UPDATE Inventory
		SET Available = Available - @quantity
		WHERE Id = @toInventId
END

GO
USE [master]
GO
ALTER DATABASE [Inventory_system] SET  READ_WRITE 
GO
