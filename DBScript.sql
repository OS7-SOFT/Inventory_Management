use Inventory_system
GO
CREATE PROC FullandNearFullInventory
as
select Inventory.InventoryName ,Inventory.Available from Inventory
where Inventory.Available <=100
GO

CREATE PROC	ExpiredProducts
as
SELECT ProductName ,Products.ExpirationDate
FROM Products
WHERE ExpirationDate < DATEADD(DAY, 60, GETDATE());