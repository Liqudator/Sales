-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
create procedure [dbo].[GetOrderByCity] 
	@city nvarchar(50)
as
begin
	select *			
	from Orders
	where @city in (select Sellers.City 
					from Sellers join Orders on Sellers.Id = Orders.SellerId)
end