USE [StoreBoxDB]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 12/19/2021 4:36:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductOrder]    Script Date: 12/19/2021 4:36:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductOrder](
	[ProductOrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductTypeID] [int] NOT NULL,
 CONSTRAINT [PK_ProductOrder] PRIMARY KEY CLUSTERED 
(
	[ProductOrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductType]    Script Date: 12/19/2021 4:36:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductType](
	[ProductTypeID] [int] IDENTITY(1,1) NOT NULL,
	[ProductTypeName] [nvarchar](max) NULL,
	[Width] [real] NOT NULL,
	[Symbol] [nchar](1) NULL,
 CONSTRAINT [PK_ProducType] PRIMARY KEY CLUSTERED 
(
	[ProductTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderId]) VALUES (10)
INSERT [dbo].[Order] ([OrderId]) VALUES (11)
INSERT [dbo].[Order] ([OrderId]) VALUES (12)
INSERT [dbo].[Order] ([OrderId]) VALUES (13)
INSERT [dbo].[Order] ([OrderId]) VALUES (14)
INSERT [dbo].[Order] ([OrderId]) VALUES (15)
INSERT [dbo].[Order] ([OrderId]) VALUES (16)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductOrder] ON 

INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (1, 10, 1)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (2, 10, 4)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (3, 11, 1)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (4, 11, 3)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (5, 11, 3)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (6, 11, 6)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (7, 12, 1)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (8, 12, 3)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (9, 12, 3)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (10, 12, 6)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (11, 12, 6)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (12, 13, 1)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (13, 13, 3)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (14, 13, 3)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (15, 13, 6)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (16, 13, 6)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (17, 13, 6)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (18, 13, 6)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (19, 13, 6)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (20, 14, 1)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (21, 14, 3)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (22, 14, 3)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (23, 14, 6)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (24, 14, 6)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (25, 14, 6)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (26, 14, 6)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (27, 15, 1)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (28, 15, 3)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (29, 15, 3)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (30, 15, 6)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (31, 15, 6)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (32, 15, 6)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (33, 15, 6)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (34, 15, 6)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (35, 15, 6)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (36, 15, 6)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (37, 15, 6)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (38, 16, 1)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (39, 16, 3)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (40, 16, 3)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (41, 16, 6)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (42, 16, 6)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (43, 16, 6)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (44, 16, 6)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (45, 16, 6)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (46, 16, 6)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (47, 16, 6)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (48, 16, 6)
INSERT [dbo].[ProductOrder] ([ProductOrderId], [OrderId], [ProductTypeID]) VALUES (49, 16, 6)
SET IDENTITY_INSERT [dbo].[ProductOrder] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductType] ON 

INSERT [dbo].[ProductType] ([ProductTypeID], [ProductTypeName], [Width], [Symbol]) VALUES (1, N'photoBook', 19, N'0')
INSERT [dbo].[ProductType] ([ProductTypeID], [ProductTypeName], [Width], [Symbol]) VALUES (3, N'calendar', 10, N'|')
INSERT [dbo].[ProductType] ([ProductTypeID], [ProductTypeName], [Width], [Symbol]) VALUES (4, N'canvas', 16, N'/')
INSERT [dbo].[ProductType] ([ProductTypeID], [ProductTypeName], [Width], [Symbol]) VALUES (5, N'cards', 4.7, N'\')
INSERT [dbo].[ProductType] ([ProductTypeID], [ProductTypeName], [Width], [Symbol]) VALUES (6, N'mug', 94, N'.')
SET IDENTITY_INSERT [dbo].[ProductType] OFF
GO
ALTER TABLE [dbo].[ProductOrder]  WITH CHECK ADD  CONSTRAINT [FK_Order_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
GO
ALTER TABLE [dbo].[ProductOrder] CHECK CONSTRAINT [FK_Order_OrderId]
GO
ALTER TABLE [dbo].[ProductOrder]  WITH CHECK ADD  CONSTRAINT [FK_ProductType_ProductTypeID] FOREIGN KEY([ProductTypeID])
REFERENCES [dbo].[ProductType] ([ProductTypeID])
GO
ALTER TABLE [dbo].[ProductOrder] CHECK CONSTRAINT [FK_ProductType_ProductTypeID]
GO
