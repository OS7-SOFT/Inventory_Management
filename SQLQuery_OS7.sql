

------------------------------------------

ALTER proc [dbo].[addOrder] 
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
------------------------------

ALTER procedure  [dbo].[productComboBox]
as
select Products.ProductName,Products.Available 
from Products
GO

---- making changes in edit order
ALTER PROC [dbo].[editOrder]
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
    
    -- Retrieve the current ordered quantity from the Orders table
    SELECT @quantity = Orders.OrderedQuantity --4
    FROM Orders
    WHERE Orders.Id = @id;

	SELECT @status = Orders.DeliveryStatus
    FROM Orders
    WHERE Orders.Id = @id;

	SELECT @current_Available = Products.Available --4
    FROM Products
    WHERE Products.Id = @productId;
    -- Update the Orders table with the new values
    UPDATE Orders
    SET
        ProductId = @productId,
        OrderedQuantity = @orderedQuantity,
        OrderDate = @orderDate,
        DeliveryStatus = @deliveryStatus,
        CustomerId = @customerId
    WHERE Id = @id;

    -- Update the Products table based on quantity change
    IF @deliveryStatus = 'Canceled' and @status != 'Canceled'
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
		SET Quantity = Quantity - @quantity
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



ALTER procedure [dbo].[addInventory] @inventoryName varchar(50),@categoriesId int,
@inventoryLocation varchar(50),@inventoryCapacity bigint as

INSERT INTO Inventory(InventoryName,CategoriesId,InventoryLocation,InventoryCapacity,Available)
values(@inventoryName,@categoriesId,@inventoryLocation,@inventoryCapacity,@inventoryCapacity)
GO

ALTER procedure  [dbo].[addProduct] @productName varchar(50),
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

ALTER procedure  [dbo].[selectInventory] as
select Inventory.Id as 'Inventory Id',Inventory.InventoryName as'Inventory Name' ,
Inventory.InventoryLocation as'Inventory Location',InventoryCapacity  as'Inventory Capacity',
Inventory.Available
,
sum(Products.Quantity)as 'Products Quantity'
,Categories.CategoryName as 'Category Name'
from Inventory left outer join Categories on Inventory.CategoriesId = Categories.Id
left outer join Products on Inventory.Id=Products.InventoryId
GROUP BY  Inventory.Id,Inventory.InventoryName 
,InventoryCapacity,Inventory.Available,Inventory.InventoryLocation ,Categories.CategoryName;
GO

ALTER procedure  [dbo].[inventoryComboBox]
as
select Inventory.InventoryName ,Inventory.Available
from Inventory
GO




--create Relation M to M between Product and Inventory

CREATE TABLE InventoryProducts (
	InventoryId INT ,
	ProductId INT,

	PRIMARY KEY (InventoryId,ProductId),
	FOREIGN KEY (InventoryId) REFERENCES Inventory(Id),
	FOREIGN KEY (ProductId) REFERENCES Products(Id)

)
GO

ALTER procedure [dbo].[selectProduct] as

select Products.Id as 'Products Id'
,Products.ProductName as 'Products Name'
,Products.Quantity as 'Quantity'
,Products.Available as 'Available'
,Products.QuantitySold as 'Sold'
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

ALTER procedure  [dbo].[selectInventory] as

select Inventory.Id as 'Inventory Id',Inventory.InventoryName as'Inventory Name' ,
Inventory.InventoryLocation as'Inventory Location',InventoryCapacity  as'Inventory Capacity',
Inventory.Available
,Categories.CategoryName as 'Category Name',
	CASE 
		WHEN InventoryProducts.Quantity IS NOT NULL 
		THEN InventoryProducts.Quantity
		ELSE 0
		END as 'Products Quantity'

from Inventory 
left outer join Categories on Inventory.CategoriesId = Categories.Id
LEFT JOIN InventoryProducts ip ON Inventory.Id = ip.InventoryId
LEFT JOIN Products p ON ip.ProductId = p.Id
LEFT JOIN InventoryProducts  ON Inventory.Id = InventoryProducts.InventoryId
AND p.Id = InventoryProducts.ProductId
GO

ALTER procedure  [dbo].[editProduct] @id int, @productName varchar(50),
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

ALTER procedure  [dbo].[editProductQuantityOnInventory] @id int, @productName varchar(50),
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

ALTER procedure [dbo].[deleteProduct] @id int 
as
BEGIN
	DELETE FROM Products
	WHERE Products.Id = @id

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

	DELETE FROM InventoryProducts
	WHERE InventoryProducts.ProductId = @id

END
GO

ALTER procedure  [dbo].[selectProductsById] @id int
as
select Products.ProductName,Products.Quantity,Products.SellPrice,Products.BuyPrice,
Products.EntryDate,Products.ExpirationDate,Categories.CategoryName,
Inventory.InventoryName,Suppliers.Name as 'Suppliers Name'
from Products left outer join Categories on Products.CategoryId = Categories.Id
left outer join Suppliers on Products.SupplierId = Suppliers.Id
JOIN InventoryProducts ON Products.Id = InventoryProducts.ProductId
JOIN Inventory ON InventoryProducts.InventoryId = Inventory.Id
where Products.Id = @id
Go


ALTER proc [dbo].[selectOrders] as

select Orders.Id,Products.ProductName,Orders.OrderedQuantity,Orders.OrderDate,
Orders.DeliveryStatus,Orders.OrderedQuantity * Products.BuyPrice as 'Total Price'
from Orders left outer join Products on Orders.ProductId = Products.Id
GO


CREATE PROC SelectToInventoryOrderedCbx
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

ALTER proc [dbo].[selectOrdersById] @id int
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

ALTER procedure [dbo].[editInventory] @id int, @inventoryName varchar(50),@categoriesId int,
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