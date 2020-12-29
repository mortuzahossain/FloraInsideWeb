USE [FloraERP]
GO

ALTER TABLE [dbo].[UserLogin] DROP CONSTRAINT [FK_UserLogin_UsersProfile]
GO

ALTER TABLE [dbo].[UserLogin] DROP CONSTRAINT [FK_UserLogin_Param_UserGroup]
GO

ALTER TABLE [dbo].[Param_Client] DROP CONSTRAINT [FK_Param_Client_Param_ClientType]
GO

ALTER TABLE [dbo].[Faqs] DROP CONSTRAINT [FK_Faqs_Param_Project]
GO

ALTER TABLE [dbo].[Conv_TourRegister] DROP CONSTRAINT [FK_Conv_TourRegister_UsersProfile]
GO

ALTER TABLE [dbo].[Conv_TourRegister] DROP CONSTRAINT [FK_Conv_TourRegister_Param_Client]
GO

/****** Object:  Table [dbo].[UsersProfile]    Script Date: 12/29/2020 5:55:30 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UsersProfile]') AND type in (N'U'))
DROP TABLE [dbo].[UsersProfile]
GO

/****** Object:  Table [dbo].[UserLogin]    Script Date: 12/29/2020 5:55:30 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserLogin]') AND type in (N'U'))
DROP TABLE [dbo].[UserLogin]
GO

/****** Object:  Table [dbo].[Param_UserGroup]    Script Date: 12/29/2020 5:55:30 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Param_UserGroup]') AND type in (N'U'))
DROP TABLE [dbo].[Param_UserGroup]
GO

/****** Object:  Table [dbo].[Param_Project]    Script Date: 12/29/2020 5:55:30 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Param_Project]') AND type in (N'U'))
DROP TABLE [dbo].[Param_Project]
GO

/****** Object:  Table [dbo].[Param_ClientType]    Script Date: 12/29/2020 5:55:30 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Param_ClientType]') AND type in (N'U'))
DROP TABLE [dbo].[Param_ClientType]
GO

/****** Object:  Table [dbo].[Param_Client]    Script Date: 12/29/2020 5:55:30 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Param_Client]') AND type in (N'U'))
DROP TABLE [dbo].[Param_Client]
GO

/****** Object:  Table [dbo].[Faqs]    Script Date: 12/29/2020 5:55:30 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Faqs]') AND type in (N'U'))
DROP TABLE [dbo].[Faqs]
GO

/****** Object:  Table [dbo].[Conv_TourRegister]    Script Date: 12/29/2020 5:55:30 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Conv_TourRegister]') AND type in (N'U'))
DROP TABLE [dbo].[Conv_TourRegister]
GO

/****** Object:  Table [dbo].[Cont_EmergencyContacts]    Script Date: 12/29/2020 5:55:30 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cont_EmergencyContacts]') AND type in (N'U'))
DROP TABLE [dbo].[Cont_EmergencyContacts]
GO

/****** Object:  Table [dbo].[Cont_EmergencyContacts]    Script Date: 12/29/2020 5:55:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cont_EmergencyContacts](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DisplayName] [nvarchar](50) NULL,
	[ContactNumber] [varchar](15) NULL,
	[Descriptions] [nvarchar](max) NULL,
	[Status] [int] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_Cont_EmergencyContacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Conv_TourRegister]    Script Date: 12/29/2020 5:55:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Conv_TourRegister](
	[Id] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[TDate] [datetime] NOT NULL,
	[ToAddress] [varchar](250) NULL,
	[FromAddress] [varchar](250) NULL,
	[JourneyBy] [int] NULL,
	[Fare] [numeric](8, 2) NULL,
	[Remarks] [varchar](150) NULL,
	[Lat] [varchar](22) NULL,
	[Lan] [varchar](22) NULL,
	[UpOrDown] [int] NULL,
	[TerminalId] [varchar](100) NULL,
	[Status] [int] NULL,
	[ClientId] [int] NULL,
	[IsVerified] [int] NULL,
	[VerifiedAmount] [numeric](8, 2) NULL,
	[VerifiedBy] [int] NULL,
	[VerifiedDate] [datetime] NULL,
	[VerificationNote] [varchar](250) NULL,
	[IsApproved] [int] NULL,
	[ApprovedAmount] [numeric](8, 2) NULL,
	[ApprovedBy] [int] NULL,
	[ApprovedDate] [datetime] NULL,
	[ApprovedNote] [varchar](250) NULL,
	[SysDate] [datetime] NULL,
	[IssueId] [varchar](250) NULL,
 CONSTRAINT [PK_Con_ConvinceRegister] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Faqs]    Script Date: 12/29/2020 5:55:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Faqs](
	[Id] [int] NOT NULL,
	[Title] [nvarchar](250) NULL,
	[Description] [nvarchar](max) NULL,
	[ProjectId] [int] NULL,
	[Status] [int] NULL,
	[UpVote] [int] NULL,
	[DownVote] [int] NULL,
 CONSTRAINT [PK_Faqs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Param_Client]    Script Date: 12/29/2020 5:55:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Param_Client](
	[Id] [int] NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[DisplayName] [varchar](150) NOT NULL,
	[ClientTypeId] [int] NOT NULL,
	[Address] [varchar](150) NULL,
	[Lat] [varchar](50) NULL,
	[Lan] [varchar](50) NULL,
	[Status] [int] NULL,
	[ContactNo1] [varchar](15) NULL,
	[ContactNo2] [varchar](15) NULL,
	[Email] [varchar](50) NULL,
	[Website] [varchar](50) NULL,
	[Logo] [varchar](max) NULL,
	[Details] [varchar](250) NULL,
 CONSTRAINT [PK_Param_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Param_ClientType]    Script Date: 12/29/2020 5:55:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Param_ClientType](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
 CONSTRAINT [PK_Param_ClientType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Param_Project]    Script Date: 12/29/2020 5:55:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Param_Project](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[Remarks] [varchar](250) NULL,
 CONSTRAINT [PK_Param_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Param_UserGroup]    Script Date: 12/29/2020 5:55:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Param_UserGroup](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Param_UserGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[UserLogin]    Script Date: 12/29/2020 5:55:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserLogin](
	[UserId] [int] NOT NULL,
	[LoginName] [varchar](50) NULL,
	[LoginId] [varchar](50) NOT NULL,
	[Password] [varchar](300) NULL,
	[UserGroupId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[IsLogin] [int] NULL,
	[LoginTime] [datetime] NULL,
	[IsLogOut] [int] NULL,
	[LogOutTime] [datetime] NULL,
	[LatLan] [varchar](44) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_UserLogin] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[UsersProfile]    Script Date: 12/29/2020 5:55:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UsersProfile](
	[UserId] [int] NOT NULL,
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
	[JoiningDate] [datetime] NULL,
	[FireId] [varchar](max) NULL,
	[Nid] [varchar](15) NULL,
	[AccountStatus] [int] NULL,
 CONSTRAINT [PK_Users_1] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Conv_TourRegister]  WITH CHECK ADD  CONSTRAINT [FK_Conv_TourRegister_Param_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Param_Client] ([Id])
GO

ALTER TABLE [dbo].[Conv_TourRegister] CHECK CONSTRAINT [FK_Conv_TourRegister_Param_Client]
GO

ALTER TABLE [dbo].[Conv_TourRegister]  WITH CHECK ADD  CONSTRAINT [FK_Conv_TourRegister_UsersProfile] FOREIGN KEY([UserId])
REFERENCES [dbo].[UsersProfile] ([UserId])
GO

ALTER TABLE [dbo].[Conv_TourRegister] CHECK CONSTRAINT [FK_Conv_TourRegister_UsersProfile]
GO

ALTER TABLE [dbo].[Faqs]  WITH CHECK ADD  CONSTRAINT [FK_Faqs_Param_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Param_Project] ([Id])
GO

ALTER TABLE [dbo].[Faqs] CHECK CONSTRAINT [FK_Faqs_Param_Project]
GO

ALTER TABLE [dbo].[Param_Client]  WITH CHECK ADD  CONSTRAINT [FK_Param_Client_Param_ClientType] FOREIGN KEY([ClientTypeId])
REFERENCES [dbo].[Param_ClientType] ([Id])
GO

ALTER TABLE [dbo].[Param_Client] CHECK CONSTRAINT [FK_Param_Client_Param_ClientType]
GO

ALTER TABLE [dbo].[UserLogin]  WITH CHECK ADD  CONSTRAINT [FK_UserLogin_Param_UserGroup] FOREIGN KEY([UserGroupId])
REFERENCES [dbo].[Param_UserGroup] ([Id])
GO

ALTER TABLE [dbo].[UserLogin] CHECK CONSTRAINT [FK_UserLogin_Param_UserGroup]
GO

ALTER TABLE [dbo].[UserLogin]  WITH CHECK ADD  CONSTRAINT [FK_UserLogin_UsersProfile] FOREIGN KEY([UserId])
REFERENCES [dbo].[UsersProfile] ([UserId])
GO

ALTER TABLE [dbo].[UserLogin] CHECK CONSTRAINT [FK_UserLogin_UsersProfile]
GO










USE [FloraERP]
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Cont_EmergencyContacts]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Get_Cont_EmergencyContacts]
	
AS
BEGIN
	
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id,Name,DisplayName,ContactNumber,Descriptions from Cont_EmergencyContacts where Status = 1
END
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Faqs]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 2020-12-29
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Get_Faqs]
	
AS
BEGIN
	
	SET NOCOUNT ON;

   select f.*,p.Name as ProjectName from Faqs f,Param_Project p
   where p.Id = f.ProjectId and f.Status = 1


END
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Param_Client]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 2020-12-29
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Get_Param_Client]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select pc.*,pt.Name from Param_Client pc,Param_ClientType pt
	where pc.Status = 1


END
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Param_ClientType]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================

-- exec sp_Get_Param_ClientType

CREATE PROCEDURE [dbo].[sp_Get_Param_ClientType]
	
AS
BEGIN
	SET NOCOUNT ON;



	SELECT [Id]
      ,[Name]
      ,[Remarks]
	FROM [dbo].[Param_ClientType]



END
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Param_Project]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Get_Param_Project]
	@Id int,
	@Name   varchar(50),
    @Remarks  varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	select * from Param_Project


END
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_Param_UserGroup]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Get_Param_UserGroup]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	select * from Param_UserGroup


END
GO

/****** Object:  StoredProcedure [dbo].[sp_Get_User_By_Email]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 2020-12-29
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Get_User_By_Email]
	@LoginId varchar(50),
	@Password varchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT UserId,LoginId,LoginName,UserGroupId,pg.Name UserGroupName from UserLogin,Param_UserGroup pg
	where LoginId= @LoginId and Password = @Password and Status = 1
END
GO

/****** Object:  StoredProcedure [dbo].[sp_In_Cont_EmergencyContacts]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_In_Cont_EmergencyContacts]
	@Name  nvarchar(50),
    @DisplayName nvarchar(50),
    @ContactNumber varchar(15),
    @Descriptions nvarchar(max),
    @Status int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @Id int
	select @Id = (isnull(max(Id),0)+1) from Cont_EmergencyContacts


	INSERT INTO [dbo].[Cont_EmergencyContacts]
           ([Id]
           ,[Name]
           ,[DisplayName]
           ,[ContactNumber]
           ,[Descriptions]
           ,[Status]
           ,[CreatedDate])
     VALUES
           (@Id
           ,@Name
           ,@DisplayName
           ,@ContactNumber
           ,@Descriptions
           ,@Status
           ,GETDATE())


END
GO

/****** Object:  StoredProcedure [dbo].[sp_In_Faqs]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_In_Faqs]
	
           @Title  nvarchar(250),
           @Description nvarchar(max),
           @ProjectId int,
           @Status int = 1,
           @UpVote int = 0,
           @DownVote int = 0


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   
	declare @Id int
	select @Id = (isnull(max(Id),0)+1) from Faqs 


	INSERT INTO [dbo].[Faqs]
           ([Id]
           ,[Title]
           ,[Description]
           ,[ProjectId]
           ,[Status]
           ,[UpVote]
           ,[DownVote])
     VALUES
           (@Id
           ,@Title
           ,@Description
           ,@ProjectId
           ,@Status
           ,@UpVote
           ,@DownVote)






END
GO

/****** Object:  StoredProcedure [dbo].[sp_In_Param_Client]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 2020-12-29
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_In_Param_Client] 
	
	@Name varchar(150),
    @DisplayName varchar(150),
    @ClientTypeId int,
    @Address varchar(150),
    @Lat varchar(50),
    @Lan varchar(50),
    @Status int = 1,
    @ContactNo1 varchar(15),
    @ContactNo2 varchar(15) = '',
    @Email varchar(50) = '',
    @Website varchar(50) = '',
    @Logo varchar(max) = '',
    @Details varchar(250) = ''


AS
BEGIN
	SET NOCOUNT ON;

  
	declare @Id int
	select @Id = (isnull(max(Id),0)+1) from Param_Client 


	INSERT INTO [dbo].[Param_Client]
           ([Id]
           ,[Name]
           ,[DisplayName]
           ,[ClientTypeId]
           ,[Address]
           ,[Lat]
           ,[Lan]
           ,[Status]
           ,[ContactNo1]
           ,[ContactNo2]
           ,[Email]
           ,[Website]
           ,[Logo]
           ,[Details])
     VALUES
           (@Id
           ,@Name
           ,@DisplayName
           ,@ClientTypeId
           ,@Address
           ,@Lat
           ,@Lan
           ,@Status
           ,@ContactNo1
           ,@ContactNo2
           ,@Email
           ,@Website
           ,@Logo
           ,@Details)





END
GO

/****** Object:  StoredProcedure [dbo].[sp_In_Param_ClientType]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 20201229
-- Description:	Insert Param ClientType 
-- =============================================

-- sp_In_Param_ClientType 'Government School','Government Non Finintial Organigation'


CREATE PROCEDURE [dbo].[sp_In_Param_ClientType] 
	@Name  varchar(50),
    @Remarks varchar(150)
AS
BEGIN

	declare @Id int
	select @Id = (isnull(max(Id),0)+1) from Param_ClientType 


	INSERT INTO [dbo].[Param_ClientType]
           ([Id]
           ,[Name]
           ,[Remarks])
     VALUES
           (@Id
           ,@Name
           ,@Remarks)



END
GO

/****** Object:  StoredProcedure [dbo].[sp_In_Param_Project]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_In_Param_Project]
	@Name   varchar(50),
    @Remarks  varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    declare @Id int
	select @Id = (isnull(max(Id),0)+1) from Param_Project 


	INSERT INTO [dbo].[Param_Project]
           ([Id]
           ,[Name]
           ,[Remarks])
     VALUES
           (@Id
           ,@Name
           ,@Remarks)



END
GO

/****** Object:  StoredProcedure [dbo].[sp_In_Param_UserGroup]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_In_Param_UserGroup]
	@Name varchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	declare @Id int
	select @Id = (isnull(max(Id),0)+1) from Param_UserGroup 


	INSERT INTO [dbo].[Param_UserGroup]
           ([Id]
           ,[Name])
     VALUES
           (@Id
           ,@Name)




END
GO

/****** Object:  StoredProcedure [dbo].[sp_In_UserLogin]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 2020-12-29
-- Description:	<Description,,>
-- =============================================

-- exec sp_In_UserLogin 'Mortuza Hossain','admin','PJkJr+wlNU1VHa4hWQuybjjVPyFzuNPcPu5MBH56scHri4UQPjvnumE7MbtcnDYhTcnxSkL9ei/bhIVrylxEwg==',1

CREATE PROCEDURE [dbo].[sp_In_UserLogin]
	
	@LoginName  varchar(50),
    @LoginId  varchar(50),
    @Password  varchar(300),
    @UserGroupId  int,
    @IsLogin  int = 0,
    @IsLogOut int = 0,
    @LatLan varchar(44) = '',
	@Status int = 1

AS
BEGIN
	SET NOCOUNT ON;

	
	if not exists(select UserId from UserLogin where LoginId = @LoginId)
	begin

		declare @UserId int
		select @UserId = (isnull(max(UserId),0)+1) from UserLogin 

		
		Insert into UsersProfile (UserId,Name) Values (@UserId,@LoginName)

		INSERT INTO [dbo].[UserLogin]
			   ([UserId]
			   ,[LoginName]
			   ,[LoginId]
			   ,[Password]
			   ,[UserGroupId]
			   ,[CreateDate]
			   ,[IsLogin]
			   ,[LoginTime]
			   ,[IsLogOut]
			   ,[LogOutTime]
			   ,[LatLan]
			   ,[Status])
		 VALUES
			   (@UserId
			   ,@LoginName
			   ,@LoginId
			   ,@Password
			   ,@UserGroupId
			   ,GETDATE()
			   ,@IsLogin
			   ,GETDATE()
			   ,@IsLogOut
			   ,GETDATE()
			   ,@LatLan
			   ,@Status)


	end
END
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_Cont_EmergencyContacts]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Up_Cont_EmergencyContacts] 
	@Id int,
	@Name  nvarchar(50),
    @DisplayName nvarchar(50),
    @ContactNumber varchar(15),
    @Descriptions nvarchar(max),
    @Status int = 1
AS
BEGIN
	
	SET NOCOUNT ON;

   

	UPDATE [dbo].[Cont_EmergencyContacts]
	   SET [Name] = @Name 
		  ,[DisplayName] = @DisplayName 
		  ,[ContactNumber] = @ContactNumber 
		  ,[Descriptions] =@Descriptions 
		  ,[Status] = @Status 
	 WHERE Id = @Id




END
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_Faqs]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Up_Faqs]
	@Id int,
    @Title  nvarchar(250),
    @Description nvarchar(max),
    @ProjectId int,
    @Status int = 1


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   
	
	UPDATE [dbo].[Faqs]
	   SET 
		  [Title] = @Title
		  ,[Description] = @Description
		  ,[ProjectId] = @ProjectId
		  ,[Status] = @Status
	 WHERE Id = @Id



END
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_Param_Client]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 2020-12-29
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Up_Param_Client]
	@Id int,
	@Name varchar(150),
    @DisplayName varchar(150),
    @ClientTypeId int,
    @Address varchar(150),
    @Lat varchar(50),
    @Lan varchar(50),
    @Status int = 1,
    @ContactNo1 varchar(15),
    @ContactNo2 varchar(15) = '',
    @Email varchar(50) = '',
    @Website varchar(50) = '',
    @Logo varchar(max) = '',
    @Details varchar(250) = ''
AS
BEGIN
	SET NOCOUNT ON;



	UPDATE [dbo].[Param_Client]
	   SET [Name] = @Name
		  ,[DisplayName] = @DisplayName
		  ,[ClientTypeId] = @ClientTypeId
		  ,[Address] = @Address
		  ,[Lat] = @Lat
		  ,[Lan] = @Lan
		  ,[Status] = @Status
		  ,[ContactNo1] = @ContactNo1
		  ,[ContactNo2] = @ContactNo2
		  ,[Email] = @Email
		  ,[Website] = @Website
		  ,[Logo] = @Logo
		  ,[Details] = @Details
	 WHERE Id = @Id




    
END
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_Param_ClientType]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Up_Param_ClientType] 
	@Id int,
	@Name  varchar(50),
    @Remarks varchar(150)
AS
BEGIN
	
	SET NOCOUNT ON;


	UPDATE [dbo].[Param_ClientType]
	   SET [Name] = @Name
		  ,[Remarks] = @Remarks
	 WHERE Id = @Id


    
END
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_Param_Project]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Up_Param_Project]
	@Id int,
	@Name   varchar(50),
    @Remarks  varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	UPDATE [dbo].[Param_Project]
	   SET
		  [Name] = @Name
		  ,[Remarks] = @Remarks
	 WHERE Id = @Id






END
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_Param_UserGroup]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 20201229
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Up_Param_UserGroup]
	@Id int,
	@Name varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	UPDATE [dbo].[Param_UserGroup]
	SET
		[Name] = @Name
	WHERE Id = @Id




END
GO

/****** Object:  StoredProcedure [dbo].[sp_Up_UsersProfile]    Script Date: 12/29/2020 5:37:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Md Mortuza Hossain
-- Create date: 2020-12-29
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Up_UsersProfile]
	@UserId  int,
	@Name varchar(50),
	@Email varchar(50),
	@Phone varchar(15),
	@BloodGroup varchar(3),
	@MaritialStatus varchar(1),
	@Designation varchar(50),
	@Department varchar(50),
	@PresentAddress varchar(max),
	@PermanentAddress varchar(max),
	@EmergencyContact varchar(15),
	@Image varchar(50),
	@JoiningDate datetime,
	@FireId varchar(max),
	@Nid varchar(15),
	@AccountStatus int
AS
BEGIN
	SET NOCOUNT ON;



	UPDATE [dbo].[UsersProfile]
	   SET [Name] = @Name
		  ,[Email] = @Email
		  ,[Phone] = @Phone
		  ,[BloodGroup] = @BloodGroup
		  ,[MaritialStatus] = @MaritialStatus
		  ,[Designation] = @Designation
		  ,[Department] = @Department
		  ,[PresentAddress] = @PresentAddress
		  ,[PermanentAddress] = @PermanentAddress
		  ,[EmergencyContact] = @EmergencyContact
		  ,[Image] = @Image
		  ,[JoiningDate] = @JoiningDate
		  ,[FireId] = @FireId
		  ,[Nid] = @Nid
		  ,[AccountStatus] = @AccountStatus
	 WHERE UserId = @UserId




END
GO

ALTER PROCEDURE [dbo].[sp_In_UserLogin]
	@Email varchar(50),
	@LoginName  varchar(50),
    @LoginId  varchar(50),
    @Password  varchar(300),
    @UserGroupId  int,
    @IsLogin  int = 0,
    @IsLogOut int = 0,
    @LatLan varchar(44) = '',
	@Status int = 1

AS
BEGIN
	SET NOCOUNT ON;

	
	if not exists(select UserId from UserLogin where LoginId = @LoginId)
	begin

		declare @UserId int
		select @UserId = (isnull(max(UserId),0)+1) from UserLogin 

		
		Insert into UsersProfile (UserId,Name,Email) Values (@UserId,@LoginName,@Email)

		INSERT INTO [dbo].[UserLogin]
			   ([UserId]
			   ,[LoginName]
			   ,[LoginId]
			   ,[Password]
			   ,[UserGroupId]
			   ,[CreateDate]
			   ,[IsLogin]
			   ,[LoginTime]
			   ,[IsLogOut]
			   ,[LogOutTime]
			   ,[LatLan]
			   ,[Status])
		 VALUES
			   (@UserId
			   ,@LoginName
			   ,@LoginId
			   ,@Password
			   ,@UserGroupId
			   ,GETDATE()
			   ,@IsLogin
			   ,GETDATE()
			   ,@IsLogOut
			   ,GETDATE()
			   ,@LatLan
			   ,@Status)


	end
END
