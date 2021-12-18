USE [StoreBoxDB]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 12/18/2021 1:39:04 AM ******/
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
/****** Object:  Table [dbo].[ProductOrder]    Script Date: 12/18/2021 1:39:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductOrder](
	[OrderId] [int] NOT NULL,
	[ProductTypeID] [int] NOT NULL,
 CONSTRAINT [PK_ProductOrder] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[ProductTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProducType]    Script Date: 12/18/2021 1:39:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProducType](
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
ALTER TABLE [dbo].[ProductOrder]  WITH CHECK ADD  CONSTRAINT [FK_ProductOrder_Order_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductOrder] CHECK CONSTRAINT [FK_ProductOrder_Order_OrderId]
GO
ALTER TABLE [dbo].[ProductOrder]  WITH CHECK ADD  CONSTRAINT [FK_ProductOrder_ProducType_ProductTypeID] FOREIGN KEY([ProductTypeID])
REFERENCES [dbo].[ProducType] ([ProductTypeID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductOrder] CHECK CONSTRAINT [FK_ProductOrder_ProducType_ProductTypeID]
GO
