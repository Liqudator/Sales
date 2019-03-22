CREATE TABLE [dbo].[Sellers] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [SecondName] NVARCHAR (50) NOT NULL,
    [FirstName]  NVARCHAR (50) NOT NULL,
    [MiddleName] NVARCHAR (50) NOT NULL,
    [City]       NVARCHAR (50) NOT NULL,
    [Comission]  FLOAT (53)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

