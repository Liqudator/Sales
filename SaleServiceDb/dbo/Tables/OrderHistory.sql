CREATE TABLE [dbo].[OrderHistory] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [ActionType]    NVARCHAR (6) NOT NULL,
    [OperationDate] DATETIME     NOT NULL,
    [OrderDate]     DATETIME     NOT NULL,
    [CustomerId]    INT          NOT NULL,
    [SellerId]      INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

