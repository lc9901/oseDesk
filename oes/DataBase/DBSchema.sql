USE [master]
GO

/****** Object:  Database [oesdata]    Script Date: 08/30/2017 10:12:04 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'oesdata')
BEGIN
alter database [oesdata] set single_user with rollback immediate
DROP DATABASE [oesdata]
END
GO

USE [master]
GO

/****** Object:  Database [oesdata]    Script Date: 08/30/2017 10:12:04 ******/
CREATE DATABASE [oesdata]
GO

ALTER DATABASE [oesdata] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [oesdata].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [oesdata] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [oesdata] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [oesdata] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [oesdata] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [oesdata] SET ARITHABORT OFF 
GO

ALTER DATABASE [oesdata] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [oesdata] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [oesdata] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [oesdata] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [oesdata] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [oesdata] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [oesdata] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [oesdata] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [oesdata] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [oesdata] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [oesdata] SET  DISABLE_BROKER 
GO

ALTER DATABASE [oesdata] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [oesdata] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [oesdata] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [oesdata] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [oesdata] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [oesdata] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [oesdata] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [oesdata] SET  READ_WRITE 
GO

ALTER DATABASE [oesdata] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [oesdata] SET  MULTI_USER 
GO

ALTER DATABASE [oesdata] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [oesdata] SET DB_CHAINING OFF 
GO

--===========================================================================================
USE [oesdata]
GO

