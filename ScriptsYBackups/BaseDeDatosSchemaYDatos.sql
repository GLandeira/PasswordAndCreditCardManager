USE [DomainDBContext]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 17/6/2021 17:45:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[UserCategory_UserCategoryID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CreditCards]    Script Date: 17/6/2021 17:45:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditCards](
	[CreditCardID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Type] [int] NOT NULL,
	[Number] [nvarchar](max) NULL,
	[SecurityCode] [nvarchar](max) NULL,
	[ValidDue] [datetime] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[Category_CategoryID] [int] NULL,
	[UserCreditCard_UserCreditCardID] [int] NOT NULL,
	[DataBreach_DataBreachID] [int] NULL,
 CONSTRAINT [PK_dbo.CreditCards] PRIMARY KEY CLUSTERED 
(
	[CreditCardID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DataBreaches]    Script Date: 17/6/2021 17:45:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataBreaches](
	[DataBreachID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[UserDataBreaches_UserDataBreachesID] [int] NULL,
 CONSTRAINT [PK_dbo.DataBreaches] PRIMARY KEY CLUSTERED 
(
	[DataBreachID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PasswordHistories]    Script Date: 17/6/2021 17:45:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PasswordHistories](
	[PasswordHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[BreachedPasswordString] [nvarchar](max) NULL,
	[DataBreach_DataBreachID] [int] NOT NULL,
	[Password_PasswordID] [int] NULL,
 CONSTRAINT [PK_dbo.PasswordHistories] PRIMARY KEY CLUSTERED 
(
	[PasswordHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passwords]    Script Date: 17/6/2021 17:45:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passwords](
	[PasswordID] [int] IDENTITY(1,1) NOT NULL,
	[PasswordString] [nvarchar](max) NULL,
	[Site] [nvarchar](max) NULL,
	[Username] [nvarchar](max) NULL,
	[LastModification] [datetime] NOT NULL,
	[SecurityLevel] [int] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[Category_CategoryID] [int] NULL,
	[UserPassword_UserPasswordID] [int] NOT NULL,
	[PasswordIV] [varbinary](max) NULL,
	[PasswordKey] [varbinary](max) NULL,
 CONSTRAINT [PK_dbo.Passwords] PRIMARY KEY CLUSTERED 
(
	[PasswordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PasswordUsers]    Script Date: 17/6/2021 17:45:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PasswordUsers](
	[Password_PasswordID] [int] NOT NULL,
	[User_UserID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.PasswordUsers] PRIMARY KEY CLUSTERED 
(
	[Password_PasswordID] ASC,
	[User_UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCategories]    Script Date: 17/6/2021 17:45:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCategories](
	[UserCategoryID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.UserCategories] PRIMARY KEY CLUSTERED 
(
	[UserCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCreditCards]    Script Date: 17/6/2021 17:45:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCreditCards](
	[UserCreditCardID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.UserCreditCards] PRIMARY KEY CLUSTERED 
(
	[UserCreditCardID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDataBreaches]    Script Date: 17/6/2021 17:45:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDataBreaches](
	[UserDataBreachesID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.UserDataBreaches] PRIMARY KEY CLUSTERED 
(
	[UserDataBreachesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPasswords]    Script Date: 17/6/2021 17:45:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPasswords](
	[UserPasswordID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.UserPasswords] PRIMARY KEY CLUSTERED 
(
	[UserPasswordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 17/6/2021 17:45:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[MainPassword] [nvarchar](max) NULL,
	[PasswordKeys] [varbinary](max) NULL,
	[PasswordIV] [varbinary](max) NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (1, N'Shared With Me', 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (2, N'Universidad', 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (3, N'Ocio', 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (4, N'Para Aprender', 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (5, N'Streaming', 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (6, N'Otros', 1)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (7, N'Shared With Me', 2)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (8, N'Streaming', 2)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (9, N'Diversion', 2)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (10, N'Universidad', 2)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (11, N'Importantes', 2)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (12, N'Otros', 2)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (13, N'Shared With Me', 3)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (14, N'Juegos', 3)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (15, N'Trabajo', 3)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (16, N'Universidad', 3)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (17, N'Servicios', 3)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (18, N'Aprender', 3)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (19, N'Shared With Me', 4)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (20, N'S. de Comida', 4)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (21, N'Vacaciones', 4)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (22, N'Trabajo', 4)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (23, N'Universidad', 4)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (24, N'Para Comprar', 4)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (25, N'Shared With Me', 5)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (26, N'Trabajo', 5)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (27, N'Expert.com', 5)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (28, N'Desarrollo', 5)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (29, N'Compras', 5)
INSERT [dbo].[Categories] ([CategoryID], [Name], [UserCategory_UserCategoryID]) VALUES (30, N'Otros', 5)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[CreditCards] ON 

INSERT [dbo].[CreditCards] ([CreditCardID], [Name], [Type], [Number], [SecurityCode], [ValidDue], [Notes], [Category_CategoryID], [UserCreditCard_UserCreditCardID], [DataBreach_DataBreachID]) VALUES (1, N'Matias Gonzalez', 0, N'4564231000302190', N'785', CAST(N'2024-09-25T23:59:59.000' AS DateTime), N'', 2, 1, NULL)
INSERT [dbo].[CreditCards] ([CreditCardID], [Name], [Type], [Number], [SecurityCode], [ValidDue], [Notes], [Category_CategoryID], [UserCreditCard_UserCreditCardID], [DataBreach_DataBreachID]) VALUES (2, N'Maria Jose Gonzalez', 0, N'3331241102330003', N'255', CAST(N'2027-02-25T23:59:59.000' AS DateTime), N'', 6, 1, NULL)
INSERT [dbo].[CreditCards] ([CreditCardID], [Name], [Type], [Number], [SecurityCode], [ValidDue], [Notes], [Category_CategoryID], [UserCreditCard_UserCreditCardID], [DataBreach_DataBreachID]) VALUES (3, N'Mario Gonzalez', 1, N'1010200322248091', N'306', CAST(N'2025-05-25T23:59:59.000' AS DateTime), N'', 6, 1, NULL)
INSERT [dbo].[CreditCards] ([CreditCardID], [Name], [Type], [Number], [SecurityCode], [ValidDue], [Notes], [Category_CategoryID], [UserCreditCard_UserCreditCardID], [DataBreach_DataBreachID]) VALUES (4, N'Eugenia Gonzalez', 4, N'9888105623890392', N'928', CAST(N'2022-02-25T23:59:59.000' AS DateTime), N'', 3, 1, NULL)
INSERT [dbo].[CreditCards] ([CreditCardID], [Name], [Type], [Number], [SecurityCode], [ValidDue], [Notes], [Category_CategoryID], [UserCreditCard_UserCreditCardID], [DataBreach_DataBreachID]) VALUES (5, N'Gaston Landeira', 0, N'5667244890022847', N'100', CAST(N'2028-10-25T23:59:59.000' AS DateTime), N'', 11, 2, NULL)
INSERT [dbo].[CreditCards] ([CreditCardID], [Name], [Type], [Number], [SecurityCode], [ValidDue], [Notes], [Category_CategoryID], [UserCreditCard_UserCreditCardID], [DataBreach_DataBreachID]) VALUES (6, N'Rosana Garrone', 0, N'4897000523672003', N'128', CAST(N'2023-09-25T23:59:59.000' AS DateTime), N'', 10, 2, NULL)
INSERT [dbo].[CreditCards] ([CreditCardID], [Name], [Type], [Number], [SecurityCode], [ValidDue], [Notes], [Category_CategoryID], [UserCreditCard_UserCreditCardID], [DataBreach_DataBreachID]) VALUES (7, N'Gonzalo Landeira', 1, N'4999102578529002', N'270', CAST(N'2025-07-25T23:59:59.000' AS DateTime), N'', 11, 2, NULL)
INSERT [dbo].[CreditCards] ([CreditCardID], [Name], [Type], [Number], [SecurityCode], [ValidDue], [Notes], [Category_CategoryID], [UserCreditCard_UserCreditCardID], [DataBreach_DataBreachID]) VALUES (8, N'Noemi Misa', 1, N'2337199019902003', N'998', CAST(N'2027-04-25T23:59:59.000' AS DateTime), N'', 8, 2, NULL)
INSERT [dbo].[CreditCards] ([CreditCardID], [Name], [Type], [Number], [SecurityCode], [ValidDue], [Notes], [Category_CategoryID], [UserCreditCard_UserCreditCardID], [DataBreach_DataBreachID]) VALUES (9, N'Iñaki Etchegaray', 2, N'2444222309850678', N'401', CAST(N'2023-04-25T23:59:59.000' AS DateTime), N'', 15, 3, 1)
INSERT [dbo].[CreditCards] ([CreditCardID], [Name], [Type], [Number], [SecurityCode], [ValidDue], [Notes], [Category_CategoryID], [UserCreditCard_UserCreditCardID], [DataBreach_DataBreachID]) VALUES (10, N'Carlos Etchegaray', 0, N'9033896010012003', N'569', CAST(N'2026-10-25T23:59:59.000' AS DateTime), N'', 15, 3, NULL)
INSERT [dbo].[CreditCards] ([CreditCardID], [Name], [Type], [Number], [SecurityCode], [ValidDue], [Notes], [Category_CategoryID], [UserCreditCard_UserCreditCardID], [DataBreach_DataBreachID]) VALUES (11, N'Pilar Sorhuet', 0, N'4000233167662032', N'903', CAST(N'2024-12-25T23:59:59.000' AS DateTime), N'', 16, 3, NULL)
INSERT [dbo].[CreditCards] ([CreditCardID], [Name], [Type], [Number], [SecurityCode], [ValidDue], [Notes], [Category_CategoryID], [UserCreditCard_UserCreditCardID], [DataBreach_DataBreachID]) VALUES (12, N'Mateo Etchegaray', 1, N'7049174958601205', N'786', CAST(N'2022-08-25T23:59:59.000' AS DateTime), N'', 16, 3, 3)
INSERT [dbo].[CreditCards] ([CreditCardID], [Name], [Type], [Number], [SecurityCode], [ValidDue], [Notes], [Category_CategoryID], [UserCreditCard_UserCreditCardID], [DataBreach_DataBreachID]) VALUES (13, N'Tatiana Martinez', 0, N'4566466623134555', N'231', CAST(N'2021-12-25T23:59:59.000' AS DateTime), N'', 22, 4, NULL)
INSERT [dbo].[CreditCards] ([CreditCardID], [Name], [Type], [Number], [SecurityCode], [ValidDue], [Notes], [Category_CategoryID], [UserCreditCard_UserCreditCardID], [DataBreach_DataBreachID]) VALUES (14, N'Federico Martinez', 4, N'8910425610962589', N'222', CAST(N'2023-11-25T23:59:59.000' AS DateTime), N'', 20, 4, NULL)
INSERT [dbo].[CreditCards] ([CreditCardID], [Name], [Type], [Number], [SecurityCode], [ValidDue], [Notes], [Category_CategoryID], [UserCreditCard_UserCreditCardID], [DataBreach_DataBreachID]) VALUES (15, N'Juan Acosta', 4, N'1123445677789900', N'400', CAST(N'2021-08-25T23:59:59.000' AS DateTime), N'', 23, 4, NULL)
INSERT [dbo].[CreditCards] ([CreditCardID], [Name], [Type], [Number], [SecurityCode], [ValidDue], [Notes], [Category_CategoryID], [UserCreditCard_UserCreditCardID], [DataBreach_DataBreachID]) VALUES (16, N'Federico Martinez', 0, N'4231512562321256', N'102', CAST(N'2022-05-25T23:59:59.000' AS DateTime), N'', 24, 4, NULL)
INSERT [dbo].[CreditCards] ([CreditCardID], [Name], [Type], [Number], [SecurityCode], [ValidDue], [Notes], [Category_CategoryID], [UserCreditCard_UserCreditCardID], [DataBreach_DataBreachID]) VALUES (17, N'Fabian Xenos', 2, N'9999120452604023', N'206', CAST(N'2028-11-25T23:59:59.000' AS DateTime), N'', 26, 5, NULL)
INSERT [dbo].[CreditCards] ([CreditCardID], [Name], [Type], [Number], [SecurityCode], [ValidDue], [Notes], [Category_CategoryID], [UserCreditCard_UserCreditCardID], [DataBreach_DataBreachID]) VALUES (18, N'Tomas Sabia', 1, N'6574125142562131', N'324', CAST(N'2022-01-25T23:59:59.000' AS DateTime), N'', 26, 5, NULL)
INSERT [dbo].[CreditCards] ([CreditCardID], [Name], [Type], [Number], [SecurityCode], [ValidDue], [Notes], [Category_CategoryID], [UserCreditCard_UserCreditCardID], [DataBreach_DataBreachID]) VALUES (19, N'Aldo Radias', 3, N'6910123654377903', N'444', CAST(N'2024-01-25T23:59:59.000' AS DateTime), N'', 28, 5, NULL)
INSERT [dbo].[CreditCards] ([CreditCardID], [Name], [Type], [Number], [SecurityCode], [ValidDue], [Notes], [Category_CategoryID], [UserCreditCard_UserCreditCardID], [DataBreach_DataBreachID]) VALUES (20, N'Zacarias Atulo', 3, N'6819634737627473', N'106', CAST(N'2025-03-25T23:59:59.000' AS DateTime), N'', 29, 5, NULL)
SET IDENTITY_INSERT [dbo].[CreditCards] OFF
GO
SET IDENTITY_INSERT [dbo].[DataBreaches] ON 

INSERT [dbo].[DataBreaches] ([DataBreachID], [Date], [UserDataBreaches_UserDataBreachesID]) VALUES (1, CAST(N'2021-06-17T19:39:55.547' AS DateTime), 3)
INSERT [dbo].[DataBreaches] ([DataBreachID], [Date], [UserDataBreaches_UserDataBreachesID]) VALUES (2, CAST(N'2021-06-17T18:41:10.337' AS DateTime), 3)
INSERT [dbo].[DataBreaches] ([DataBreachID], [Date], [UserDataBreaches_UserDataBreachesID]) VALUES (3, CAST(N'2021-06-17T17:41:52.530' AS DateTime), 3)
SET IDENTITY_INSERT [dbo].[DataBreaches] OFF
GO
SET IDENTITY_INSERT [dbo].[PasswordHistories] ON 

INSERT [dbo].[PasswordHistories] ([PasswordHistoryID], [BreachedPasswordString], [DataBreach_DataBreachID], [Password_PasswordID]) VALUES (1, N'fini7474', 1, 51)
INSERT [dbo].[PasswordHistories] ([PasswordHistoryID], [BreachedPasswordString], [DataBreach_DataBreachID], [Password_PasswordID]) VALUES (2, N'Jj3:aA~?v0VVv#8lsdL@SD]F', 1, 66)
INSERT [dbo].[PasswordHistories] ([PasswordHistoryID], [BreachedPasswordString], [DataBreach_DataBreachID], [Password_PasswordID]) VALUES (3, N'inaki7474Mili', 2, 73)
INSERT [dbo].[PasswordHistories] ([PasswordHistoryID], [BreachedPasswordString], [DataBreach_DataBreachID], [Password_PasswordID]) VALUES (4, N'inaki7474Mili', 2, 74)
INSERT [dbo].[PasswordHistories] ([PasswordHistoryID], [BreachedPasswordString], [DataBreach_DataBreachID], [Password_PasswordID]) VALUES (5, N'inaki7474Mili', 2, 75)
SET IDENTITY_INSERT [dbo].[PasswordHistories] OFF
GO
SET IDENTITY_INSERT [dbo].[Passwords] ON 

INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (1, N'QxTd5ZTz9wI9IxuKJ2cws/B4KtFLeFKelGTU394pIEg=', N'www.ort.edu.uy', N'MatixitaM27', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 0, N'', 2, 1, 0x65680AD65253F3EF216874DCB7CB57F3EE8D12398B99049C8153B7CD5F34649D, 0xA21994E40C2B2222373FBE291C4C04665C348913250570B0F8BC89DB2933BA86)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (2, N'1MWQd/2b0u0M6v3NP6zR2XO9Jqbd6r3jrT1TseyUIiA=', N'gestion.ort.edu.uy', N'MatixitaM', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 2, 1, 0x8EB9D4F3A8F6C93394B1C043CC990B84061477FED60085377285694B7B5C85F0, 0x34EF156689BC8BE89E6246E5DDD018FB5DA0D1DA2D7287A4121C46FEF6B65DB4)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (3, N'yPRJ1QJ+NfSRW/RD/NmqVmv3+Mu/ouTNqxb3SyDnmtA=', N'ucla.com', N'MatixitaM', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 2, 1, 0xBE327D18BC5838E25A06B3D911D24804EF6AE14753C5A97C4D103FCB3BF09498, 0x8E3244CB34AB8684F29A21CEF7FA269064B9A0C87BD805E65B0ED36E3F07AAB4)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (4, N'EydjlYxmfAKC1vXIsv29KBvHnpBDliN7IX6OWszlwIE7vJuxTzi8KzkmrovT6ne82RpDk+ztVDxxr9GU7xkguw==', N'camscanner.com', N'MatixitaM', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 3, N'', 2, 1, 0x4D31F53AF4A5A620A7841994127D22649209D14869B4DE2C613F673FD0FEF59B, 0xD8B8546FEA75ECE1ECE680E0828CF405D6AA5C9212CF97B69035087DCE4D0185)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (5, N'3AVbJGtD8UZCW13x0yD+5GJiizuW2A4uE5AWGgfkL2I=', N'www.pdfs.com', N'MatixitaM', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 2, 1, 0xC4DF636A6E2A97C87674237F8F5FB03F0075566AEC09E5E57AC2722BBE78A97D, 0x3AF044C542C8DBD1CD57E8A105CA599BF9E66A072C23C38EDF0393498316000D)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (6, N'suKd8qiMRQaGkj0j0l4+ge9HfVi6kr3nPPBhesFD/kI=', N'minecraft.com', N'MatixitaM27', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 0, N'', 3, 1, 0xCAB198BEC8E5BCB3A7876F58AB446DDCEFE8B73F44B7CFF8267FB31F929CBACA, 0x529C3A496604C88F89B781DC0CFFB3EA5C705078F0543C9648ECA357BC97CE66)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (7, N'7dY0r5RvxxW/Izf9lM3jW0DDnNinm5Si3Eaj3c6Yi7U=', N'bukkit.com', N'MatixitaM27', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 2, N'', 3, 1, 0x4335FBE74127CE3313D027AFACF40E616C5E4395770A8F625B43CD12E3015EBE, 0xECCD0283AEF9287B4D6932D9637CA4D037BDB1653D6DC21D4405AC92B769020D)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (8, N'ePTA3ViBLOfRnlJiDEM4QEMmgEaWHbOY1WCUwLUXK+E=', N'valve.com', N'matias_27@hotmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 0, N'', 3, 1, 0x92B425B3A11BB6D9840282569135C15704DB55543D619EE1DA9E1F10986C72A7, 0x3B208EEA1E72C4B9F51CEEE2EB1476E2D48ABE91A0616311E04BDB396549B6EF)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (9, N'iYACYHok3ToI7+r6z6fcoZj0uYiUT5UiVY90MUSkQJE=', N'blizzard.com', N'MatixitaM', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 3, 1, 0x14B68B2DBCDB91DDFA8FE5FD94FB1566D82E4A472D846332253EA42A9DA671A8, 0x35B9F180E0E7A10C6D826C27601033C707F1F83D58E3616BB37C48EE8597717B)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (10, N'gimpi4ulkpghrglXkwZyEfAUvtjteJ8POvKa2tejUhHY/rwa8WYfzm3DCMTrD3PXTMLIbJu37y74vpd7wUHR4w==', N'www.kioss.com', N'MatixitaM', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 4, N'', 3, 1, 0x696D944954D2CA09A355AC6E913C5B17C79E5D7B811A704674FDAE291CF7DDD2, 0x362F96669F67585B937CAE27D2E427FAB1333EBFD6C3942895B03580F4F05EFF)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (11, N'7sIBBcDst2gtfgbHAIWMcloveunOdCTBtwBjTH+ADRFCcqaaeocp/7KssLn27GOnljmudl3cCcgHMPyLJhH1ww==', N'www.lokz.com', N'MatixitaM', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 3, N'', 4, 1, 0x286AA77F40764C8502A741B4F57CB530A177C8E4BDF91AB0FC805EA21B9A9374, 0x23E313A1ADF53CED2BCA944A29640F7AB3ADE076698FBA0E4C58C63332F2AB65)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (12, N'w6MnMNS0f8Bn6/IpJ7ARyEZDTeVWGv5B1mpfX/LaBnQ=', N'www.learn.com', N'MatixitaM', CAST(N'2021-06-17T19:01:38.007' AS DateTime), 3, N'', 4, 1, 0xB6A8C9D4E9CF02102140A36DFAA98A1F567D947002CBE70B293618B85670C8AF, 0x5C9377057BCB572F5B55215369C7A4C444A75F2B65EC91A813C26609789DB0C7)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (13, N'8hBzI5FIphuUYlOacFDI7CT619WCw1KwJ4bvSgiSRWI=', N'diy.org', N'matias27@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 4, 1, 0x094B8B8343FB91F33F09C50AD2FB3F9470FE281D86E322BC13D2A189CA54D542, 0xC2CACB9DB6FEC54F1633AF16AED09A022695B77F7FD1D1B8AD323384BCC50980)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (14, N'45oG00CXxw48+kuamQkhfm0GHsXzrXk4vVXShRhFvGU=', N'passcrypt.org.com', N'MatixitaM27', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 0, N'', 4, 1, 0xE11B8A5FA1C9E4C1ADA162296B3F399BF83BFEE889ED379419B8DC84B08BE9BB, 0x67B6E59B73492FBDE32CA8314D3AFED22CAE6BFB7E67F1715AA339A40D2CC513)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (15, N'hMxLnpYpEn9yujBUd+NdoLErbMrnJrQoQNcuAbbbyFMbQd+D9tN17r4ED0/mJNc0MvcJsHdLT1RrPY2LA7jYhw==', N'brilliantly.com', N'MatixitaM27', CAST(N'2021-06-17T19:01:58.700' AS DateTime), 2, N'', 4, 1, 0x9BB352D406E63501D6752E540360F5D677CDA44C782A5AF89A25D8A1D27DEF15, 0x43765BD0E97A3EE6784ABB5BFB539264AD9C4FECD396BE33CB3E876D903948B1)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (16, N'WpMcFw2c9wbmgNPGq7j7fGkDHajq0AFWjHqMzOIRTKU=', N'twitch.tv', N'MatixitaM27', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 0, N'', 5, 1, 0x4EEE53CACEBAE72F248FA4A53922B3740C0DBCBEC92962705324CBC42D74E155, 0x41F86399BC4EC6FB8F23EE8A1666868CB2D7A3B881F4866A34D8939F102A5D2E)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (17, N'tol+fz30TBU1VtpkE83RYIy+1KPG/ELUK5tDMkrzGa8=', N'youtube.com', N'MatixitaM', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 5, 1, 0xFED897AB57F72AC4CF0B2AE55F72AABFC00CBB1D3BC806B835676B2614B662D5, 0x509B935548355F7C2D59651FF8B09A3677A3D36AE715A666EE3BA3D6E03EC98C)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (18, N'wVq+O+ZKpfms4slzdmgY+ASPIzmq8mKkUp4VVnxp4X8=', N'streaming.com', N'MatixitaM', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 5, 1, 0x7CB50911E06D244D65A0A85378B200F7F8A509844F9AA2F9FB648DFAF79F45D7, 0xC7A65CDB61A15B1E93FB47994ED894449CA70EF7A065F40E1CF3A43414DDC942)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (19, N'nc022iroJ4Y4tp+nUsI/L+8ArQxVb1g5EkLzk6TZm7E=', N'steam.com', N'MatixitaM', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 4, N'', 5, 1, 0xD197FD251DF1D794B81D1B4D26467D2E60E93D3A0E3746FD9C30E2D361672357, 0x4BE86A0CDA8A9AD82BE1360A0531EFD70359A938EDDDB6521D60C2E1AD699C59)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (20, N'abbK19gbDM/u4ifyZXo+wKonAQ7mV3XSKnJIx0vo809TS5zjAOCEn7M0cWfLiyuYTZ9LdkGbvBF8mtPvwmdLAA==', N'sttuts.org', N'MatixitaM', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 4, N'', 5, 1, 0x1725C12111A17EEE673E525D697449EB4AC6B5068EA1A0A1F5E980D8AB2EEDE1, 0x35FFD7FC5D0F19888DB3AA7EDCD2F877C5937B5C288966A11459E17F72CE24DC)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (21, N'Rmd077/kHSyp2ZI3MSZInGpavGduaL0hFIdcd7e1hKk1Jnl8Zi/ZO6Zt19XzUZol6tx+l6hU06NG+2+ZSpU6YQ==', N'thot.com', N'matias27@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 2, N'', 6, 1, 0x168AFA092D7110BE4BC0B51CEE7C3A6403F0B3D86CFE7932F76DA2064A6509A7, 0xA199EA727FBC2CBFC167C8D4442CC376B37306E52AC1DDA880F167B3231BBC65)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (22, N'oF90kzOHkXQvGuwPGpRGZfKrpNHsW8x1nlKw2OXD7hdkjwPah3QT0Qn/zI6JeGIgDinoQCDGi5LzkOu86rxryw==', N'wikipedia.com', N'matias27@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 3, N'', 6, 1, 0x96EE9CC48572459B5F1C2B2D9723071486CB1FCFABC040A05CAC7D5586DD8514, 0x2D34819E03AE591F4349D8CC3393551DC3152F56A7A1ECBE94AFA497CCA1EC5A)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (23, N'hsi0QGZV6qBgg6GlO2awOjnvGOMKAc9UT0GUNh/97Qo=', N'bukkforums.com', N'MatixitaM27', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 6, 1, 0xA46BB105425B05D37F03CC61FE1DD0931F829C1B435CFACA6866D9B23B839F8D, 0xE942CC56A22E83D270CC0216105CD81DCDB3CFF825182594875DFDC1AE4DAA78)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (24, N'wcd+OTkCNpA0nCp96jYgCzOit6QsX3SSwXtZ1mXgQgI=', N'gmail.com', N'matias27@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 6, 1, 0x77012E2B9ECBB2F774D7C0BAE3B7A3891B0BA4EA9470F9CA43257FE53C7442D4, 0xDCFC5C6B76F52207177E80E0D6E2D4373B82A9BC9BFF76148C8793FC1A662A2A)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (25, N'IX6NM+bNm/q8MeWN+0yMSH8jW7trwQwgWmw0w3XRsh218EP2fl+3Bw9QF6I8BZ0+rhRetZm72f51+M7bMkbjWQ==', N'outlook.com', N'matias_27@hotmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 4, N'', 6, 1, 0x13460D9925B21A22C9A3C5F4045A15D874B856E59E45B6D8045564641EB6AE37, 0x868B8A1D59E0854939D4DE6A1ABE3FC87878A66FF6A9699DB61C8896DF88ED53)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (26, N'tkkI4cGMKMDdeA4jHFPgwf4tdKfjCcVXaCn3OMHUAgw=', N'twitch.tv', N'GLandeira', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 0, N'', 8, 2, 0x05C87E8946CE819E0E80A2D33AA1782E69AFA007D1C363DED6FA01F170DAC7A7, 0x8F53AFF0FC2D16A2F116FD5E3CBD6CD94C0A88419250DBFCD16CFF846CE741C5)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (27, N'3dOkq5ss3pNeRObIzZd3S787vLRhlFj5IS1y4L3x08Q=', N'youtube.com', N'GLandeira', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 8, 2, 0xBD30E8439FEF7243DC2ADD3F7B038044AE36764C7EF14ADB5C5F137DD2074EBE, 0x0913320A56759F3DBE504385FB07D4F5BB907821222BD2A19127180489265B93)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (28, N'NxKIZbV4oktA7DU4+yq2OAjGUET2HnyQtu4Pwe6PmTk=', N'streaming.com', N'GLandeira', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 0, N'', 8, 2, 0xB10A4137FDB72F1A668B110D2C53423309602E824309085A8C0882119A3FA2B7, 0x25BF40FF4C3817DF280F0B81471FF9E1AE57224F1CAAF4EDAEBF85C5535683C7)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (29, N'ogfzYz92VKu+1g919xukuAa/sFVei0j642KjRYxQKgo=', N'stream.com', N'GLandeira', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 8, 2, 0xE1F40A4C4721A3A3D69AABAEFC6449E6526B5DA81257906F07193416A83EBC2F, 0x3EBBAC9EE578DAE06A1AA378D7FEC388E0A713EDDBFF8B73DD07FFF7E7230C2F)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (30, N'6rOBrdQR7ijCAPvOsvajGHFk3VLYxmyPd88dmWLGp1Y=', N'sttuts.org', N'GLandeira', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 8, 2, 0xD603437B144BFF28A574D9A401944BDF2C82B2995F8C0F993A89218E6F3D5A89, 0x3B336829202A17A5CA459C45FA37399F4478C82791DEFA44FA2CA3A2F4135227)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (31, N'M3Kw64u9VUy9gGeS6M+J4EAkc6DJxGdry88unJXHGb+ne83UAF6na0LC17hgtcg/nNp1dQSlRmk6EibfI9sm9A==', N'leagueoflegends.com', N'GLandeira', CAST(N'2021-06-17T19:09:02.217' AS DateTime), 4, N'', 9, 2, 0xDAE46D83C8D3F547F6975789546E5F6A5E514BC822FD078F12EE274247752EC0, 0xC8FC773C0E53AE69A5F5DA800EC95146F3ED393F108B2975184106C62C624073)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (32, N'+DisB2KDsUuNg3NGNo8JAcQwGRIOUfTrvEV5XsxGecg=', N'steam.com', N'GLandeira', CAST(N'2021-06-17T19:09:11.393' AS DateTime), 1, N'', 9, 2, 0x7B1CCE9BF3F5D68155CE73271500245684BD692016CFA28695532F7CFED9C1EA, 0x7A7F1031DAF16C0E8E44A140FEC013D73D10E7542FF1C8666643C675993B39A9)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (33, N'RryF5JWKXrdzjREjGSZzzt1B92w1rZa9Jh40yd2UqBg=', N'gamesdonequick.com', N'GLandeira', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 9, 2, 0x6A378CD783CFAD4BF97014CC9258AA8463C7BD7FB7A0ABEDD5517E043B05E4A9, 0x1D1D4B5CEBD9F0FA64A752F4DEEA1E14378DD6C4450CCC972858E268695DD305)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (34, N'YTwwdZKYnazc23JtmC7PNXtYVheOQIJX4WtWvYWXi/4=', N'agar.io', N'GLandeira', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 3, N'', 9, 2, 0x80185696CAE12193B09483527727E7A360631DBDC7164050EB091894F5A3AAA1, 0xC8B2314AAF1E7A1181380E416CB992676413A526E66A91E5CB5703E2E0F831F2)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (35, N'zJokh8eXwjMAdnnIC28zyLlYVhE2JpOa62iV9EwMzMs=', N'ttf.org.com', N'GLandeira', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 9, 2, 0x4724C46705F382A0F8A425C79E6E6A6026C0719D8E6C752339FEA4BC83255DF8, 0x0E3AB98D322D761367356751A31514BB20976DE1B0CF51FDED69ECD2726E08E6)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (36, N'VRsJKYjnjAoiVmyvPSRWqgByTys9D3+3YMlBMLpeCdU=', N'www.ort.edu.uy', N'gastonlandeira@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 0, N'', 10, 2, 0x10D5E5527E17F3659BD8681C7A5C36889A1A7CD60C731353C954FE58836367EB, 0x526CA42A88B4F52FCABCA4D9F3D24C290F16ECE3F6EFAD2D6CEEA07317D03E5E)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (37, N'MxqmuIZky31WznRE3TYXyC7M9agMdEt0/tSQbYDAGLU=', N'gestion.ort.edu.uy', N'gastonlandeira@gmail.com', CAST(N'2021-06-17T19:10:20.097' AS DateTime), 1, N'', 10, 2, 0x88B4C7E006D44D4F1E74ADE24582DF7D3A799C457B188364924C3F49A8818D1A, 0x9C405EE6FAB308F052E33258C297DF328D47E9069674598F9DDEB68795875847)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (38, N'vEF6KceF9vBRz2h4JQIf/4ikQRU4O0ctTM6fo1fWBkoEGP1wE25m5sDGz1rkr6PztvJIGecOWnJlLLzV48zVHQ==', N'ucla.com', N'gastonlandeira@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 3, N'', 10, 2, 0x3470B44634A194E81D6BA684CE288645C21B0C04936C655F3D202D63A538C43C, 0x1C93E723B6460743D5349A7B3BFAD6AAACA4422C97A1CA6EC0F2AE0043C464BA)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (39, N'+fEbB8BQr10/OyktjbC3pBwi2+GRazNG+GDlxMhGkGw=', N'camscanner.com', N'gastonlandeira@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 10, 2, 0x837DC6A2507C8524BF47C3DEEB7B478DFAF18A9AB334F5FAE64FD13AA912CC5D, 0x38D2FA3B2E6EDD644571A8905AAA301B5617E307A99FE8F2413C70A4D97BADEE)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (40, N'CMrjWRSXnOz7wwUQ0T9lmyoNrxasaqadj7/PTJdEp7A=', N'www.pdfs.com', N'gastonlandeira@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 8, 2, 0xF55F1DBC63A2A1E64A69CF010F58FDEB7266DB3AC01CE4B614E715065B9FAD73, 0x2082714CB3A9566859CA8038BD856D47490E7922F51392D5C01E2571056B8B0C)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (41, N'E8kiTMlIMdXvG73vnU637yB28u1gfrSDiN7N9uTVOl8ut8tuLJgmWqRd1k9Lfji/7do4/AwEpPQrkkTfXC7MNw==', N'www.santander.com', N'gastonlandeira@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 4, N'', 11, 2, 0x4F94DEB15C7C1E32445FDDCAED40B2135F74A0C1904A8F7D5FB50FA814AA749D, 0xD5E057C6682BE3C532BE336D44470E39556C97C8EAE077EE64D78CF9DA45C34B)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (42, N'Vr0mrGlkVNIPp3Rm5PhSbHs31cciNfej/tVI3CfKjgI=', N'www.pedidosya.com.uy', N'gastonlandeira@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 11, 2, 0x71FD240FDDCCBA25408A03EA4B8EB3E8D9DA5B40E5529EAFCDAEA856CFDC8E07, 0xFE06372964C75B3F40F8B3ED6076E80AE1F876E873A459ADC43A7AACF3D7ABA1)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (43, N'+Bluj+pVR0MbCrYSJnQOJ/LGVRWz8ew7KaSoGXtaH70=', N'www.mercadolibre.com', N'gastonlandeira@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 11, 2, 0x4D1AF54792D153D53E70D4EFC8F8C85BB495624833408B491B2B6FFD79D6CE0C, 0x80F326A30A5532D80988FDE608B2C8F9E52C9336BC51E856C3269AA52CDF8086)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (44, N'Q9WtVHwxUl7YPeRu19iXWDWzY1IzUjdpemN/EAZkw57bsNEHcE2MTbrDjtDz4cY9TUbW7qQtm5MVNTnB3TGoeQ==', N'www.itaulink.com', N'gastonlandeira@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 2, N'', 11, 2, 0x590FE8D922560F7C66C8C88306ABF56A0CC64EEC2E547D11666D75DAC42EDD3A, 0x6E1A34FCD6C3B6352A7516C4CC50E721466300407E84A1493B40717F889CA8E7)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (45, N'RVNyMtPEGYULQsOe9+t1qk49UoMEqc1MGF/HtZ+jfYs=', N'www.tirados.com.uy', N'gastonlandeira@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 11, 2, 0x007331C87E43B3A18DD2E8F03DD8DB8BE96B86FC32856D286F6CB81AF69001D4, 0x2638644978E816A579FCF86F8BE9610B00A01333A6DBC52B5560C662E9707A1C)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (46, N'drWFUxP+Meu3ZL99bFXym1vHQt8jtJuItvBXzmDtg1Q=', N'www.mybreaches.com', N'GLandeira02', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 12, 2, 0x7569AB3EA3BA563772F969DCB8172440D3B6D6A8134FD507F1872B41D65DDD85, 0x60A412802E42441883C8866E24F52BE2D0327143AB11F3C2FF1B76F68EF9F688)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (47, N'+Uj4VqUdhD2hLl1EhPRlwU4aMyQyvEVgOP+7uKLlShU=', N'www.comidaahora.com', N'GLandeira02', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 12, 2, 0x203F1C2B6ED5295CC026876527EE9AB3C08BCECB3BE42A7FB70147E4DC452696, 0xC0D0733BAD1FAA3EAABF9BA1249F826DB7A197E776AC9223F68D41956E4578EB)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (48, N'/OKqid8MfcJuaM5galUO6JaplnlC0DG2BaVwzE1qrMNC470WwgoBULQ6EIxjMLyNnCft1bDlMvjdWwStfJ9N4A==', N'www.psnow.com', N'GLandeira', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 2, N'', 12, 2, 0x70B93174657DB342FD7EAD1264B00ABA36E53C0BD1870C365D3C0202B135116A, 0xB0A94DDEE203127B99BA535D37F6D3BCEA624173A14980DFE9FC4238B3176125)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (49, N'y7CQRxMiy0gBj2imXNyXFK6BQNUS+xI7MIoAjjTA42Y=', N'www.myblog.com', N'GLandeira02www.myblog.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 12, 2, 0x5BBB57EC82214F03239B9765C3D1B07D7192D84AC1D5BB5D57504030007BB7E3, 0x3757EFD167AA3D50803DDC645CF724160298AF2300033AABDD544B4D96A70EA6)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (50, N'v4SN2PW4UctaDAh155tkSIz2KXXO4asfXax6Y/rCNB0=', N'www.blogger.com', N'GLandeira02', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 12, 2, 0xFCB857BF5581E51703BC95541E0E82616B4C81DF6BF26415FAD5860C5752E7DB, 0xD44AD68AA92DBE3C1A58121EEE65D4B022A0EA11CA93CF4C6F1D29B84D87EDCC)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (51, N'+w1bkWsmXoVAxHdK7nWb8FHW2SAG8b+w2Dmid6pfVTA=', N'www.blizzard.com', N'SleepyWolfie', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 14, 3, 0x7CD973FBF54BE6B9E18728E9E478DD1662E1A96589A82E5D89E2CFF44B02A584, 0x68F671D4391D2861B89B2FDD76209DD0AFE26B1D28EDB5770AB7A13480AE797D)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (52, N'Kn0F6NgOvwmQEfa5pnCc7lyDjZBxB8hiI/fBi3wFMQA=', N'www.valve.com', N'SleepyWolfie', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 14, 3, 0xA9CC2E32C28BCF93DC94E9518A5CC06A92D472C840D7C1488902F1B6C6E267B5, 0xFD4FCAF2F6EB407FADE6953F1D5DF0B0D84E115C3F81A48657EB60C569387281)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (53, N'2HgfOxfncEy1ohOPMWBz5hykGwPaye/CUPnuE9QRO8fRYPYoOL5FtvKnj+JdkNEGI/EIxrBdEAsbp8yg5eUGsA==', N'www.steam.com', N'SleepyWolfie', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 4, N'', 14, 3, 0x8543A74D088B424A718E4EAC5ABEF20AA0858C7E93CA75C40506F43BC41BF05A, 0x5D23619BFAF2282B5A448C4C6257C7703468F79E4322C952B739DA05CCE8A186)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (54, N'UElg/1VVaKPwEsBoz2Bch9bZnAcZiRBQgzxsR+YM/zY=', N'www.discord.com', N'SleepyWolfie', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 14, 3, 0x12DE07B872613C6CDFBB4D59326AC3C9F44F3F594D5A86A3E1FD6BFD9B85D7C8, 0xB8EB6A38CC9C6527D7CE7C75449E8D4A611DFE867E7A24566960B8444D14D88B)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (55, N'K5+pMmpPhv9Q1kn6KMnUxRcPuax/FtJjQ4IbAWK8RHo=', N'www.diablo2.com', N'SleepyWolfie74', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 0, N'', 14, 3, 0x3702B3D9644AE906880ACAF279B3687407266A1E2EC96AB862A0C0C68D6837D5, 0xA88538A0D682DA865C96A9DAE7DEED37A3319F56B85B0F75E946011FF307ED89)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (56, N'NeOQAHFS7vkDZFdNbE1ldFlqyYGUROj1FHlhHeFT93Y=', N'www.unity.com', N'inaki.2012@hotmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 15, 3, 0x5873C6424B1D74667D6EA7706767CA45AC24BC73B0544BEAF1BB0936EFBB3213, 0x3E268BDBF5B1FA0C4825E73CC296BAC6EAF8C8866C0BCCEC90A744FF7F85D06A)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (57, N'8JReCLtpmFahkf9A2/gZDUarrL9nw9mnWqoUxWJdXz4=', N'www.stackoverflow.com', N'inaki.2012@hotmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 15, 3, 0x13F8D7BA7B0A925705C6F5E87CC4E180D2AB7889ED601FED79BF67854C9CD305, 0xA2E64C69F45E5F7FF3D6C7E399D7DF6910AFE5DBAD4D1E47B0D3500111833B67)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (58, N'UfTrjHH0sjoPvPvDiXDclV24k0A5XA/16zvxbzy+oTo=', N'www.unityforums.com', N'inaki.2012@hotmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 15, 3, 0x9A12E28FA9D1A3689B8997E911C630C21AEB1645F6539E5A88041C31D319E5D4, 0x930581C7B62CF2B2226AC6BCC96FDCAC822ED43D6CD672BAD9A8468001DB8B9E)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (59, N'lgvJkv9ik+sEeQ8Ui9J9KCYUnxNwLfuAm+dDqiyTY7Q=', N'www.potonunitynetwork.com', N'inaki.2012@hotmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 15, 3, 0x6545A5C79EB751B5617BB1A9C2211817E96799367C33FE203C99369EA6D612E9, 0x471E1D50EEEE8CAEFC645BC2165578506C5447DEFBA3A57F26F87842E099F376)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (60, N'jrKGiGORxHgzxU836GlR8xVO8oxOBudzLMui9XXQd83NNWypxQ7SB7K2ngW84PyUG8JdSnwesZJ0zsPixB/A/w==', N'www.net.com', N'inaki.2012@hotmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 3, N'', 15, 3, 0x94422C3AA95B5DD2B3DD4371254876FF6B359603D230DFF50898C76F4FE80ED6, 0x6593D00D8B2039259D3795E3C5D23363B8773D5F8F9152B73CF5657A89D2EE98)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (61, N't+d+SohMlt9PjvWYroIqe3vXyu+SQBNkay6NpBV0bcGi2Zpo0oY3JYimOnsKN4fy8vXE0lYkP+zbkm0UaBfhbQ==', N'www.ort.edu.uy', N'inaki.2012@hotmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 4, N'', 16, 3, 0xFD5BD723C2C66ADD6F00C053932DC9C27D6087522AD7736C2D8899C0FAB8E320, 0x9EF6A36D5B5E0BA3CB70FAE4D2551875C3129D5120FC567CDFBD9FD1BFF73407)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (62, N'tbf0JaD1itWOMEHa1KT8YpeQyPIK8XiGLAYHltX+iLI=', N'gestion.ort.edu.uy', N'inaki.2012@hotmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 16, 3, 0x4206042BD7E535BCAEE5329C650F465C79215D8D71ABD9FE2AEF0F32301A74D9, 0xA3EF5ACA33AFC88ABCC60E16228AC6D71A851EDF21559DE43B5893BCF2278B72)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (63, N'wYWTNa+OduoPK0TfxBw1JcnQEyBZdDhiCBg6dgX7a1U77ubhDLUEIjj+eVNEcEHZD9XINvdseQQvpjO/gmfCvw==', N'ucla.com', N'inaki.2012@hotmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 3, N'', 16, 3, 0x7AF543E2DA8EA3B54A7A8464DABEAB1BD5616F0DB8BA647033591CA0B0FBD735, 0x55E51C5C62E7C7F6F7ACFEC8CF9B695ABA3550F86FF32A530D6670F9A2070E78)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (64, N'sNMa4hv0Rw8a8UqIws98iF1tM6HwsGvQI2zydrSppoo=', N'camscanner.com', N'inaki.2012@hotmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 16, 3, 0x3CCAA98DEC3C383A7D1E492283C61E93190AA05572488CB43727DE39051D605A, 0xAD2E7BE38F2A2882E92D9A55A8185E95D60DCDA0865D009B513C2E427D7BE7E8)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (65, N'lsuzLUaHE/JBeNH07JDtm1AYaFe5oCweSdUvtqJNgEM=', N'www.pdfs.com', N'inaki.2012@hotmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 16, 3, 0x21BEFCBD266FD825D1E5A25273F6992B226B72E0CB6B75EA9F71684474DE9DF0, 0xB28B198AB3766F43DF3AC4CE85D4BDEB3B833331F61AC4912317E64C28DAE656)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (66, N'CRIEfbRo5kzlW0YzNRR2ZQD9ArFwZCsYCz5lW9Ki5KF8V/gMEK+HF98qC/EBT3TEYOgO/K2BVk2/55f2Fq88yw==', N'www.generateservices.com', N'inaki.2008@hotmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 4, N'', 17, 3, 0x34C260F9AB4DB67B6B2A4F1259BB9AB3CB16F83F72437866C9B2C7F7A3CEBAB6, 0x50634765D0DC52C089FC387F1307DD26B688645687A3DB81AF65D86D18292F82)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (67, N'OH7+SpkXBwm9RyAVjnC/SGQxPhQt5FGBO5NxhsHw3zA=', N'www.dicethrow.com', N'inaki.2008@hotmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 17, 3, 0x62A73E5DF14E1CB8F33DEC68B88F59256B1B3BF075140A4A30AC00F4AE1E8FCC, 0x7325713D9DCF5FD35B97D26F1D0CD7B734BE3693B3EA5813C026333393E6100E)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (68, N'M1aQ5OvgLx9XKxgJdd9db8/LrssSWBgyKARjVs63M1U=', N'drive.google.com', N'inaki.2008@hotmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 17, 3, 0x0E4FF8E3EDD499818EFC2343003DCE37CB421EBEA5A47FD4339D0DCC33127855, 0x2D9B5C6995BD97C9F86703E80F2E221BAB212016280E4B6AA05E030B221246FD)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (69, N'3Ln9/wK7R+s9/6znafL7y2ZFAK5e6La8Q9Nlt4FSjL0=', N'www.google.com', N'inaki.2008@hotmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 17, 3, 0x47A21A15930F564FC782B26CF21DA94391D490689A6A96483E39741B122371C1, 0x23396C01C4C7B5F1ED6BEB8FA163AE852906E28E048F6252AA4F184567F56203)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (70, N'ljT3cmNEKj+QZSMc903YY2vmVNMEY0Oi90hJgeMBlhI=', N'www.refactoring.guru.com', N'inaki.2008@hotmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 17, 3, 0xAB575D6C0A358C1E1FA4687491E8469D24CF51DDBEC4EE0F56B89CA366C7682C, 0x5E94FEE8068B74E4E49FB11FB0268A468953BB14B606217BBDEC3ADE2D077F70)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (71, N'Xh9fi0lTEnURLMdHyr1gOH3P0wxSYQRFfvB2GT/HbNUqVg15yQIkQ7aSOFRhpvDn2JeB0iLnw074CWzjHWYQpg==', N'www.lokz.com', N'inaki.2008@hotmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 2, N'', 18, 3, 0xDCB6A035022AE4D314E67A3939D814333D87208C0143A29C20CA91AC6F0DF08A, 0x6AF4700569882F26D6BD2798134E071A807382BD270A6878089491E1E139A3EC)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (72, N'nKoakSg/kz4aQIBLjRR/37qvj9OJ9vl+oEW9/rWs7UE=', N'www.learn.com', N'inaki.etche@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 18, 3, 0x1BE60A7C908E4007A926393CBA039D32F7F46C9B6D7F859509143924EB2FD80D, 0x74630A699C73CED2D5588D83A92B6041526BBA33D4C5C1DFB327BEFEF4E41C67)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (73, N'B0iqd0uFcb/IGKXCkXTCXGfZzeR67tYAuqQ3ZMXrYY4=', N'diy.org', N'inaki.etche@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 18, 3, 0x8852ECF73A85229452BDB88623261E508EEB78ADA781EA8629279FC75B1FA205, 0x0A65BEAAD279363489C40655AD94C5CCC5A0FBEAB63B085F40D8E34F0F67E663)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (74, N'/dd4Ts0IeSO8u/IHvzDXsTSVzMF3qmF9t88L11pzzus=', N'passcrypt.org.com', N'inaki.etche@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 18, 3, 0x17E27B7C4FF30DE016C225992375CD5C9D94BA671C0E01A07251AD5D554386FE, 0x24B90C2AC1F4E5830A2CF0B6CD9C0D78BE48FA8BF96D2577E8249CB5D9F09E00)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (75, N'r8leovXwmVf89AdOolZ4OWP2x+zJ6cFhW+JmMxVUGcw=', N'brilliantly.com', N'inaki.etche@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 18, 3, 0x32174917C6150D0ADBE0DEF0FA08090576A953E0FD05F843BA28EFD53D60CF74, 0x240E3E9570AD7678F6DFFC21D2BE57606302BF4338B927E960E8685400FC9466)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (76, N'SIieb+9/OKGGVPnG6u36w7znEs425iF7r54cRc5x0WcyJFQ0TWgGbjLgBsOcGstt2ax54yC8YSWe4Vx4mFph4A==', N'www.pedidosya.com.uy', N'tat1ana', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 2, N'', 20, 4, 0x191569D8AFF9E85C450FFD2C0804ECB7D743AFEC20836AAD241639354A1DBFE3, 0xD1E405FCADAD51AB5E25B4759D71C01BC53B0523F053D07F8971FEDDB02ECDA7)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (77, N'r8Js4yCgDrtyrSMFOHsVXu5acamBqg7mZHJb/c7jWm0=', N'www.comidaahora.com', N'tat1ana', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 20, 4, 0x6D9B778DF8BA01F00E4909D5853C8CC9E7B0D56A37CDBB43A0DDB16EE79C8213, 0x218C3A3B2F1886EF6259B1A870281C67E4500F3B75166F3B6AB1588872DEB123)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (78, N'7wIuy9D2PnWC3PdCe+rOh6Y1iQdNnyqywX37SqmFgrw=', N'www.ubereats.com', N'tat1ana', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 20, 4, 0xDE99672C0ECF6310792B2720201A77F5BDCC72B9F15D58834859E00D06770D4F, 0xB5EC676279D1005643F37B8E789B4D704D56C89C52624F1BD5332836B5173190)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (79, N'YWoLrKekGrl2uamJGOIkVpbyacxQ6PXytf6OeKkCTBk=', N'www.tiendaingles.com', N'tat1ana', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 20, 4, 0x2C7D0CD6A57C5C31D2386669888A694B69E803E66FC2BA576FCF9B132353FDA1, 0x10706E862EA33EE3F670B03025E30618449E2AD884A8D45F063D8B0B156D2511)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (80, N'1X8aeIGCnpv7Wlcmd4X1fhMSWYCAiR1qZuqNDaM++2w=', N'www.disco.com', N'tat1ana', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 20, 4, 0xC74D0BCCFA175158991EB4FBD7B293612C311027EC398EB42385E56AFAB6FE0A, 0x7C1A4763F7A6446A96ED0ADDF37A82C666436D58B0AFC34E5EF39017F0F834BA)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (81, N'BFh3/bFDt+KmIS3TMQzIsxfSIZtBybsKf98R9n8wQev/tnqp/zmpjpXrbtnP/8So2bCjH0OOoLCDEhrjmbZzpQ==', N'www.despegar.com', N'tat1ana', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 4, N'', 21, 4, 0x01409C8F08B07113F5A8E10ED4D9E34FFA7BEF21A9AD38106866DF8B6FDAE8E2, 0xC6E958C6244A3098046419EF18E9CF5C09593453EB31F8AE6D10280750CE3F20)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (82, N'AT5zS08W9QI+u0N8jpHUB6SNPmjud4bCRVqXkXdNO+CIfuNSBrJxDqwqiLRZ4bi8eMaCNOA5jCrfClvn0j1UpQ==', N'www.hotels.com', N'tat1ana', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 3, N'', 21, 4, 0xB7E293BA9DEA763B243B118B8FF912E9BBC49CC30939BD133B03363EDF9913B9, 0x70C127272C5F05B612EDFBD5772A6C46FE49188C01EF927502C3FDAB25EFDD0D)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (83, N'7NnY5nFZGnXvFQWgvZeY8LsW+WYejDO61lNC8BRsdYI=', N'www.trivago.com', N'tat1ana', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 4, N'', 21, 4, 0xA725D07C2BEF4C2E7CE96933AAE9BB6A27CC95BF1E1BD0FCC4788624B3F05BE7, 0x6317275D0AB3538FEE13B0B42E56259C56A23608AEF566B9D1E635AB6D55330C)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (84, N'FImZI8mFpfPDRq3KWZUiLsg4ZxPuWWRB3Djp962u41YLmzIx9Y/X5E1UYJgo3mG+zZT7wFlR+PxE5JTGaTVl1g==', N'www.discounttravel.com', N'tat1ana', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 3, N'', 21, 4, 0x6C71D6F334AABBC635320B97C03315D8E46072DB5A8A5110B5C541E7DA76F2F4, 0x4B1A602C8EE616F77554ED47EE7F419C6D3F08307F7CD63CEEC209ED5F560A05)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (85, N'AelF6dBg4KUmjfiDv1r+7DOJSXtKrTLQFJYWeaLiJ5s=', N'www.devacaciones.com', N'tat1ana', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 21, 4, 0x106CD91D97FD5030E98C5E1895A3DF92FC70A5087D12C986B62ACDF1C822565F, 0x4774A279BDEF2A655289940F387FA4170FFE65D453DFF33F863BF5233517A186)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (86, N'j/y8376OkwuDNjsFrwpZX3W2lLD+mNtIs4YyfZbq9cQY0cuw3DZBM2AGaTpX1oA+NK5grgzRr/CsCzLSNU47tg==', N'www.net.com', N'tat1ana.co@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 3, N'', 22, 4, 0x325F94F39B7CD3B52DB66E56E1C8A14D200B179D31C6D72BF7C51F5DC5D8AFD4, 0x10F02D11CA8DE333B23AFC70F9CA8ABD59BB843A9312EA9E4AE625FA7572D88C)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (87, N'B57WXw7CMnykhPABL3ial+VoYjc5TvqyXJWzottawQE=', N'drive.google.com', N'tat1ana.co@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 22, 4, 0xE60B715854FABD5FC8C45D4033FE81E2A801EE2B819F9BB5948E8DB79B91A3EF, 0xE9B4FD2528A3AAD5C9370CCC79A3DA9CE4493D65524EDDB2FF7C0F5090CF04F2)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (88, N'jv04C0BpC2RgPlPhv10q/8T49uTPLG8fv9hwboknacY=', N'www.wondershare.com', N'tat1ana.co@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 22, 4, 0xFFBA2E276C058B4605928CB77D9C877D7AC700BD1E8FE8EEB85346ACC1FE078A, 0x2A0824C85CBD2C6F487985226934F9C0D962B1637A0716A02AA1C55074CF77B1)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (89, N'cMbfbyBK15XlMu24N3brbQG9BHqLmOTR8BIVjQkcAGg=', N'www.stackoverflow.com', N'tat1ana.co@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 22, 4, 0x33AB648C1B9F0767BCDEE1D9AAA2E50EF859456EDBA29B5FF312D6F258213B76, 0xB344950257B0D2E9F3CC28006A0C5539AFF934CF9F023E70E07AE100B13DB9D5)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (90, N'Ibwohq7mV52tBVl4z8Rlw0hTOFacauHMYq/0lgZdSjw=', N'www.kioss.com', N'tat1ana.co@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 22, 4, 0x24BCE796401E5A863C43522C563556A7AE714D23015EC6B6F09B6C4F6D95A21A, 0xC38040FC8C1EF1E009A6F7E70E5A7E1FFB4893EFD36D7D03356D853D1AFF97A4)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (91, N'ntCz2Rm7P+Z5+Y6XC+9bBQeObzejYZl54wyuL38+aE8=', N'www.ort.edu.uy', N'tat1ana.co@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 23, 4, 0xDF81B041FE3180BE006559E9CA2DFF2316B56977A83835B91D11DCE5A7CABA76, 0x852BC8501BA1D5FB89E9C6DC5FC716EEA983CA41B883E499A7DF2B838F9946B2)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (92, N'eSaDOoA3MOqLlTfHm9PbEVu4FfZ9VUAAvWOjHq1pfKk=', N'gestion.ort.edu.uy', N'tat1ana.co@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 23, 4, 0x286EE781F5B35BE0246F5109EB29E26EA18A7CD8DCA2AA3BE2252DFEF5A57066, 0x4421AC10F676C2DE29B31A7DB39E2037A58D175E01B0D9F44E91FC587715B437)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (93, N'BdE0XGOX1rufl8uxbBr8i9ODlAtnaG/XfVv+uyK4KRlc9fC4jSSMh1f+uXOz+AC5QKi2/vK0o+mZn1E/29mXdg==', N'ucla.com', N'tat1ana.co@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 4, N'', 23, 4, 0x4162A2454ADEA9BCFD1EF0CF717485F1B943F11CD72315F2C2ECECB1C846BE30, 0x4145A5AE9BB000840273A5183DA131CA5A4B266D67DFB8826A5DF924C1AB5644)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (94, N'fjMPDcmjvHDT/H5drh4MJ+BIqyYpg/X+Magi0N+2Oy8=', N'camscanner.com', N'tat1ana.co@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 23, 4, 0xBFA8E9A5283AB94C86670CA5615DBD3AC4303FA61625ADDB4E11E11FDC3874D3, 0x443A1594957D8B266DFF982CC01FCFB1B41CEE80296A54049C08581151F68329)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (95, N'yA3BvxlybisM874sJa977wd3FADL4cIrKVZKsCYAvd0=', N'www.pdfs.com', N'tat1ana.co@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 23, 4, 0x14F3840FD75D149E3C7D08FF871A596FEC6A3054E15881AC0D5C4FC056E0582B, 0x028AEB9690232AB71EE308F971FE656C70850E8E2D58EFC76E10526B007B0102)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (96, N'eNRwOBArRfzm3cqdUGeh1e7p9Hn5AOagWC7Lo+bzP5tSEBsBUkuJXtz/8C/m9y29z+YyC+vq+Xr/wkH9njC+ZA==', N'www.mercadolibre.com', N'tat1ana.co@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 3, N'', 24, 4, 0xC98352303B3F9D9AE72030C1221FAF48895FF1C2C822F41FF960CC4C7B2EA4E2, 0xD52F9A2A07D24002805E5EBCBC4340ADAD3CFA2A638B6F9D81B5CB03F05A47F0)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (97, N'EgLuMiqoTqEaHSFJrrC3y6CghbSGT2m0+AtbOmiRNJ6Icw1u0YkaZnJdPgcgaRPgC/BUmHX4upcvrVv8Vs0Pkg==', N'www.ebay.com', N'tat1ana.co@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 3, N'', 24, 4, 0xA06BCC26017F0CBE58DADEF1B01D7BEEF835C301F22D61B6994B144D719A539C, 0x767466FD607834228EB77DD83A85C148C2574EA5C71023DD8A1CAACF7CCB7ACB)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (98, N'Bz1Qw3zvNf9geD7B3KFdAqCyHsTFTto1EKBGGkMC8cI=', N'www.amazon.com', N'tat1ana.co@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 3, N'', 24, 4, 0x4021F61E63230B96D50C513A08D1AB3689CD5FAFE17EB34FFD4B3EFBF5A00CE4, 0xC0DD1B3569C5FC555DD631CF0DCFE5187ABDE900557471B9AC318E48D3DFFABB)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (99, N'9ZMXB8Qh9jgOsKHyYlXIFAj+y86mue/5WOHbu+fB1Io=', N'www.comprasmuchas.com', N'tat1ana.co@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 24, 4, 0x7A33EBAF3DCA2441CF46D5EE00BEFC616E98683753A78D115494581162FA6BA4, 0x18E6FEA9C3E49F20572514A049E722E637AA66DD588CB6869D18254D0BCAD246)
GO
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (100, N'C1k/mBZAGsR0pB/4prREiqmGnOTBHImonZAeptyRrtc=', N'tat1ana.co@gmail.com', N'www.alibaba.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 24, 4, 0xBFE107C03D77D54231CDC70C54DC0E712CD40231C70C3FEB6C2C8C6A4640DB0E, 0x75656C0FD9AA41A448562ACB0376D0909BB1F9675BEB22416E277EF1E47D26CE)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (101, N'8hSeHtyuy/wf370D9AW2nuc2NjUbzHlR5iusYfbVVPY=', N'www.tarsonis.com', N'executor@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 26, 5, 0x2DD574CB5DE6C5407087074B7E33118C1512375CAC378BB23E802D0D12D82D39, 0x293923471A2FA9FC6FE046B85C8C93F7C0702CCB2FCFD6441E645A353D83A600)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (102, N'7cHTKRFgj+U3UOHC43Zq6Y2h34Ii4ewKu0CLJOrFV+2CpLMrrp/2JYZAcpO+3Jgh6g6imQ45NoS25nRijA9hCQ==', N'www.sc.forums.com', N'executor@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 3, N'', 26, 5, 0x2151312B2BD976D08781C6459C93790A6814A3AB89422F79AA22053AF6AB1054, 0xD1ADBD1CECD1B2CC6B9BD28052F02B8799A143DB5A6CEAE6D1A2CA402ED2744C)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (103, N'HcB34s3UdnGE1Mh1s93HrQUuEIrkTEcQEuH+hLzQomgNilxAs3BbYjpzcG6TgiXgNb7k2Gdi9ek5U8WKg/rtxA==', N'www.bwsc.forums.com', N'executor@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 2, N'', 26, 5, 0x34843C746456FBCF2654C1E7491B02F9462F210D88BE665320DFDBE179CB0F83, 0xDC5D05362CD384FCF06E01D603930DBC2CA2FD08AFE3C2C0A011C5FC7EBA269A)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (104, N'WU/BrtuLrproS8KeZtEez8FCmr4Em0FrlEi4FRv5Hf0=', N'afreeca.tv', N'executor@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 26, 5, 0x1EDB09E650E9C7E7D9932722C50F6E6AFAC680D7959242FFDDFFD502BE6365EF, 0x31631A5190D34E5C3B03A958EBB21A131F06928D6626C74B634FB3D546680A21)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (105, N'NKQxn4Aiq4vE9gSInpXcF/XX4wNx2fgZxZy/LWItBkE=', N'www.dikfg.com', N'executor@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 26, 5, 0x6B5424C37349A758218DE7B32599E87407E0C848209300D9E12F1AD190470C46, 0xBBE3BDDD6CD3AC7A04738E6B0ACC7845008038BACB21855ABE36A98480D94D73)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (106, N'9T5nrckRjL/jPG+qqlqlEguC1AUh0Ep7T9Jpck1SDSY=', N'www.starcraft.com', N'executor@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 27, 5, 0xACD74F3415A17EFF062DC1C7041B683A1F9ABFAC7A37C382FF4D180CE729B054, 0xC73808732BD232CC95034901C07440905AFDEC102DC92EE5FDDF4595690C226F)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (107, N'H1fP3xJPjD+v3CmhpHzoJoFV+9D9oqZZawSPddDCg2w=', N'www.teamliquid.com', N'executor@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 27, 5, 0xAE0E61F84A775E4ADF1ADC0FB5494065DDCEA15D1659F01AC3BCC1566B5A7C00, 0x757FBBABAF57F13024ECA0ECA16FB13DB831EE155D6DCDC4543A5DAF14ECBBCD)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (108, N'VCarSs+XGF94CZ/nNNPP27ZuFlRIVFe+q4PGKyVQ7zArDhdlKCvHGvXEecZZzyyJ6L046eO3xIhwXmK4ybYn4w==', N'www.artosistv.com', N'executor@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 4, N'', 27, 5, 0x1DFC27A904CECEDE82A250C044F054F65FCB4EB1C0C527A6C5D6D50809F4AEBA, 0xA17F4CFF22DB2E2F59F893165825EFCC958A6B129A9A44AF6FD542E61A798EB7)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (109, N'MyH9pVXtbrF//IBUIqWDdSeMD4ZXheXK48CXexuqiHA=', N'www.twitch.tv', N'executor@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 27, 5, 0xE185942EF3A03B46CBD99F00DCA5008FC909419F3DF817143B75C8C941ADD4AB, 0xE00C0F23B156513FD68295A4EC50504F285CF4EFD4854524F829A2FF5FDF50BF)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (110, N'dHR4WqdEOY/ntSoeMRrI8UbQ51k+9A+sG+opcgYe2kY=', N'www.blizzard.com', N'executor@gmail.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 27, 5, 0x834C4CCF18FCDCFFD4C8526A2C4E7119E3C1B1753E2BAD1A887ABADCF33366C6, 0x62ECEFA5E4825C170EC8C2B6A567CB66CCA8DAF33B19F242072DCB361C292D8A)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (111, N'ODmgDrHIKqMkCT2KKkbQr9Qmj+DxHzzGnwGXXqima2nG/ysbpyP/5rhhLs1+37O5HHyf/wjkLJ7K42M9ZHvZyQ==', N'www.microsoft.com', N'artan1s', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 3, N'', 28, 5, 0x570C89FC6878867801781E6ABCDA67A6A6871AF85908D935B9D8A2C7D5B834AC, 0xA7F8D1975C8DEA7082E9E2DA4DADD41A214EE205CA0416DF7AB30E1958802502)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (112, N'XxFhInjSgcOcUImykgj0VzFrUqT4kadmr5aDaSnleVk=', N'www.apple.com', N'artan1s', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 28, 5, 0x19320ABA7F7A350179F5C7B4FEAD4B44FB80A802BA88E019E0B9245594ECB294, 0x5F0C4542B6375DAA841EFA3397199278B5D5530A9E1CC2C0351BAF541C3F8D0A)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (113, N'mE03hyK9LDHufFnkO6LnESPkACnQ1kGHUYrgP0E2mMs=', N'www.devforums.com', N'artan1s', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 28, 5, 0xC9CBB1D0E583ED429CF207443FB11A1A7C82A61563EC4AD803DAA98409A25B08, 0xF2F559E7010AA14E10C609EE66BC0FEEB6090887412AD3FC32183412045EE414)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (114, N'A1JkVzNkIycIw2TQ+b8ifznziaZR2BwM/MM/lYnOtmc=', N'www.netcore.com', N'artan1s', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 28, 5, 0x9BF5DAC786523E356D4268BFB148D0D2B3BAD443E7E5E55191AC25DA553B2E34, 0x57DA4EE7D7D8A8ADC87947C9C86415930AE9209524AB9E53756FDA20A3A29B23)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (115, N'tPTsYoYn5Njmlh2aoDf8fORN6VnyR9Rkm2CachQN+JUQhaXu/JY5Y9pvAG9thr813AO/JTW7avC7PnMvBWxTJA==', N'www.stackoverflow.com', N'artan1s', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 2, N'', 28, 5, 0x26723D50A9941CA4444757A26F472FDF7496786197FE107E286B416446EA8987, 0xD2CD999B6526B85B2B1C6773CE0153843C87F18FEEA6A201866D18F39D6A85AF)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (116, N'c8SZEA07ssPAc2Yv4VJ7lB07h/AiCEHMTgtH2IzDBdPqYvX/XShZjxT73Kg5SnMqx4dNoX7j8pG0A0tVF29yzw==', N'www.mercadolibre.com', N'artan1s', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 3, N'', 29, 5, 0x1C8BF0FCCDBB42A8C7CD0AE03DB4AEACF6A8960F04A7F82BD6E99CEC20535426, 0x2190E321AC51C51D6668C8ECDEF6CE21FEFCDE5A4128D434404CEB80ADA442B7)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (117, N'w1ll7KHXRiBxdfVh0X5sXegsv0JJBQVSRhdsL5/U2apXWQjNfKXvOK47CHW64JVqMfP7u+YxeJfgCgolBeqloA==', N'www.mercadolibre.com', N'artan1s', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 3, N'', 29, 5, 0xE49FAA6622748DE0DB02F66F6C89F7E3B72945144318F0949E68C6109ED5B793, 0x36D1A35CF0BDB427D2EAC0A973374775443047533C363E056B65B3C66A49AFF3)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (118, N'Kt/tgbzh+L6iyWtrW4TtU0Ey1DgmmLBWQiTb9Z+k82A82LaiexFP1HGI8cm8wYaUH+uu6yMU6aqsBul9hzsavA==', N'www.ebay.com', N'artan1s', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 3, N'', 29, 5, 0x13A59F1544C08DF78CDC44BD797E35AF13E276F9E7E91B2023BF930AD63A98AB, 0xD25B8DDEA5892E63232B4D255C1EC69D1592FA32D6D5D6CA0F7AFD1EFBB954CB)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (119, N'jOtv6ru4aFEtcQRrhz6WSaogOF0l5YRe2t7AF0GCkvQTBlScyICPqo6Dp/5TJHVEALe8fwtqqNwD8/m5d1WTiA==', N'www.comprasmuchas.com', N'artan1s', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 4, N'', 29, 5, 0xBF7CE45675C1C70642FEA6D4DC20D9FB29C7A69DFBE34CC5225CC6579231424E, 0x2A0CB21B36DF0287BCC61A79B19B250BF77BDA29037D268E0A67D4239956FA76)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (120, N'pBQYVdVLrFD8kS0addKvljUgo+qjONvztXhbl1Phz90=', N'www.alibaba.com', N'artan1s', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 0, N'', 29, 5, 0x87B98AD62F6D1434F3027E58F53333727462B0A9C578E8B6F12BEF4B40C61828, 0xEC704D4EDC4F3CEA6E6037C3B403B9C238F181EBC3177D69DBCCF7AD66390B40)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (121, N'nEl6i+q5MyfTj3r6tv9gejZM01gf/JGAQS9JUPGIy78=', N'www.paginas.com', N'artan1s', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 1, N'', 30, 5, 0x7DB2C3B9571E52E04D8DD0D89A2BDA4BEAF6538DEDF6FE6E502EBB1FD8E99BFD, 0x6AFC94CA24986206BC5C3C6A022744F1714CDFE42A4D75AC8BED4F82D40B749E)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (122, N'pCEZTqsZ86RJDXnF5IFuitc+ysNOD8liK8r2Rp6pIRA=', N'gavron', N'www.appledev.com', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 0, N'', 30, 5, 0x18970439ACEFD220CC8AA9D95E12BCED0B13251A9F1F21902B24022C870F62C3, 0x21489D797DB787ABBBD4BD62D7728AB0D7151AE5AC82F689DB3DA09074979B8B)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (123, N'3ex0lohLw1TuLPpVUg5OQ4nXI6cJ8PXQEFQoXaJhwC8W6jvw2NLqRdnutyGgkxQkDAE6rU8pvCGZMhAzt9RsOA==', N'www.myforum.com', N'artan1s', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 3, N'', 30, 5, 0x7065FDD96D99FA3E60507088B92A002BDC9B88AF895001343D0839EF71F197EA, 0x55FFF2C946C445976720A5BC014E85F62572C331A60015EC7E8A71FB04B6BF2E)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (124, N'sh7xLgs0TGEmmZueEizk6SrAz+bliA0wUEIOlE6ljnnKnMvBOOQ5C5GnMceCIxU/R0Z3g3qaADRmYzOy1cvl9Q==', N'www.exec.org.uy', N'artan1s', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 3, N'', 30, 5, 0xEB584257626405556003236E44C4634AC8AC5C3AAD59A5284336545973B1091A, 0x9A6F96DD48FCD0E0BD9CDAE624A8B0ACF5FAF834C42B0EEB3B0D5936AB61D5F0)
INSERT [dbo].[Passwords] ([PasswordID], [PasswordString], [Site], [Username], [LastModification], [SecurityLevel], [Notes], [Category_CategoryID], [UserPassword_UserPasswordID], [PasswordIV], [PasswordKey]) VALUES (125, N's1uFNouMtFvi3I+FjEYHH8cs2keM+aRylLO6QiLR/dxCFfXJo8l0zoqT6fCuaZf7DF5foaCEGg7/k4MOcRgkOg==', N'www.pipo.com', N'artan1s', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 4, N'', 30, 5, 0xB54D008C5827F08B7B7E1EEA05A7BCC776E822C8F579FBEEA58843DA6ECD2B08, 0xFD31239435AC9F4F270E529B4327F9F68681B8008C5D10F8480C3839001FA474)
SET IDENTITY_INSERT [dbo].[Passwords] OFF
GO
INSERT [dbo].[UserCategories] ([UserCategoryID]) VALUES (1)
INSERT [dbo].[UserCategories] ([UserCategoryID]) VALUES (2)
INSERT [dbo].[UserCategories] ([UserCategoryID]) VALUES (3)
INSERT [dbo].[UserCategories] ([UserCategoryID]) VALUES (4)
INSERT [dbo].[UserCategories] ([UserCategoryID]) VALUES (5)
GO
INSERT [dbo].[UserCreditCards] ([UserCreditCardID]) VALUES (1)
INSERT [dbo].[UserCreditCards] ([UserCreditCardID]) VALUES (2)
INSERT [dbo].[UserCreditCards] ([UserCreditCardID]) VALUES (3)
INSERT [dbo].[UserCreditCards] ([UserCreditCardID]) VALUES (4)
INSERT [dbo].[UserCreditCards] ([UserCreditCardID]) VALUES (5)
GO
INSERT [dbo].[UserDataBreaches] ([UserDataBreachesID]) VALUES (1)
INSERT [dbo].[UserDataBreaches] ([UserDataBreachesID]) VALUES (2)
INSERT [dbo].[UserDataBreaches] ([UserDataBreachesID]) VALUES (3)
INSERT [dbo].[UserDataBreaches] ([UserDataBreachesID]) VALUES (4)
INSERT [dbo].[UserDataBreaches] ([UserDataBreachesID]) VALUES (5)
GO
INSERT [dbo].[UserPasswords] ([UserPasswordID]) VALUES (1)
INSERT [dbo].[UserPasswords] ([UserPasswordID]) VALUES (2)
INSERT [dbo].[UserPasswords] ([UserPasswordID]) VALUES (3)
INSERT [dbo].[UserPasswords] ([UserPasswordID]) VALUES (4)
INSERT [dbo].[UserPasswords] ([UserPasswordID]) VALUES (5)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [Name], [MainPassword], [PasswordKeys], [PasswordIV]) VALUES (1, N'MatixitaM', N'0qbQN+g5meIXTRMW1Bm7vJPXHSsoz0hueG0jCrHFPPk=', 0x04952AAE0E0246AECB7E1D51971CD461C9DBAB8C4A92DD113CD23422A5BEE936, 0x2A0A6D6F35FF8672DE93DC57584732EE223D006E4472DA12D68CA4E661BFFD49)
INSERT [dbo].[Users] ([UserID], [Name], [MainPassword], [PasswordKeys], [PasswordIV]) VALUES (2, N'GLandeira', N'W0VEYbOH9CSuwOwv7fWS11+ZROnzMQiQyMLx6FWJVCY=', 0xD6AAB018E5CADA5C093B585DA1A0824D6A24572D814E4F383B22A06CDC95CC11, 0xF67E9B290FF66C2D1ACC5B6037C4C898E13C536730AC253C4C6013F48A54A421)
INSERT [dbo].[Users] ([UserID], [Name], [MainPassword], [PasswordKeys], [PasswordIV]) VALUES (3, N'Sleepz', N'q0DlOyh5yn4AxqRR4Mpv/6BI/6osjR+qOFnACtYaZOs=', 0x7259DBAFE4AD67648DB0599A2B945774C786EA3707CDDBAA4BD1B1259CDA5E78, 0xAF355F79BA1A4B6696A64B975A3F74B29C87389137454591A74866CCBD0D88AC)
INSERT [dbo].[Users] ([UserID], [Name], [MainPassword], [PasswordKeys], [PasswordIV]) VALUES (4, N'Tat1ana02', N'30DwQfNg4AtMwUH5hGuoEVjFmMNHno4nGlxBlrrrHYA=', 0x8B6ED7CD17964CC346CCAC28861BE86A27510D0FA22A183A766AE30276D7887F, 0xE7785D2CC85A93A0D47007910EF34FFA8DE25F95217A3BA00BB91E63DADCEC7A)
INSERT [dbo].[Users] ([UserID], [Name], [MainPassword], [PasswordKeys], [PasswordIV]) VALUES (5, N'exec1509', N'N9ZuEnNslCgHbmNF1gANnLfRsLKO6TsrpZ7vhOCNC90=', 0xB6EF20499863CC5F3A1F9E2341F51085EF2F72EACAC8EC9709A30EADC3273EE2, 0x9AFED425977F66C8193E4AFAF1C9AD47428A913C0D0B9515341C78F00960E0E3)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Categories_dbo.UserCategories_UserCategory_UserCategoryID] FOREIGN KEY([UserCategory_UserCategoryID])
REFERENCES [dbo].[UserCategories] ([UserCategoryID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_dbo.Categories_dbo.UserCategories_UserCategory_UserCategoryID]
GO
ALTER TABLE [dbo].[CreditCards]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CreditCards_dbo.Categories_Category_CategoryID] FOREIGN KEY([Category_CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[CreditCards] CHECK CONSTRAINT [FK_dbo.CreditCards_dbo.Categories_Category_CategoryID]
GO
ALTER TABLE [dbo].[CreditCards]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CreditCards_dbo.DataBreaches_DataBreach_DataBreachID] FOREIGN KEY([DataBreach_DataBreachID])
REFERENCES [dbo].[DataBreaches] ([DataBreachID])
GO
ALTER TABLE [dbo].[CreditCards] CHECK CONSTRAINT [FK_dbo.CreditCards_dbo.DataBreaches_DataBreach_DataBreachID]
GO
ALTER TABLE [dbo].[CreditCards]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CreditCards_dbo.UserCreditCards_UserCreditCard_UserCreditCardID] FOREIGN KEY([UserCreditCard_UserCreditCardID])
REFERENCES [dbo].[UserCreditCards] ([UserCreditCardID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CreditCards] CHECK CONSTRAINT [FK_dbo.CreditCards_dbo.UserCreditCards_UserCreditCard_UserCreditCardID]
GO
ALTER TABLE [dbo].[DataBreaches]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DataBreaches_dbo.UserDataBreaches_UserDataBreaches_UserDataBreachesID] FOREIGN KEY([UserDataBreaches_UserDataBreachesID])
REFERENCES [dbo].[UserDataBreaches] ([UserDataBreachesID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DataBreaches] CHECK CONSTRAINT [FK_dbo.DataBreaches_dbo.UserDataBreaches_UserDataBreaches_UserDataBreachesID]
GO
ALTER TABLE [dbo].[PasswordHistories]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PasswordHistories_dbo.DataBreaches_DataBreach_DataBreachID] FOREIGN KEY([DataBreach_DataBreachID])
REFERENCES [dbo].[DataBreaches] ([DataBreachID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PasswordHistories] CHECK CONSTRAINT [FK_dbo.PasswordHistories_dbo.DataBreaches_DataBreach_DataBreachID]
GO
ALTER TABLE [dbo].[PasswordHistories]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PasswordHistories_dbo.DataBreaches_DataBreachOrigin_DataBreachID] FOREIGN KEY([DataBreach_DataBreachID])
REFERENCES [dbo].[DataBreaches] ([DataBreachID])
GO
ALTER TABLE [dbo].[PasswordHistories] CHECK CONSTRAINT [FK_dbo.PasswordHistories_dbo.DataBreaches_DataBreachOrigin_DataBreachID]
GO
ALTER TABLE [dbo].[PasswordHistories]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PasswordHistories_dbo.Passwords_Password_PasswordID] FOREIGN KEY([Password_PasswordID])
REFERENCES [dbo].[Passwords] ([PasswordID])
GO
ALTER TABLE [dbo].[PasswordHistories] CHECK CONSTRAINT [FK_dbo.PasswordHistories_dbo.Passwords_Password_PasswordID]
GO
ALTER TABLE [dbo].[Passwords]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Passwords_dbo.Categories_Category_CategoryID] FOREIGN KEY([Category_CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[Passwords] CHECK CONSTRAINT [FK_dbo.Passwords_dbo.Categories_Category_CategoryID]
GO
ALTER TABLE [dbo].[Passwords]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Passwords_dbo.UserPasswords_UserPassword_UserPasswordID1] FOREIGN KEY([UserPassword_UserPasswordID])
REFERENCES [dbo].[UserPasswords] ([UserPasswordID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Passwords] CHECK CONSTRAINT [FK_dbo.Passwords_dbo.UserPasswords_UserPassword_UserPasswordID1]
GO
ALTER TABLE [dbo].[PasswordUsers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PasswordUsers_dbo.Passwords_Password_PasswordID] FOREIGN KEY([Password_PasswordID])
REFERENCES [dbo].[Passwords] ([PasswordID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PasswordUsers] CHECK CONSTRAINT [FK_dbo.PasswordUsers_dbo.Passwords_Password_PasswordID]
GO
ALTER TABLE [dbo].[PasswordUsers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PasswordUsers_dbo.Users_User_UserID] FOREIGN KEY([User_UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[PasswordUsers] CHECK CONSTRAINT [FK_dbo.PasswordUsers_dbo.Users_User_UserID]
GO
ALTER TABLE [dbo].[UserCategories]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserCategories_dbo.Users_UserCategoryID] FOREIGN KEY([UserCategoryID])
REFERENCES [dbo].[Users] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserCategories] CHECK CONSTRAINT [FK_dbo.UserCategories_dbo.Users_UserCategoryID]
GO
ALTER TABLE [dbo].[UserCreditCards]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserCreditCards_dbo.Users_UserCreditCardID] FOREIGN KEY([UserCreditCardID])
REFERENCES [dbo].[Users] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserCreditCards] CHECK CONSTRAINT [FK_dbo.UserCreditCards_dbo.Users_UserCreditCardID]
GO
ALTER TABLE [dbo].[UserDataBreaches]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserDataBreaches_dbo.Users_UserDataBreachesID] FOREIGN KEY([UserDataBreachesID])
REFERENCES [dbo].[Users] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserDataBreaches] CHECK CONSTRAINT [FK_dbo.UserDataBreaches_dbo.Users_UserDataBreachesID]
GO
ALTER TABLE [dbo].[UserPasswords]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserPasswords_dbo.Users_UserPasswordID] FOREIGN KEY([UserPasswordID])
REFERENCES [dbo].[Users] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserPasswords] CHECK CONSTRAINT [FK_dbo.UserPasswords_dbo.Users_UserPasswordID]
GO
