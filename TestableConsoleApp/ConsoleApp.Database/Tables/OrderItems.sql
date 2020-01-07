CREATE TABLE [dbo].[OrderItems] (
	[Id]			INT				IDENTITY	(1,1)	NOT NULL,
	[OrderItemName]		VARCHAR(256)	NOT NULL,
	[Price]			FLOAT			NOT NULL,
	[OrderItemTypeId]	INT				NOT NULL,
    CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderItems_OrderItemType] FOREIGN KEY ([OrderItemTypeId]) REFERENCES [dbo].[OrderItemType] ([Id])

);
