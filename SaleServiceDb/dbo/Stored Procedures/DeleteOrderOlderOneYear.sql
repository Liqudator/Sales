CREATE PROCEDURE [dbo].[DeleteOrderOlderOneYear]
AS
BEGIN
	delete from Orders where DATEDIFF(YEAR, GETDATE(), OrderDate) < -1
END