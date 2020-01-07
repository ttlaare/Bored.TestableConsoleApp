CREATE TABLE [dbo].[OrderItemType] (
	[Id]				INT				NOT NULL,
	[OrderItemTypeName]		VARCHAR(256)	NOT NULL,
    CONSTRAINT [PK_OrderItemType] PRIMARY KEY CLUSTERED ([Id] ASC)
);
