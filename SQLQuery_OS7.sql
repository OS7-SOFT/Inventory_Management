

ALTER procedure  [dbo].[addProduct] @productName varchar(50),
@quantity int,@sellPrice money, @buyPrice money,@entryDate date ,@expirationDate date,
@categoryId int,@supplierId int,@inventorId int
as

INSERT INTO Products (ProductName,Quantity,Available,SellPrice,BuyPrice,QuantitySold,EntryDate,ExpirationDate
,CategoryId,InventoryId,SupplierId)
values(@productName,@quantity,@quantity,@sellPrice,@buyPrice,0,@entryDate,@expirationDate
,@categoryId,@inventorId,@supplierId)


ALTER proc [dbo].[addOrder] @productId int,
@orderedQuantity int,@orderDate date,@deliveryStatus varchar(50),@customerId int
as
begin
INSERT INTO Orders(ProductId,OrderedQuantity,OrderDate,DeliveryStatus,CustomerId)
values(@productId,@orderedQuantity,@orderDate,@deliveryStatus,@customerId)

update Products
set Available = Available - @orderedQuantity,
QuantitySold += @orderedQuantity
where 
Id = @productId
end


ALTER procedure [dbo].[selectProduct] as

select Products.Id as 'Products Id'
,Products.ProductName
,Products.Quantity
,Products.Available
,Products.SellPrice,
Products.BuyPrice,
Products.QuantitySold,
Products.EntryDate ,
Products.ExpirationDate,
Categories.CategoryName
,Inventory.InventoryName,
Suppliers.Name as 'Suppliers Name'
from Products left outer join Categories on Products.CategoryId = Categories.Id
left outer join Inventory on Products.InventoryId = Inventory.Id
left outer join Suppliers on Products.SupplierId = Suppliers.Id


ALTER procedure  [dbo].[productComboBox]
as
select Products.ProductName,Products.Available 
from Products


ALTER proc [dbo].[editOrder] @id int,@productId int,
@orderedQuantity int,@orderDate date,@deliveryStatus varchar(50)
,@customerId int
as
begin 
Declare @quantity INT;
select Orders.OrderedQuantity into quantity
from Orders where Orders.Id = @id

update Orders set ProductId =@productId ,
OrderedQuantity =@orderedQuantity ,OrderDate =@orderDate ,
DeliveryStatus = @deliveryStatus, CustomerId =@customerId
where Id =@id

update Products
set Available = (Available + quantity) - @orderedQuantity ,
QuantitySold += (QuantitySold + quantity) -   @orderedQuantity
where 
Id = @productId
end





ALTER PROC [dbo].[editOrder]
    @id INT,
    @productId INT,
    @orderedQuantity INT,
    @orderDate DATE,
    @deliveryStatus VARCHAR(50),
    @customerId INT
AS
BEGIN 
    DECLARE @quantity INT;
    
    -- Retrieve the current ordered quantity from the Orders table
    SELECT @quantity = Orders.OrderedQuantity
    FROM Orders
    WHERE Orders.Id = @id;

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
    IF @deliveryStatus = 'Canceled'
    BEGIN
      UPDATE Products
      SET
            Available = Available + @quantity,
            QuantitySold = QuantitySold - @quantity
      WHERE Id = @productId;
    END
    
    ELSE IF @deliveryStatus = 'Under proccessing'
    BEGIN
        IF @orderedQuantity >= @quantity
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
    END
END