USE [DomainDBContext]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 17/6/2021 17:44:05 ******/
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
/****** Object:  Table [dbo].[CreditCards]    Script Date: 17/6/2021 17:44:05 ******/
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
/****** Object:  Table [dbo].[DataBreaches]    Script Date: 17/6/2021 17:44:05 ******/
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
/****** Object:  Table [dbo].[PasswordHistories]    Script Date: 17/6/2021 17:44:05 ******/
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
/****** Object:  Table [dbo].[Passwords]    Script Date: 17/6/2021 17:44:05 ******/
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
/****** Object:  Table [dbo].[PasswordUsers]    Script Date: 17/6/2021 17:44:05 ******/
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
/****** Object:  Table [dbo].[UserCategories]    Script Date: 17/6/2021 17:44:05 ******/
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
/****** Object:  Table [dbo].[UserCreditCards]    Script Date: 17/6/2021 17:44:05 ******/
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
/****** Object:  Table [dbo].[UserDataBreaches]    Script Date: 17/6/2021 17:44:05 ******/
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
/****** Object:  Table [dbo].[UserPasswords]    Script Date: 17/6/2021 17:44:05 ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 17/6/2021 17:44:05 ******/
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