/****** Object:  Table [dbo].[answer_sheet]    Script Date: 08/30/2017 10:33:02 ******/
IF  EXISTS (SELECT sys.objects.object_id FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[answer_sheet]') AND type in (N'U'))
DROP TABLE [dbo].[answer_sheet]
GO

USE [oesdata]
GO

/****** Object:  Table [dbo].[answer_sheet]    Script Date: 08/30/2017 10:33:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[answer_sheet](
	[user_id] [int] NOT NULL,
	[exam_id] [int] NOT NULL,
	[question_id] [int] NOT NULL,
	[question_answer] [nvarchar](50) NULL,
	[right_answer] [nvarchar](50) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


--===================================================================

USE [oesdata]
GO

IF  EXISTS (SELECT id FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_exam_create_time]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[exam] DROP CONSTRAINT [DF_exam_create_time]
END

GO

USE [oesdata]
GO

/****** Object:  Table [dbo].[exam]    Script Date: 08/30/2017 10:33:31 ******/
IF  EXISTS (SELECT sys.objects.object_id FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[exam]') AND type in (N'U'))
DROP TABLE [dbo].[exam]
GO

USE [oesdata]
GO

/****** Object:  Table [dbo].[exam]    Script Date: 08/30/2017 10:33:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[exam](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[display_id] [nvarchar](50) NULL,
	[user_id] [int] NULL,
	[name] [nvarchar](200) NULL,
	[total_score] [int] NULL,
	[question_quantity] [int] NULL,
	[single_question_score] [int] NULL,
	[create_time] [datetime] NULL,
	[description] [ntext] NULL,
	[effective_time] [datetime] NULL,
	[pass_criteria] [int] NULL,
	[time_limit] [int] NULL,
	[examinee_count] [int] NULL CONSTRAINT [DF_exam_examinee_count]  DEFAULT ((0)),
	[average_score] [int] NULL CONSTRAINT [DF_exam_average_score]  DEFAULT ((0)),
	[pass_rate] [int] NULL CONSTRAINT [DF_exam_pass_rate]  DEFAULT ((0)),
	[pass_number] [int] NULL CONSTRAINT [DF_exam_pass_number]  DEFAULT ((0)),
 CONSTRAINT [PK_exam] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[exam] ADD  CONSTRAINT [DF_exam_create_time]  DEFAULT (getdate()) FOR [create_time]
GO

--===========================================================================

USE [oesdata]
GO

/****** Object:  Table [dbo].[exam_question]    Script Date: 08/30/2017 10:35:24 ******/
IF  EXISTS (SELECT sys.objects.object_id FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[exam_question]') AND type in (N'U'))
DROP TABLE [dbo].[exam_question]
GO

USE [oesdata]
GO

/****** Object:  Table [dbo].[exam_question]    Script Date: 08/30/2017 10:35:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[exam_question](
	[exam_id] [int] NOT NULL,
	[question_id] [int] NOT NULL,
 CONSTRAINT [PK_exam_question] PRIMARY KEY CLUSTERED 
(
	[exam_id] ASC,
	[question_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--==================================================================================================
USE [oesdata]
GO

IF  EXISTS (SELECT id FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_question_question_status]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[question] DROP CONSTRAINT [DF_question_question_status]
END

GO

IF  EXISTS (SELECT id FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_question_create_time]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[question] DROP CONSTRAINT [DF_question_create_time]
END

GO

USE [oesdata]
GO

/****** Object:  Table [dbo].[question]    Script Date: 08/30/2017 10:35:58 ******/
IF  EXISTS (SELECT sys.objects.object_id FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[question]') AND type in (N'U'))
DROP TABLE [dbo].[question]
GO

USE [oesdata]
GO

/****** Object:  Table [dbo].[question]    Script Date: 08/30/2017 10:35:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[question](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[question_status] [nvarchar](10) NULL,
	[user_id] [int] NULL,
	[description] [ntext] NULL,
	[answer] [nvarchar](50) NULL,
	[create_time] [datetime] NULL,
	[update_time] [datetime] NULL,
	[option_a] [nvarchar](500) NULL,
	[option_b] [nvarchar](500) NULL,
	[option_c] [nvarchar](500) NULL,
	[option_d] [nvarchar](500) NULL,
 CONSTRAINT [PK_question] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[question] ADD  CONSTRAINT [DF_question_question_status]  DEFAULT ('ACTIVE') FOR [question_status]
GO

ALTER TABLE [dbo].[question] ADD  CONSTRAINT [DF_question_create_time]  DEFAULT (getdate()) FOR [create_time]
GO

--=================================================================================
USE [oesdata]
GO

/****** Object:  Table [dbo].[user]    Script Date: 08/30/2017 10:37:12 ******/
IF  EXISTS (SELECT sys.objects.object_id FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[user]') AND type in (N'U'))
DROP TABLE [dbo].[user]
GO

USE [oesdata]
GO

/****** Object:  Table [dbo].[user]    Script Date: 08/30/2017 10:37:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[gender] [nvarchar](20) NULL,
	[role_type] [int] NULL,
	[tel] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[avatar] [nvarchar](50) NULL,
	[description] [ntext] NULL,
	[address] [nvarchar](50) NULL,
	[chinese_name] [nchar](10) NULL,
	[create_time] [datetime] NULL,
	[update_time] [datetime] NULL,
	[last_login_time] [datetime] NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
--====================================================================================================

USE [oesdata]
GO

IF  EXISTS (SELECT id FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_user_exam_exam_status]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[user_exam] DROP CONSTRAINT [DF_user_exam_exam_status]
END

GO

IF  EXISTS (SELECT id FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_user_exam_score]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[user_exam] DROP CONSTRAINT [DF_user_exam_score]
END

GO

IF  EXISTS (SELECT id FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_user_exam_use_time]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[user_exam] DROP CONSTRAINT [DF_user_exam_use_time]
END

GO

USE [oesdata]
GO

/****** Object:  Table [dbo].[user_exam]    Script Date: 08/30/2017 10:38:00 ******/
IF  EXISTS (SELECT sys.objects.object_id FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[user_exam]') AND type in (N'U'))
DROP TABLE [dbo].[user_exam]
GO

USE [oesdata]
GO

/****** Object:  Table [dbo].[user_exam]    Script Date: 08/30/2017 10:38:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[user_exam](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[exam_id] [int] NULL,
	[exam_status] [int] NULL,
	[score] [int] NULL,
	[right_count] [int] NULL,
	[use_time] [int] NULL,
 CONSTRAINT [PK_user_exam] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[user_exam] ADD  CONSTRAINT [DF_user_exam_exam_status]  DEFAULT ((0)) FOR [exam_status]
GO

ALTER TABLE [dbo].[user_exam] ADD  CONSTRAINT [DF_user_exam_score]  DEFAULT ((0)) FOR [score]
GO

ALTER TABLE [dbo].[user_exam] ADD  CONSTRAINT [DF_user_exam_use_time]  DEFAULT ((0)) FOR [use_time]
GO


