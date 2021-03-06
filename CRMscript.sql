/* USE [CRM]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 11/18/2018 7:58:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO 
****
	Create CRM database and run this script
*****
*/
CREATE TABLE [dbo].[Comments](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[CommentText] [nvarchar](500) NOT NULL,
	[CreateAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customers]    Script Date: 11/18/2018 7:58:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](50) NOT NULL,
	[ContactPerson] [nvarchar](50) NOT NULL,
	[Addres] [nvarchar](100) NOT NULL,
	[Mobile] [nvarchar](20) NOT NULL,
	[OfficeNumber] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[CreateAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Notification]    Script Date: 11/18/2018 7:58:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notification](
	[NotificationId] [int] IDENTITY(1,1) NOT NULL,
	[TaksID] [int] NOT NULL,
	[NotificationType] [tinyint] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Create] [datetime] NOT NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[NotificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 11/18/2018 7:58:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [tinyint] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 11/18/2018 7:58:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[TaskId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[Description] [nvarchar](200) NULL,
	[CreationAt] [datetime] NOT NULL,
	[DeadlineTime] [datetime] NOT NULL,
	[FinishTime] [bit] NOT NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/18/2018 7:58:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
	[RoleID] [tinyint] NOT NULL,
	[CreateAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([CommentId], [UserID], [CustomerID], [CommentText], [CreateAt]) VALUES (3, 1, 1, N'problem yoxdu', CAST(0x0000A99900000000 AS DateTime))
INSERT [dbo].[Comments] ([CommentId], [UserID], [CustomerID], [CommentText], [CreateAt]) VALUES (9, 1, 2, N'ge tog dus hadt
', CAST(0x0000A99900000000 AS DateTime))
INSERT [dbo].[Comments] ([CommentId], [UserID], [CustomerID], [CommentText], [CreateAt]) VALUES (1006, 1, 2, N'Bu sirketle mutleq emekdasliq etmek lazimdi
', CAST(0x0000A99A00000000 AS DateTime))
INSERT [dbo].[Comments] ([CommentId], [UserID], [CustomerID], [CommentText], [CreateAt]) VALUES (1007, 1, 2, N'Lorem isun molrem sporunto min axe notrmi
', CAST(0x0000A99A00000000 AS DateTime))
INSERT [dbo].[Comments] ([CommentId], [UserID], [CustomerID], [CommentText], [CreateAt]) VALUES (1008, 1, 3, N'Visionsuz dunyada visoin axtaran insanlara rast gelmedik
', CAST(0x0000A99C0141E644 AS DateTime))
SET IDENTITY_INSERT [dbo].[Comments] OFF
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([CustomerId], [CustomerName], [ContactPerson], [Addres], [Mobile], [OfficeNumber], [Email], [CreateAt]) VALUES (1, N'KA MMC', N'Kamal Kamil', N'Bakı ş. Xətai r. Xocali 25', N'+994505625586', N'+994123880000', N'kammc@gmail.com', CAST(0x0000A99500000000 AS DateTime))
INSERT [dbo].[Customers] ([CustomerId], [CustomerName], [ContactPerson], [Addres], [Mobile], [OfficeNumber], [Email], [CreateAt]) VALUES (2, N'Kamasutra', N'Jin Lyu', N'Chine Hang Hong', N'+1252666635', N'+1235135168', N'jinlyu@gmail.com', CAST(0x0000A99600000000 AS DateTime))
INSERT [dbo].[Customers] ([CustomerId], [CustomerName], [ContactPerson], [Addres], [Mobile], [OfficeNumber], [Email], [CreateAt]) VALUES (3, N'Code Vision', N'No SQl', N'Sqlsiz heyat', N'+994501121212', N'+994125000000', N'code@gmail.com', CAST(0x0000A99900000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Customers] OFF
SET IDENTITY_INSERT [dbo].[Notification] ON 

INSERT [dbo].[Notification] ([NotificationId], [TaksID], [NotificationType], [IsActive], [Create]) VALUES (1, 1008, 1, 1, CAST(0x0000A99600000000 AS DateTime))
INSERT [dbo].[Notification] ([NotificationId], [TaksID], [NotificationType], [IsActive], [Create]) VALUES (2, 1009, 3, 1, CAST(0x0000A99600000000 AS DateTime))
INSERT [dbo].[Notification] ([NotificationId], [TaksID], [NotificationType], [IsActive], [Create]) VALUES (3, 1010, 1, 1, CAST(0x0000A99600000000 AS DateTime))
INSERT [dbo].[Notification] ([NotificationId], [TaksID], [NotificationType], [IsActive], [Create]) VALUES (4, 1011, 1, 1, CAST(0x0000A99700000000 AS DateTime))
INSERT [dbo].[Notification] ([NotificationId], [TaksID], [NotificationType], [IsActive], [Create]) VALUES (5, 1012, 0, 1, CAST(0x0000A99700000000 AS DateTime))
INSERT [dbo].[Notification] ([NotificationId], [TaksID], [NotificationType], [IsActive], [Create]) VALUES (6, 1013, 3, 1, CAST(0x0000A99700000000 AS DateTime))
INSERT [dbo].[Notification] ([NotificationId], [TaksID], [NotificationType], [IsActive], [Create]) VALUES (7, 1014, 3, 1, CAST(0x0000A99900000000 AS DateTime))
INSERT [dbo].[Notification] ([NotificationId], [TaksID], [NotificationType], [IsActive], [Create]) VALUES (8, 1015, 2, 1, CAST(0x0000A99900000000 AS DateTime))
INSERT [dbo].[Notification] ([NotificationId], [TaksID], [NotificationType], [IsActive], [Create]) VALUES (9, 1016, 3, 0, CAST(0x0000A99A00000000 AS DateTime))
INSERT [dbo].[Notification] ([NotificationId], [TaksID], [NotificationType], [IsActive], [Create]) VALUES (10, 1017, 2, 0, CAST(0x0000A99A00000000 AS DateTime))
INSERT [dbo].[Notification] ([NotificationId], [TaksID], [NotificationType], [IsActive], [Create]) VALUES (11, 1018, 2, 0, CAST(0x0000A99B016BB92C AS DateTime))
SET IDENTITY_INSERT [dbo].[Notification] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (2, N'Moderator')
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Tasks] ON 

INSERT [dbo].[Tasks] ([TaskId], [CustomerID], [UserID], [Description], [CreationAt], [DeadlineTime], [FinishTime]) VALUES (1, 1, 1, N'Bir nece cumle
', CAST(0x0000A995015DA979 AS DateTime), CAST(0x0000A99700000000 AS DateTime), 1)
INSERT [dbo].[Tasks] ([TaskId], [CustomerID], [UserID], [Description], [CreationAt], [DeadlineTime], [FinishTime]) VALUES (2, 2, 1, N'MADfsdgsMADfsdgs

', CAST(0x0000A996013E40F5 AS DateTime), CAST(0x0000A99900000000 AS DateTime), 1)
INSERT [dbo].[Tasks] ([TaskId], [CustomerID], [UserID], [Description], [CreationAt], [DeadlineTime], [FinishTime]) VALUES (1005, 1, 1, N'Her sey yaxsi olacaqHer sey yaxsi olacaq
', CAST(0x0000A997010A24D0 AS DateTime), CAST(0x0000A99D00000000 AS DateTime), 1)
INSERT [dbo].[Tasks] ([TaskId], [CustomerID], [UserID], [Description], [CreationAt], [DeadlineTime], [FinishTime]) VALUES (1006, 2, 1, N'MUtleq emeklasliq etmek lazimdiMUtleq emeklasliq etmek lazimdi

', CAST(0x0000A997010B7FE5 AS DateTime), CAST(0x0000A9A400000000 AS DateTime), 1)
INSERT [dbo].[Tasks] ([TaskId], [CustomerID], [UserID], [Description], [CreationAt], [DeadlineTime], [FinishTime]) VALUES (1007, 1, 1, N'Gələn həftə korparativ görüş olacaqGələn həftə korparativ görüş olacaq

', CAST(0x0000A9970112AECF AS DateTime), CAST(0x0000A99F00000000 AS DateTime), 1)
INSERT [dbo].[Tasks] ([TaskId], [CustomerID], [UserID], [Description], [CreationAt], [DeadlineTime], [FinishTime]) VALUES (1008, 1, 1, N'Lorem impsun amkexet impros komto inrex sorutimLorem impsun amkexet impros komto inrex sorutim

', CAST(0x0000A99801821DAF AS DateTime), CAST(0x0000A99900000000 AS DateTime), 1)
INSERT [dbo].[Tasks] ([TaskId], [CustomerID], [UserID], [Description], [CreationAt], [DeadlineTime], [FinishTime]) VALUES (1009, 2, 1, N'Lorem impsun lorem lorem korem norem formLorem impsun lorem lorem korem norem form

', CAST(0x0000A999000E01B0 AS DateTime), CAST(0x0000A99A00000000 AS DateTime), 1)
INSERT [dbo].[Tasks] ([TaskId], [CustomerID], [UserID], [Description], [CreationAt], [DeadlineTime], [FinishTime]) VALUES (1010, 2, 1, N'Bir tnec yoxlamaBir tnec yoxlama

', CAST(0x0000A99900F2DBB7 AS DateTime), CAST(0x0000A99A00000000 AS DateTime), 1)
INSERT [dbo].[Tasks] ([TaskId], [CustomerID], [UserID], [Description], [CreationAt], [DeadlineTime], [FinishTime]) VALUES (1011, 2, 1, N'ghfghdhtghfghdht

', CAST(0x0000A99900F4530E AS DateTime), CAST(0x0000A99A00000000 AS DateTime), 1)
INSERT [dbo].[Tasks] ([TaskId], [CustomerID], [UserID], [Description], [CreationAt], [DeadlineTime], [FinishTime]) VALUES (1012, 2, 1, N'Lorem ipsun lormero unito hordio
', CAST(0x0000A99900FC1097 AS DateTime), CAST(0x0000A99C00000000 AS DateTime), 1)
INSERT [dbo].[Tasks] ([TaskId], [CustomerID], [UserID], [Description], [CreationAt], [DeadlineTime], [FinishTime]) VALUES (1013, 2, 1, N'69 -zu tetbiq etdirmek69 -zu tetbiq etdirmek

', CAST(0x0000A999012EE189 AS DateTime), CAST(0x0000A99E00000000 AS DateTime), 1)
INSERT [dbo].[Tasks] ([TaskId], [CustomerID], [UserID], [Description], [CreationAt], [DeadlineTime], [FinishTime]) VALUES (1014, 2, 1, N'3131

', CAST(0x0000A999012FFB5F AS DateTime), CAST(0x0000A99B00000000 AS DateTime), 1)
INSERT [dbo].[Tasks] ([TaskId], [CustomerID], [UserID], [Description], [CreationAt], [DeadlineTime], [FinishTime]) VALUES (1015, 2, 1, N'68696996498989896869699649898989

', CAST(0x0000A99901313E82 AS DateTime), CAST(0x0000A99B00000000 AS DateTime), 1)
INSERT [dbo].[Tasks] ([TaskId], [CustomerID], [UserID], [Description], [CreationAt], [DeadlineTime], [FinishTime]) VALUES (1016, 1, 1, N'Lorem impsun lodem rolem nio dio

', CAST(0x0000A99A01367377 AS DateTime), CAST(0x0000A99D00000000 AS DateTime), 0)
INSERT [dbo].[Tasks] ([TaskId], [CustomerID], [UserID], [Description], [CreationAt], [DeadlineTime], [FinishTime]) VALUES (1017, 2, 1, N'Lorem ipsun de mio coternto ikonti uno

', CAST(0x0000A99A0137F71F AS DateTime), CAST(0x0000A99F00000000 AS DateTime), 0)
INSERT [dbo].[Tasks] ([TaskId], [CustomerID], [UserID], [Description], [CreationAt], [DeadlineTime], [FinishTime]) VALUES (1018, 3, 1, N'Code vision MHTL xml vsion de loenma
', CAST(0x0000A99B016BB922 AS DateTime), CAST(0x0000A99F00000000 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Tasks] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [Name], [Surname], [Password], [UserName], [Email], [PhoneNumber], [RoleID], [CreateAt]) VALUES (1, N'Kamran', N'Mirzəyev', N'123', N'Kamran', N'kamranshm@code.edu.az', N'+994555625886', 1, CAST(0x0000A99500000000 AS DateTime))
INSERT [dbo].[Users] ([UserId], [Name], [Surname], [Password], [UserName], [Email], [PhoneNumber], [RoleID], [CreateAt]) VALUES (2, N'Ruslan', N'Bərziqyar', N'456', N'Ruslan', N'ruslanb@code.edu.az', N'+994502121212', 2, CAST(0x0000A99500000000 AS DateTime))
INSERT [dbo].[Users] ([UserId], [Name], [Surname], [Password], [UserName], [Email], [PhoneNumber], [RoleID], [CreateAt]) VALUES (3, N'Ulvi', N'Ibrahimov', N'159', N'Ulvi Ibragimov', N'ulvii@code.edu.az', N'+994702352111', 2, CAST(0x0000A99900000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Notification] ADD  CONSTRAINT [DF_Notification_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Tasks] ADD  CONSTRAINT [DF_Tasks_FinishTime]  DEFAULT ((0)) FOR [FinishTime]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Customers]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Users]
GO
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_Tasks] FOREIGN KEY([TaksID])
REFERENCES [dbo].[Tasks] ([TaskId])
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_Tasks]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Customers]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
