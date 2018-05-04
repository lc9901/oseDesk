/****** Object:  Table [dbo].[user]    Script Date: 08/30/2017 10:45:39 ******/
USE [oesdata]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

TRUNCATE TABLE [dbo].[user]
SET IDENTITY_INSERT [dbo].[user] ON
INSERT [dbo].[user] ([id], [user_name], [password], [gender], [role_type], [tel], [email], [avatar], [description], [address], [chinese_name], [create_time], [update_time], [last_login_time]) VALUES (1, N'asher', N'202CB962AC59075B964B07152D234B70', N'female', 1, N'18388886666', N'asherchen@augmentum.com.cn', N'no', N'第一个用户', N'YanZhou', N'小明        ', CAST(0x0000A7D000AD9580 AS DateTime), CAST(0x0000A7D000AD9580 AS DateTime), CAST(0x0000A7DE015DB413 AS DateTime))
INSERT [dbo].[user] ([id], [user_name], [password], [gender], [role_type], [tel], [email], [avatar], [description], [address], [chinese_name], [create_time], [update_time], [last_login_time]) VALUES (2, N'teacher', N'202CB962AC59075B964B07152D234B70', N'female', 2, N'18999998888', N'teacher@augmentum.com.cn', N'no', N'第一位老师', N'YZ', N'小黄        ', CAST(0x0000A7DE014DB5B0 AS DateTime), CAST(0x0000A7DE014DB5B0 AS DateTime), CAST(0x0000A7DE015DA14F AS DateTime))
SET IDENTITY_INSERT [dbo].[user] OFF