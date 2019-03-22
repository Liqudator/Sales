CREATE PROCEDURE DeleteOrderHistoreOlderOneYear
AS
BEGIN
	delete from OrderHistory where DATEDIFF(YEAR, GETDATE(), OperationDate) < -1
END