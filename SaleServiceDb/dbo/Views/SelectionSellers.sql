create view SelectionSellers 
as
	select S.Id, S.SecondName, S.FirstName, S.MiddleName, S.Comission, 100. * Orders.Sum / S.Comission as SumComission
	from Sellers as S JOIN Orders ON S.Id = Orders.SellerId