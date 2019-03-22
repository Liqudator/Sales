create view SelectionSellers 
as
	select Sellers.Id, Sellers.SecondName, Sellers.FirstName, Sellers.MiddleName, Sellers.Comission, 100. * Orders.Sum / Sellers.Comission as SumComission
	from Sellers JOIN Orders ON Sellers.Id = Orders.SellerId