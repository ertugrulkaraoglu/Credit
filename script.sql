USE [Credit]
GO
/****** Object:  Table [dbo].[CustomerHistories]    Script Date: 28.08.2019 20:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerHistories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdentityNumber] [nvarchar](11) NOT NULL,
	[CreditResult] [int] NOT NULL,
	[ActualScore] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customers]    Script Date: 28.08.2019 20:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdentityNumber] [nvarchar](11) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[MonthlyIncome] [decimal](18, 2) NOT NULL,
	[PhoneNumber] [nvarchar](11) NOT NULL,
	[CreditLimit] [decimal](18, 2) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomerScores]    Script Date: 28.08.2019 20:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerScores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdentityNumber] [nvarchar](11) NOT NULL,
	[Score] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[CustomerHistories] ON 

GO
INSERT [dbo].[CustomerHistories] ([Id], [IdentityNumber], [CreditResult], [ActualScore]) VALUES (1, N'12345678912', 20, CAST(8000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[CustomerHistories] ([Id], [IdentityNumber], [CreditResult], [ActualScore]) VALUES (2, N'98745621456', 20, CAST(750.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[CustomerHistories] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

GO
INSERT [dbo].[Customers] ([Id], [IdentityNumber], [FirstName], [LastName], [MonthlyIncome], [PhoneNumber], [CreditLimit], [CreationDate]) VALUES (1, N'12345678912', N'Ali', N'Kara', CAST(3500.00 AS Decimal(18, 2)), N'05301234567', CAST(14000.00 AS Decimal(18, 2)), CAST(0x0000AAB4014B07FD AS DateTime))
GO
INSERT [dbo].[Customers] ([Id], [IdentityNumber], [FirstName], [LastName], [MonthlyIncome], [PhoneNumber], [CreditLimit], [CreationDate]) VALUES (2, N'98745621456', N'Zekeriya', N'Ýnci', CAST(8000.00 AS Decimal(18, 2)), N'05301234568', CAST(32000.00 AS Decimal(18, 2)), CAST(0x0000AAB4014B07FD AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerScores] ON 

GO
INSERT [dbo].[CustomerScores] ([Id], [IdentityNumber], [Score]) VALUES (1, N'12345678912', CAST(8000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[CustomerScores] ([Id], [IdentityNumber], [Score]) VALUES (2, N'98745621456', CAST(750.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[CustomerScores] OFF
GO
