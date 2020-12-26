USE [FloraInsideDB]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 12/26/2020 5:42:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[Id] [int] NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](15) NULL,
	[BloodGroup] [varchar](3) NULL,
	[MaritialStatus] [varchar](1) NULL,
	[Designation] [varchar](50) NULL,
	[Department] [varchar](50) NULL,
	[PresentAddress] [varchar](max) NULL,
	[PermanentAddress] [varchar](max) NULL,
	[EmergencyContact] [varchar](15) NULL,
	[Image] [varchar](50) NULL,
	[Status] [int] NULL,
	[IsAdmin] [int] NULL,
	[JoiningDate] [datetime] NULL,
	[FireId] [varchar](max) NULL,
	[Nid] [varchar](15) NULL,
	[AccountStatus] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

