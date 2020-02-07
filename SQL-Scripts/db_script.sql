Use [Master]
GO

CREATE DATABASE [MyDB]
GO

Use [MyDB]
GO

CREATE TABLE [dbo].[SearchKeyword]
(
	Id int identity(1,1) NOT NULL,
	Name varchar(20) NOT NULL,
	CreatedDate datetime NOT NULL,
	CreatedBy datetime  NULL,
	UpdatedDate datetime NULL,
	UpdatedBy datetime NULL
)
GO

CREATE TABLE [dbo].[SearchKeywordMatch]
(
	Id int identity(1,1) NOT NULL,
	SearchKeywordId int NOT NULL,
	Name varchar(20) NOT NULL,
	CreatedDate datetime NOT NULL,
	CreatedBy datetime NULL,
	UpdatedDate datetime NULL,
	UpdatedBy datetime NULL
)
GO

CREATE TABLE [dbo].[Employees](
	[Id] [int] identity(1,1) NOT NULL,
	[Name] [varchar](50)  NOT NULL,
	[ManagerId] [int]  NULL
   )

    INSERT INTO [dbo].[Employees]
    ([Name], [ManagerId])
    VALUES
    ('Joe',NULL),
    ('Harry',1),
    ('Chang',2),
    ('Mary',2),
    ('Alfonse',4)
 


INSERT [dbo].[SearchKeyword] ([Name], [CreatedDate]) VALUES (N'u', GETDATE())
GO
INSERT [dbo].[SearchKeyword] ([Name], [CreatedDate]) VALUES (N'u l', GETDATE())
GO
INSERT [dbo].[SearchKeyword] ([Name], [CreatedDate]) VALUES (N'u gr', GETDATE())
GO
INSERT [dbo].[SearchKeyword] ([Name], [CreatedDate]) VALUES (N'r', GETDATE())
GO
INSERT [dbo].[SearchKeyword] ([Name], [CreatedDate]) VALUES (N'r d', GETDATE())
GO
INSERT [dbo].[SearchKeyword] ([Name], [CreatedDate]) VALUES (N'r l', GETDATE())
GO


INSERT [dbo].[SearchKeywordMatch] ([SearchKeywordId],[Name], [CreatedDate]) VALUES (1, N'Users', GETDATE())
GO
INSERT [dbo].[SearchKeywordMatch] ([SearchKeywordId],[Name], [CreatedDate]) VALUES (1, N'User Groups', GETDATE())
GO
INSERT [dbo].[SearchKeywordMatch] ([SearchKeywordId],[Name], [CreatedDate]) VALUES (1, N'User Activity Log', GETDATE())
GO

INSERT [dbo].[SearchKeywordMatch] ([SearchKeywordId],[Name], [CreatedDate]) VALUES (2, N'User Actvity Log', GETDATE())
GO


INSERT [dbo].[SearchKeywordMatch] ([SearchKeywordId],[Name], [CreatedDate]) VALUES (3, N'User Groups', GETDATE())
GO

INSERT [dbo].[SearchKeywordMatch] ([SearchKeywordId],[Name], [CreatedDate]) VALUES (4, N'Report Designer', GETDATE())
GO
INSERT [dbo].[SearchKeywordMatch] ([SearchKeywordId],[Name], [CreatedDate]) VALUES (4, N'Report Activity Log', GETDATE())
GO

INSERT [dbo].[SearchKeywordMatch] ([SearchKeywordId],[Name], [CreatedDate]) VALUES (5, N'Report Designer', GETDATE())
GO

INSERT [dbo].[SearchKeywordMatch] ([SearchKeywordId],[Name], [CreatedDate]) VALUES (6, N'Report Activity Log', GETDATE())
GO


