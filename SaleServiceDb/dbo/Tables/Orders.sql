CREATE TABLE [dbo].[Orders] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (250) NOT NULL,
    [Sum]         FLOAT (53)     NOT NULL,
    [OrderDate]   DATETIME       NOT NULL,
    [CustomerId]  INT            NULL,
    [SellerId]    INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([Id]),
    FOREIGN KEY ([SellerId]) REFERENCES [dbo].[Sellers] ([Id])
);




GO
create trigger [dbo].[UpdateData] 
   on  [dbo].[Orders] 
   after update
as
	insert into OrderHistory (ActionType, OperationDate, OrderDate, CustomerId, SellerId)
	SELECT 'Update', SYSDATETIME(), OrderDate, CustomerId, SellerId
	FROM inserted
GO
create trigger [dbo].[InsertData] 
   on  [dbo].[Orders] 
   after insert
as
	insert into OrderHistory (ActionType, OperationDate, OrderDate, CustomerId, SellerId)
	SELECT 'Insert', SYSDATETIME(), OrderDate, CustomerId, SellerId
	FROM inserted
GO

create trigger [dbo].[DeleteData] 
   on  [dbo].[Orders] 
   after delete
as
	insert into OrderHistory (ActionType, OperationDate, OrderDate, CustomerId, SellerId)
	SELECT 'Delete', SYSDATETIME(), OrderDate, CustomerId, SellerId
	FROM deleted