

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