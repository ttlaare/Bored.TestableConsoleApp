/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

/******* SEED DATA FOR ORDERTYPE TABLE*****/

INSERT [dbo].[OrderItemType] ([Id], [OrderItemTypeName]) VALUES (1,'Food')
INSERT [dbo].[OrderItemType] ([Id], [OrderItemTypeName]) VALUES (2,'Drink')


/******* SEED DATA FOR ORDER TABLE*****/
INSERT [dbo].[OrderItems] ([OrderItemName], [Price],[OrderItemTypeId]) VALUES ('Hamburger',2.95,1)
INSERT [dbo].[OrderItems] ([OrderItemName], [Price],[OrderItemTypeId]) VALUES ('Grilled Sandwich',2.45,1)
INSERT [dbo].[OrderItems] ([OrderItemName], [Price],[OrderItemTypeId]) VALUES ('Cola',1.45,2)
INSERT [dbo].[OrderItems] ([OrderItemName], [Price],[OrderItemTypeId]) VALUES ('Juice',1.95,2)


