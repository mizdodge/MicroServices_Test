USE [by.humbi_transaction]
GO
/****** Object:  Table [dbo].[Transact_Cart]    Script Date: 12/22/2023 11:59:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transact_Cart](
	[ID] [uniqueidentifier] NOT NULL,
	[ItemID] [uniqueidentifier] NOT NULL,
	[Qty] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[UserID] [uniqueidentifier] NOT NULL,
	[IsProcessed] [bit] NOT NULL,
 CONSTRAINT [PK_Transact_Cart] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transact_Processed]    Script Date: 12/22/2023 11:59:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transact_Processed](
	[ID] [uniqueidentifier] NOT NULL,
	[UserID] [uniqueidentifier] NOT NULL,
	[ItemID] [uniqueidentifier] NOT NULL,
	[AddressID] [uniqueidentifier] NOT NULL,
	[Qty] [bigint] NOT NULL,
	[IsComplete] [bit] NOT NULL,
 CONSTRAINT [PK_Transact_Processed] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Transact_Cart] ADD  CONSTRAINT [DF_Transact_Cart_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Transact_Cart] ADD  CONSTRAINT [DF_Transact_Cart_IsProcessed]  DEFAULT ((0)) FOR [IsProcessed]
GO
ALTER TABLE [dbo].[Transact_Processed] ADD  CONSTRAINT [DF_Transact_Processed_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Transact_Processed] ADD  CONSTRAINT [DF_Transact_Processed_IsComplete]  DEFAULT ((0)) FOR [IsComplete]
GO
